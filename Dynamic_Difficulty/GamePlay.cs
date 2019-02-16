using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dynamic_Difficulty
{
    public class Gameplay
    {
        private Thread ted;
        public Thread getTed { get { return ted; } }

        private BoardForm bf;
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
                if (m_Turn == 'X')
                    return true;
                else
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
        public bool getDynamic { get { return m_Dynamic; } }

        /// <summary>
        /// The choice the user made.
        /// </summary>
        private int m_Choice;
        public int getChoice { get { return m_Choice; } set { m_Choice = value; } }

        /// <summary>
        /// The board array.
        /// </summary>
        private char[] m_Arr;
        public char[] getCurrentBoard { get { return m_Arr; } set { m_Arr = value; } }

        /// <summary>
        /// The difficulty setting (auto adjusted for dynamic and hard set for static)
        /// </summary>
        private int m_Difficulty;

        private bool EndGameCalled = false;

        /// <summary>
        /// The total number of games won by the user.
        /// </summary>
        private int wins;

        /// <summary>
        /// The total number of games played.
        /// </summary>
        private int totalGames;

        bool replay = false;

        private static Gameplay g;

        private Gameplay()
        {

        }

        public static Gameplay getInstance()
        {
            if (g == null)
            {
                g = new Gameplay();
            }
            return g;
        }



        /// <summary>
        /// Assigns the starting inital values for the game and calls the gameplay loop
        /// </summary>
        /// <param name="dynamic">true or false, dynamic or static</param>
        /// <param name="difficulty">The static difficulty value if applicable else 99</param>
        /// <param name="UI">Display UI? True/False</param>
        public void StartGame(bool dynamic, int difficulty, bool UI)
        {
            m_End = false;
            m_Turn = 'X';
            m_Arr = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            m_B = new Board();
            m_M = new Minimax((char[])m_Arr.Clone(), false);
            m_Dynamic = dynamic;

            if (difficulty != 99)
                m_Difficulty = difficulty;

            if(UI)
            {
                if (ted == null || !ted.IsAlive)
                {
                    ted = new Thread(LoadUI);
                    ted.Start();
                }
            }
            GameplayLoop();
        }

        private void GameplayLoop()
        {
            m_B.UpdateCurrentBoard();
            while (!m_End)
            {
                if (!CheckWin())
                {
                    if (isTurnX)
                        UserChooseMove();
                    if (!CheckWin())
                    {
                        if (!isTurnX && m_Dynamic)
                            DynamicTakeTurn();
                        else
                            StaticTakeTurn();
                    }
                }
            }

            
            EndGame();
        }

        private void LoadUI()
        {
            bf = new BoardForm();
            bf.ShowDialog();
        }

        /// <summary>
        /// Checks to see if either the computer or the user has won. 
        /// </summary>
        /// <returns></returns>
        public bool CheckWin()
        {
            //TODO
            //top left to top right
            if (m_Arr[0] == m_Arr[1] && m_Arr[1] == m_Arr[2])
            {
                m_End = true;
            }
            //middle left to middle right
            else if (m_Arr[3] == m_Arr[4] && m_Arr[4] == m_Arr[5])
            {
                m_End = true;
            }
            //bottom left to bottom right
            else if (m_Arr[6] == m_Arr[7] && m_Arr[7] == m_Arr[8])
            {
                m_End = true;
            }

            //top left to bottom right
            else if (m_Arr[0] == m_Arr[4] && m_Arr[4] == m_Arr[8])
            {
                m_End = true;
            }
            //top right to bottom left
            else if (m_Arr[2] == m_Arr[4] && m_Arr[6] == m_Arr[4])
            {
                m_End = true;
            }

            //top left to bottom left
            else if (m_Arr[0] == m_Arr[3] && m_Arr[3] == m_Arr[6])
            {
                m_End = true;
            }
            //top middle to bottom middle
            else if (m_Arr[1] == m_Arr[4] && m_Arr[4] == m_Arr[7])
            {
                m_End = true;
            }
            //top right to bottom right
            else if (m_Arr[2] == m_Arr[5] && m_Arr[5] == m_Arr[8])
            {
                m_End = true;
            }

            // checks for a draw
            else if (m_Arr[0] != '1' && m_Arr[1] != '2' && m_Arr[2] != '3' && m_Arr[3] != '4' && m_Arr[4] != '5' && m_Arr[5] != '6' && m_Arr[6] != '7' && m_Arr[7] != '8' && m_Arr[8] != '9')
            {
                m_End = true;
            }

            if (m_End == true)
            {
                if (ted != null)
                    if (ted.IsAlive)
                    {
                        bf.Hide();
                    }
                return true;
            }

            return false;
        }

        private void EndGame()
        {
            if (m_Arr[0] != '1' && m_Arr[1] != '2' && m_Arr[2] != '3' && m_Arr[3] != '4' && m_Arr[4] != '5' && m_Arr[5] != '6' && m_Arr[6] != '7' && m_Arr[7] != '8' && m_Arr[8] != '9')
                Console.WriteLine("Draw!");
            else
            {
                if (isTurnX)
                    Console.WriteLine("O's Win!");
                else
                    Console.WriteLine("X's Win!");
            }
            Console.WriteLine("PRESS ENTER TO CONTINUE");
            Console.ReadLine();
        }

        private void UserChooseMove()
        {
            //TODO
            m_Choice = -1;
            do
            {
                Console.Clear();
                m_B.UpdateCurrentBoard();
                Console.WriteLine("Where would you like to go (1-9)");
                int.TryParse(Console.ReadLine(), out m_Choice);
            } while (m_Choice == -1);
            UserTakeTurn(m_Choice);
        }

        /// <summary>
        /// Queries the user for their move, checks it's valid and applies it to the board.
        /// </summary>
        public void UserTakeTurn(int choice)
        {
            m_Choice = choice;
            if (!CheckWin())
            {
                if (m_Choice != -1)
                {
                    if (CheckChoice())
                    {
                        ApplyChoice();
                    }
                }
            }
        }
        /// <summary>
        /// Uses statically assigned values and the minimax algorithum to take a move. 
        /// </summary>
        public void StaticTakeTurn()
        {
            if (r == null)
                r = new Random();

            int ranChance = r.Next(8);

            Minimax max;
            if (ranChance < m_Difficulty)
            {
                m_M.UpdateBoard(this.m_Arr);
                max = m_M.FindNextMove(m_Difficulty);
                this.m_Arr = max.MG;
                m_Turn = 'X';
            }
            else
            {
                Randomisation();
            }
        }
        /// <summary>
        /// Uses dynamic difficulty adjustment and the minimax algorithum to make take a move.
        /// </summary>
        public void DynamicTakeTurn()
        {
            m_Difficulty = 5;
            r = new Random();


            int loses = totalGames - wins;
            if (loses > wins)
            {
                int differece = loses - wins;
                m_Difficulty = 5 - differece;
                if (m_Difficulty < 1)
                    m_Difficulty = 1;
            }
            else if (wins > loses)
            {
                int difference = wins - loses;
                m_Difficulty = 5 + wins;
                if (m_Difficulty > 8)
                    m_Difficulty = 8;
            }
            else
                m_Difficulty = 5;

            int ranChance = 8 - m_Difficulty;
            ranChance = r.Next(ranChance);

            if (ranChance < m_Difficulty)
            {
                m_M.UpdateBoard(this.m_Arr);
                Minimax max = m_M.FindNextMove(m_Difficulty);
                this.m_Arr = max.MG;
                m_Turn = 'X';
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
        public void ApplyChoice()
        {
            m_Arr[m_Choice - 1] = m_Turn;

            if (m_Turn == 'X')
                m_Turn = 'O';
            else
                m_Turn = 'X';

            m_B.UpdateCurrentBoard();
            if (ted != null)
            {
                if (ted.IsAlive)
                    bf.UpdateBoard();
            }
        }
        public void Update()
        {
            m_B.UpdateCurrentBoard();
            m_M.UpdateBoard(this.m_Arr);

            if (ted != null)
                if (ted.IsAlive)
                    bf.UpdateBoard();
        }
    }
}
