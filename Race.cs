using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race3
{
    internal class Race
    {
        private List<Car> cars = new List<Car>
        {
            new Car("Bärgarn"),
            new Car("Guido"),
        };

        private List<Thread> raceThreads = new List<Thread>();
        private List<Car> raceResults = new List<Car>();
        private double raceDistanceLimit = 1;

        public void StartRace()
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Name} is off!");
            }

            var userInputEvent = new ManualResetEvent(false);
            var displayStatusThread = new Thread(() => DisplayStatusLoop(userInputEvent));
            displayStatusThread.Start();

            foreach (var car in cars)
            {
                var thread = new Thread(() => car.StartRace(raceDistanceLimit, raceResults, userInputEvent, new RaceEventHandler(car.Name))); // Pass RaceEventHandler instance
                raceThreads.Add(thread);
                thread.Start();
            }

            foreach (var thread in raceThreads)
            {
                thread.Join();
            }

            userInputEvent.Set();
            displayStatusThread.Join();

            Console.Clear();
            Console.WriteLine("Placings:\n");

            DisplayRaceResults();
        }

        private void DisplayStatusLoop(ManualResetEvent userInputEvent)
        {
            while (!userInputEvent.WaitOne(0))
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;
                    if (key == ConsoleKey.Enter)
                    {
                        DisplayAllCarStatus();
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void DisplayAllCarStatus()
        {
            Console.WriteLine();
            foreach (var car in cars)
            {
                car.DisplayStatus();
                //Console.WriteLine($"Time before the car returns: {car.TimeSinceLastEvent} seconds."); // Didn't get it to work
            }
        }

        private void DisplayRaceResults()
        {
            Console.Clear();
            Console.WriteLine("Race Results:\n");

            int position = 1;
            foreach (var car in raceResults.OrderBy(c => c.Distance))
            {
                Console.Write($"{position}. {car.Name}: ");

                if (position == 1)
                {
                    Console.WriteLine($"He is our new champion!");
                }
                else
                {
                    Console.WriteLine("Good race buddy.");
                }

                position++;
            }
        }
    }
}
