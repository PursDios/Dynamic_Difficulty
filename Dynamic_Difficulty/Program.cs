using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Difficulty
{
    public class Program
    {
        private static Controller c;
        static void Main(string[] args)
        {
            c = new Controller();
            c.MainMenu();
        }
    }
}
