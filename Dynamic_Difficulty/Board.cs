using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Difficulty
{
    public class Board
    {
        private List<char> m_Arr;
        public Board(List<char> p_Arr)
        {
            m_Arr = p_Arr;
        }

        public void LoadBoard()
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

        public void UpdateBoard(List<char> p_Arr)
        {
            m_Arr = p_Arr;
            Console.Clear();
            LoadBoard();
        }
    }
}
