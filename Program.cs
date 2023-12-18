using System.Collections.Concurrent;

namespace Race3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RaceGame.DisplayWelcomeMessage();
            RaceGame.DisplayCountDown();
            
            Race race = new Race();
            race.StartRace();

            RaceGame.ExitMessage();
        }
    }
}
