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
        /// Displays the tic tac toe board
        /// </summary>
        public void UpdateCurrentBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |      ");
            Console.Write("  "); CalculateColour(Gameplay.getInstance().getCurrentBoard[0]); Console.Write("  |  "); CalculateColour(Gameplay.getInstance().getCurrentBoard[1]); Console.Write("  |  "); CalculateColour(Gameplay.getInstance().getCurrentBoard[2]); Console.Write("\n");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.Write("  "); CalculateColour(Gameplay.getInstance().getCurrentBoard[3]); Console.Write("  |  "); CalculateColour(Gameplay.getInstance().getCurrentBoard[4]); Console.Write("  |  "); CalculateColour(Gameplay.getInstance().getCurrentBoard[5]);  Console.Write("\n");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.Write("  "); CalculateColour(Gameplay.getInstance().getCurrentBoard[6]); Console.Write("  |  "); CalculateColour(Gameplay.getInstance().getCurrentBoard[7]); Console.Write("  |  "); CalculateColour(Gameplay.getInstance().getCurrentBoard[8]); Console.Write("\n");
            Console.WriteLine("     |     |      ");
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
