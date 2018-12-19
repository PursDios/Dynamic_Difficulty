using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dynamic_Difficulty
{
    public class Gameplay
    {
        private Board b;
        private char m_Turn = 'x';
        private bool m_End = false;
        private bool m_Dynamic = false;
        private int m_Choice;
        private List<char> m_Arr;

        public void StartGame(bool dynamic)
        {
            m_Arr = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            b = new Board(m_Arr);
            m_Dynamic = dynamic;

            while (m_End == false)
            {
                b.LoadBoard();
                UserTakeTurn();
                if (m_Dynamic)
                    DynamicTakeTurn();
                else
                    StaticTakeTurn();
            }
        }

        private void CheckWin()
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

            //checks for a draw
            else if (m_Arr[1] != '1' && m_Arr[2] != '2' && m_Arr[3] != '3' && m_Arr[4] != '4' && m_Arr[5] != '5' && m_Arr[6] != '6' && m_Arr[7] != '7' && m_Arr[8] != '8' && m_Arr[9] != '9')
            {
                Console.WriteLine("Draw");
                m_End = true;
            }
        }

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

        private static void StaticTakeTurn()
        {
            //TODO
        }

        private static void DynamicTakeTurn()
        {
            //TODO
        }

        public  bool CheckChoice()
        {
            if (m_Arr[m_Choice - 1] == 'X' || m_Arr[m_Choice - 1] == 'O')
                return false;
            else
                return true;
        }

        protected void ApplyChoice()
        {
            //TODO
        }
    }
}
