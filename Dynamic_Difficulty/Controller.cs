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
        private int m_Choice, difficulty;
        private bool m_Successful=false, UI, retry = true;

        public Controller()
        {

        }

        public void MainMenu()
        {
            while (retry != false)
            {
                StaticDynamicChoice();
                if (!m_Successful)
                {
                    return;
                }

                switch (m_Choice)
                {
                    case 1:
                        m_Successful = false;
                        UIConsoleChoice();
                        SetStaticDifficulty();
                        Gameplay.getInstance().StartGame(false, 3, UI);
                        break;
                    case 2:
                        m_Successful = false;
                        UIConsoleChoice();
                        Gameplay.getInstance().StartGame(true, 99, UI);
                        break;
                    default:
                        Console.WriteLine("Invalid Selection Please Try Again");
                        Console.ReadLine();
                        break;
                }
                char choice;
                Console.Clear();
                Console.WriteLine("Do you wish to play again? Y/N");
                char.TryParse(Console.ReadLine(), out choice);

                if (choice == 'y' || choice == 'Y')
                    retry = true;
                else
                    retry = false;
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
        private void StaticDynamicChoice()
        {
            Console.WriteLine("Please Select an Option: ");
            Console.WriteLine("1) Static Difficulty");
            Console.WriteLine("2) Dynamic Difficulty");
            m_Successful = int.TryParse(Console.ReadLine(), out m_Choice);
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
    }
}
