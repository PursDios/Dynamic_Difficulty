using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dynamic_Difficulty
{
    public class Controller
    {
        private int m_Choice;
        private bool m_Successful;
        private readonly Gameplay g = new Gameplay();



        public void MainMenu()
        {
            Console.WriteLine("Please Select an Option: ");
            Console.WriteLine("1) Static Difficulty");
            Console.WriteLine("2) Dynamic Difficulty");
            m_Successful = int.TryParse(Console.ReadLine(), out m_Choice);

            if (!m_Successful)
            {
                return;
            }

            switch (m_Choice)
            {
                case 1:
                    g.StartGame(false);
                    break;
                case 2:
                    g.StartGame(true);
                    break;
                default:
                    Console.WriteLine("Invalid Selection Please Try Again");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
