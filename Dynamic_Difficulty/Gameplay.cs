using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dynamic_Difficulty
{
    public class Gameplay
    {
        /// <summary>
        /// The board.
        /// </summary>
        private Board m_B;
        /// <summary>
        /// The Randomisation.
        /// </summary>
        private Random r;
        /// <summary>
        /// Minimax object.
        /// </summary>
        private Minimax m_M;

        /// <summary>
        /// Who's turn it is.
        /// </summary>
        private char m_Turn = 'X';
        public bool isTurnX
        {
            get
            {
                if (m_Turn == 'O')
                    return true;
                return false;
            }
            set
            {
                if (m_Turn == 'X')
                    m_Turn = 'O';
                else
                    m_Turn = 'O';
            }
        }

        /// <summary>
        /// Whether the game is finished or not.
        /// </summary>
        private bool m_End = false;
        public bool isEnd { get { return m_End; } }
        /// <summary>
        /// Is dynamic boolean.
        /// </summary>
        private bool m_Dynamic = false;

        /// <summary>
        /// The choice the user made.
        /// </summary>
        private int m_Choice;

        /// <summary>
        /// The board array.
        /// </summary>
        private char[] m_Arr;
        public char[] getCurrentBoard { get { return m_Arr; } }

        /// <summary>
        /// The difficulty setting (auto adjusted for dynamic and hard set for static)
        /// </summary>
        private int difficulty = 0;

        /// <summary>
        /// The total number of games won by the user.
        /// </summary>
        private int wins;

        /// <summary>
        /// The total number of games played.
        /// </summary>
        private int totalGames;

        /// <summary>
        /// The gameplay loop.
        /// </summary>
        /// <param name="dynamic"></param>
        public void StartGame(bool dynamic)
        {
            bool replay = true;
            char input = 'N';
            do
            {
                m_End = false;
                m_Arr = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                m_B = new Board(m_Arr);
                m_Dynamic = dynamic;
                m_M = new Minimax((char[])m_Arr.Clone(), false);

                if (!m_Dynamic)
                    SetStaticDifficulty();
                while (!m_End)
                {
                    //Update the board the user can see
                    m_B.UpdateBoard(this.m_Arr);
                    //Update the board for the Minimax Algo.
                    m_M.UpdateBoard(this.m_Arr);
                    if (!CheckWin())
                    {
                        m_Turn = 'X';
                        UserTakeTurn();
                    }
                    m_B.UpdateBoard(this.m_Arr);
                    m_M.UpdateBoard(this.m_Arr);
                    if (!CheckWin())
                    {
                        m_Turn = 'O';
                        if (m_Dynamic)
                            DynamicTakeTurn();
                        else
                            StaticTakeTurn();
                        this.CheckWin();
                    }
                }

                Console.WriteLine("Do you wish to play again? Y/N");
                char.TryParse(Console.ReadLine(), out input);
                if (input == 'Y' || input == 'y')
                    replay = true;
                else
                    replay = false;

            } while (replay != false);
        }
        /// <summary>
        /// Checks to see if either the computer or the user has won. 
        /// </summary>
        /// <returns></returns>
        private bool CheckWin()
        {
            //TODO
            //top left to top right
            if (m_Arr[0] == m_Arr[1] && m_Arr[1] == m_Arr[2])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[0]);
                m_End = true;
            }
            //middle left to middle right
            else if (m_Arr[3] == m_Arr[4] && m_Arr[4] == m_Arr[5])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[3]);
                m_End = true;
            }
            //bottom left to bottom right
            else if (m_Arr[6] == m_Arr[7] && m_Arr[7] == m_Arr[8])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[6]);
                m_End = true;
            }

            //top left to bottom right
            else if (m_Arr[0] == m_Arr[4] && m_Arr[4] == m_Arr[8])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[0]);
                m_End = true;
            }
            //top right to bottom left
            else if (m_Arr[2] == m_Arr[4] && m_Arr[6] == m_Arr[4])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[2]);
                m_End = true;
            }

            //top left to bottom left
            else if (m_Arr[0] == m_Arr[3] && m_Arr[3] == m_Arr[6])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[0]);
                m_End = true;
            }
            //top middle to bottom middle
            else if (m_Arr[1] == m_Arr[4] && m_Arr[4] == m_Arr[7])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[1]);
                m_End = true;
            }
            //top right to bottom right
            else if (m_Arr[2] == m_Arr[5] && m_Arr[5] == m_Arr[8])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[2]);
                m_End = true;
            }

            // checks for a draw
            else if (m_Arr[0] != '1' && m_Arr[1] != '2' && m_Arr[2] != '3' && m_Arr[3] != '4' && m_Arr[4] != '5' && m_Arr[5] != '6' && m_Arr[6] != '7' && m_Arr[7] != '8' && m_Arr[8] != '9')
            {
                Console.WriteLine("Draw");
                m_End = true;
            }

            if (m_End == true)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Queries the user for their move, checks it's valid and applies it to the board.
        /// </summary>
        private void UserTakeTurn()
        {
            //TODO
            m_Choice = -1;
            Console.WriteLine("Where would you like to go (1-9)");
            int.TryParse(Console.ReadLine(), out m_Choice);
            if (m_Choice != -1)
            {
                if (CheckChoice())
                {
                    ApplyChoice();
                }
            }

        }
        /// <summary>
        /// Sets the difficulty of the static game.
        /// </summary>
        private void SetStaticDifficulty()
        {
            if (difficulty == 0)
            {
                bool valid = false;
                int choice = 0;
                while (valid == false)
                {
                    Console.Clear();
                    m_B.LoadBoard();

                    Console.WriteLine("What difficulty would you like to play at?");
                    Console.WriteLine("1) Easy\n2) Medium\n3) Hard");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        difficulty = choice;
                        valid = true;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid Entry.\nPlease ensure that you only enter a number.\nPRESS ENTER TO CONTINUE");
                        Console.ReadLine();
                    }
                }
                if (difficulty == 2)
                    difficulty = 4;
                if (difficulty == 3)
                    difficulty = 8;
            }

        }
        /// <summary>
        /// Uses statically assigned values and the minimax algorithum to take a move. 
        /// </summary>
        private void StaticTakeTurn()
        {
            if (r == null)
                r = new Random();

            int ranChance = r.Next(8);

            Minimax max;
            if (ranChance < difficulty)
            {
                max = m_M.FindNextMove(difficulty);
                this.m_Arr = max.MG;
            }
            else
            {
                Randomisation();
            }
        }
        /// <summary>
        /// Uses dynamic difficulty adjustment and the minimax algorithum to make take a move.
        /// </summary>
        private void DynamicTakeTurn()
        {
            difficulty = 5;
            r = new Random();


            int loses = totalGames - wins;
            if (loses > wins)
            {
                int differece = loses - wins;
                difficulty = 5 - differece;
                if (difficulty < 1)
                    difficulty = 1;
            }
            else if (wins > loses)
            {
                int difference = wins - loses;
                difficulty = 5 + wins;
                if (difficulty > 8)
                    difficulty = 8;
            }
            else
                difficulty = 5;

            int ranChance = 8 - difficulty;
            ranChance = r.Next(ranChance);

            if (ranChance < difficulty)
            {
                Minimax max = m_M.FindNextMove(difficulty);
                this.m_Arr = max.MG;
            }
            else
                Randomisation();
        }
        /// <summary>
        /// Randomly generates a number and uses that as the AI's move.
        /// </summary>
        private void Randomisation()
        {
            int i;
            r = new Random();
            do
            {
                i = r.Next(1, 10);
                m_Choice = i;
            } while (!CheckChoice());
            ApplyChoice();
        }

        /// <summary>
        /// Checks if the move is valid/not taken
        /// </summary>
        /// <returns></returns>
        public bool CheckChoice()
        {
            if (m_Arr[m_Choice - 1] == 'X' || m_Arr[m_Choice - 1] == 'O')
                return false;
            else
                return true;
        }

        /// <summary>
        /// Applies the choice to the board.
        /// </summary>
        protected void ApplyChoice()
        {
            m_Arr[m_Choice - 1] = m_Turn;

            if (m_Turn == 'X')
                m_Turn = 'O';
            else
                m_Turn = 'X';

            m_B.LoadBoard();
        }
    }
}
