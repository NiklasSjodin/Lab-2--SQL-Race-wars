using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race3
{
    internal class RaceEventHandler
    {
        private string carName;
        private Random random = new Random();

        public RaceEventHandler(string carName)
        {
            this.carName = carName;
        }

        public int HandleEvent(Car car)
        {
            var events = new List<(string, int)>
            {
                ("they forgot to fuel up. They need to go to the gas station.", 30),
                ("they run over some sharp snails and need to change their tire.", 20),
                ("there is bird shit all over the front window. They need to clean it.", 10),
                ("there seems to be an engine malfunction. The top speed is reduced by 1km/h. ", -1000)
            };

            var eventIndex = random.Next(events.Count);
            var (eventName, eventDuration) = events[eventIndex];

            Console.WriteLine($"\n{car.Name} is having a problem, {eventName}");

            if (eventDuration == -1000)
            {
                car.Speed -= 1;
                Thread.Sleep(Math.Max(eventDuration, 0));
            }
            else
            {
                Thread.Sleep(eventDuration * 1000);
            }

            return eventDuration;
        }
    }
}
