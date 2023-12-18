using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race3
{
    internal class RaceGame
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Race Wars!");
            Console.WriteLine("The race will soon begin...");
            Thread.Sleep(2000);
            Console.Clear();
        }
        public static void DisplayCountDown()
        {
            Console.Write("The race starts in 3..");
            Thread.Sleep(1000);
            Console.Write("2..");
            Thread.Sleep(1000);
            Console.Write("1..");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void ExitMessage()
        {
            Console.WriteLine("\nThank you for playing Race Wars! Press any key to exit.");
            Console.ReadKey();
        }
    }
}
