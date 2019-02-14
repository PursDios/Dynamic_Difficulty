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
        private Controller c;
        private int m_Choice;
        private bool m_Successful=false, UI;

        public Controller()
        {

        }

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
                    m_Successful = false;
                    UIConsoleChoice();
                    Gameplay.getInstance().StartGame(false, UI);
                    break;
                case 2:
                    m_Successful = false;
                    UIConsoleChoice();
                    Gameplay.getInstance().StartGame(true, UI);
                    break;
                default:
                    Console.WriteLine("Invalid Selection Please Try Again");
                    Console.ReadLine();
                    break;
            }
        }
        private void UIConsoleChoice()
        {
            while (m_Successful != true)
            {
                Console.Clear();
                Console.WriteLine("UI or Console?");
                Console.WriteLine("1) UI");
                Console.WriteLine("2) Console");
                m_Successful = int.TryParse(Console.ReadLine(), out m_Choice);

                switch(m_Choice)
                {
                    case 1:
                        UI = true;
                        break;
                    case 2:
                        UI = false;
                        break;
                }
            }

            m_Successful = false;
            m_Choice = 0;
        }
    }
}
