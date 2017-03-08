using System;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau p = getPlateau();
            Rover rover1 = getRover();
            getInstructions(p, rover1);
            Rover rover2 = getRover();
            getInstructions(p, rover2);
            rover1.ShowStatus();
            rover2.ShowStatus();
            Console.ReadKey();
        }

        /// <summary>
        /// gets plateau fields from user interaction
        /// </summary>
        /// <returns>new plateau instance</returns>
        private static Plateau getPlateau()
        {
            Plateau p;
            bool result = false;
            int X = 0, Y = 0;
            string input = string.Empty;
            string[] splitted;
            while (result == false)
            {
                Console.WriteLine("enter upper-right coordinates of plateau:");
                input = Console.ReadLine();
                splitted = input.Split(' ');
                result = int.TryParse(splitted[0], out X);
                result = int.TryParse(splitted[1], out Y);
            }

            p = new Plateau()
            {
                minX = 0,
                minY = 0,
                maxX = X,
                maxY = Y
            };
            return p;
        }

        /// <summary>
        /// gets rover fields from user interaction
        /// </summary>
        /// <returns>new rover instance</returns>
        private static Rover getRover()
        {
            bool result = false;
            int X = 0, Y = 0;
            Rover rover = null;
            while (result == false)
            {
                Console.WriteLine("enter rover info:");
                string input = Console.ReadLine();
                string[] splitted = input.Split(' ');
                result = int.TryParse(splitted[0], out X);
                result = int.TryParse(splitted[1], out Y);
                char directionChar = splitted[2].FirstOrDefault();

                rover = new Rover
                {
                    X = X,
                    Y = Y
                };

                if (directionChar == 'N')
                {
                    rover.D = Direction.N;
                }
                else if (directionChar == 'W')
                {
                    rover.D = Direction.W;
                }
                else if (directionChar == 'E')
                {
                    rover.D = Direction.E;
                }
                else if (directionChar == 'S')
                {
                    rover.D = Direction.S;
                }
                else
                {
                    result = false;
                }
            }

            return rover;
        }

        /// <summary>
        /// gets the movement instructions from user interaction and moves the rover on the plateau
        /// </summary>
        /// <param name="p"></param>
        /// <param name="rover"></param>
        private static void getInstructions(Plateau p, Rover rover)
        {
            Console.WriteLine("enter instructions:");
            string instruction = Console.ReadLine();

            foreach (var c in instruction)
            {
                rover.Move(c, p);
            }
        }
    }
}
