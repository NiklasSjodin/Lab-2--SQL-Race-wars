using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race3
{
    internal class Car
    {
        private Random random = new Random();

        public string Name { get; }
        public double Speed { get; set; }
        public double Distance { get; set; }
        public int TimeSinceLastEvent { get; private set; }

        public Car(string name, double initialSpeed = 120, double initialDistance = 0)
        {
            Name = name;
            Speed = initialSpeed;
            Distance = initialDistance;
            TimeSinceLastEvent = 0;
        }
        public void StartRace(double raceDistanceLimit, List<Car> raceResults, ManualResetEvent userInputEvent, RaceEventHandler eventHandler)
        {
            while (Distance < raceDistanceLimit)
            {
                SimulateTimePassing();
                MoveCar();

                if (TimeSinceLastEvent > 0)
                {
                    TimeSinceLastEvent--;
                }
                else if (ShouldGenerateRandomEvent())
                {
                    int eventDuration = eventHandler.HandleEvent(this);
                    TimeSinceLastEvent = eventDuration;
                }

                HandleUserInput(userInputEvent);
            }

            UpdateRaceResults(raceResults);
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"{Name} is at {Distance:F2} km, with a current speed of {Speed} km/h.");
        }

        private void SimulateTimePassing()
        {
            Thread.Sleep(1000);
        }

        private void MoveCar()
        {
            Distance += Speed / 3600;
        }

        private bool ShouldGenerateRandomEvent()
        {
            const double eventProbability = 0.06;
            return random.NextDouble() < eventProbability;
        }

        private void HandleUserInput(ManualResetEvent userInputEvent)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                if (key == ConsoleKey.Enter)
                {
                    userInputEvent.Set();
                }
            }
        }

        private void UpdateRaceResults(List<Car> raceResults)
        {
            lock (raceResults)
            {
                raceResults.Add(this);

                Console.WriteLine($"\n{Name} has finished the race!");

                if (raceResults.Count == 1)
                {
                    Console.WriteLine($"{Name} is the winner!");
                }
                else
                {
                    var position = raceResults.IndexOf(this) + 1;
                    Console.WriteLine($"{Name} finished in position {position}");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}

