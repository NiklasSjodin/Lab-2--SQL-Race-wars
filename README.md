# Race Simulation

Welcome to the exciting world of car racing simulation! This C# program simulates a race between multiple cars, each with its own set of challenges and events. Before you start, make sure you have the necessary dependencies and a C# development environment set up.

## Features

- The competition involves cars driving a distance of 1 km.
- All cars start at 0 km.
- Cars have a basic speed of 120 km/h, and no car is slower or faster than others from the start.
- Cars do not need to accelerate; they reach their speed instantly.
- Each car runs in its own thread for parallel processing.

## Challenges on the Road

Be prepared for unexpected events that may occur during the race. The following events can happen, each with its own probability and effect:

| Event                 | Probability | Effect                               |
| --------------------- | ----------- | ------------------------------------ |
| Out of gas            | 1/50        | Needs to refuel, stops 30 seconds    |
| Puncture              | 2/50        | Needs tire change, stops 20 seconds  |
| Bird on the windshield| 5/50        | Needs to wash windshield, stops 10 seconds |
| Engine failure        | 10/50       | The speed of the car is reduced by 1 km/h |

Every 30 seconds, a random event is generated for each car. Only one event can occur at a time.

## Run the Race

- All cars start at the same time.
- Console messages are displayed when:
  - Cars start.
  - A car encounters a problem, specifying the car and the problem.
  - A car reaches the finish line, with an additional message if it wins.
- The user can type "status" or press Enter to print the current position of all cars, including their distance and speed.

## How to Use

1. Clone the repository to your local machine.
2. Ensure you have a C# development environment installed.
3. Compile and run the `RaceSimulation.cs` file.
4. Enjoy the race and monitor the progress of each car!

Feel free to customize and extend the simulation to add more events or features. Happy racing! 🏁
