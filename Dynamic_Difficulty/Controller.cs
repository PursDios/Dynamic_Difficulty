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
        private int choice;
        private bool successful;
        private Gameplay g = new Gameplay();
        public void MainMenu()
        {
            Console.WriteLine("Please Select an Option: ");
            Console.WriteLine("1) Static Difficulty");
            Console.WriteLine("2) Dynamic Difficulty");
            successful = int.TryParse(Console.ReadLine(), out choice);

            if (successful)
            {
                if (choice == 1)
                {
                    StaticDifficulty();
                }
                else if(choice == 2)
                {
                    DynamicDifficulty();
                }
            }
        }
    }
}
