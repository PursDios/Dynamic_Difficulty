using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Difficulty
{
    public class Board
    {
        /// <summary>
        /// The Board Array
        /// </summary>
        private char[] m_Arr;

        public Board(char[] p_Arr)
        {
            m_Arr = p_Arr;
        }

        /// <summary>
        /// Displays the tic tac toe board
        /// </summary>
        public void LoadBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |      ");
            Console.Write("  "); CalculateColour(m_Arr[0]); Console.Write("  |  "); CalculateColour(m_Arr[1]); Console.Write("  |  "); CalculateColour(m_Arr[2]); Console.Write("\n");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.Write("  "); CalculateColour(m_Arr[3]); Console.Write("  |  "); CalculateColour(m_Arr[4]); Console.Write("  |  "); CalculateColour(m_Arr[5]);  Console.Write("\n");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.Write("  "); CalculateColour(m_Arr[6]); Console.Write("  |  "); CalculateColour(m_Arr[7]); Console.Write("  |  "); CalculateColour(m_Arr[8]); Console.Write("\n");
            Console.WriteLine("     |     |      ");
        }

        /// <summary>
        /// Updates the current board values, clears the console and updates the board
        /// </summary>
        /// <param name="p_Arr"></param>
        public void UpdateBoard(char[] p_Arr)
        {
            m_Arr = p_Arr;
            Console.Clear();
            LoadBoard();
        }

        /// <summary>
        /// reads the board values and colour codes according to the character
        /// </summary>
        /// <param name="c"></param>
        private void CalculateColour(char c)
        {
            if (c == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(c);
                Console.ResetColor();
            }
            else if (c == 'O')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(c);
                Console.ResetColor();
            }
            else
            {
                Console.Write(c);
            }
        }
    }
}
