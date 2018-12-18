using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Difficulty
{
    public class Gameplay
    {
        private char m_Turn = 'x';
        private bool m_End = false;
        private bool m_Dynamic = false;
        private List<char> m_Arr;

        public Gameplay()
        {

        }

        public void StartGame(bool dynamic)
        {
            m_Arr = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            m_Dynamic = dynamic;

            while (m_End == false)
            {
                LoadBoard();
                UserTakeTurn();
                if (m_Dynamic)
                    DynamicTakeTurn();
                else
                    StaticTakeTurn();
            }
        }

        private void LoadBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", m_Arr[0], m_Arr[1], m_Arr[2]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", m_Arr[3], m_Arr[4], m_Arr[5]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", m_Arr[6], m_Arr[7], m_Arr[8]);

            Console.WriteLine("     |     |      ");
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
            else if(m_Arr[6] == m_Arr[7] && m_Arr[7] == m_Arr[8])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[6]);
                m_End = true;
            }

            //top left to bottom right
            else if(m_Arr[0] == m_Arr[4] && m_Arr[4] == m_Arr[8])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[0]);
                m_End = true;
            }
            //top right to bottom left
            else if(m_Arr[2] == m_Arr[4] && m_Arr[6] == m_Arr[4])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[2]);
                m_End = true;
            }

            //top left to bottom left
            else if(m_Arr[0] == m_Arr[3] && m_Arr[3] == m_Arr[6])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[0]);
                m_End = true;
            }
            //top middle to bottom middle
            else if(m_Arr[1] == m_Arr[4] && m_Arr[4] == m_Arr[7])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[1]);
                m_End = true;
            }
            //top right to bottom right
            else if(m_Arr[2] == m_Arr[5] && m_Arr[5] == m_Arr[8])
            {
                Console.WriteLine("{0}'s wins!", m_Arr[2]);
                m_End = true;
            }

            //checks for a draw
            else if(m_Arr[1] != '1' && m_Arr[2] != '2' && m_Arr[3] != '3' && m_Arr[4] != '4' && m_Arr[5] != '5' && m_Arr[6] != '6' && m_Arr[7] != '7' && m_Arr[8] != '8' && m_Arr[9] != '9')
            {
                Console.WriteLine("Draw");
                m_End = true;
            }
        }

        private static void UserTakeTurn()
        {
            //TODO
        }

        private static void StaticTakeTurn()
        {
            //TODO
        }

        private static void DynamicTakeTurn()
        {
            //TODO
        }

    }
}
