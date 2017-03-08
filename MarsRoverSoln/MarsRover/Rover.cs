using System;

namespace MarsRover
{
    public class Rover
    {
        /// <summary>
        /// current X coordinate of the Rover
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Current Y coordinate of the Rover
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Current direction of the Rover (N,S,E,W)
        /// </summary>
        public Direction D { get; set; }

        /// <summary>
        /// Method will move the current instance of Rover. Rover can turn or make one movement. 
        /// </summary>
        /// <param name="move">a char command as L (left), R (right), M (move)</param>
        /// <param name="p">gets the current state of plateau on Mars which the rover is on</param>
        public void Move(char move, Plateau p)
        {
            switch (move)
            {
                case 'L':
                    if (D == Direction.N)
                    {
                        D = Direction.W;
                    }
                    else if (D == Direction.S)
                    {
                        D = Direction.E;
                    }
                    else if (D == Direction.E)
                    {
                        D = Direction.N;
                    }
                    else if (D == Direction.W)
                    {
                        D = Direction.S;
                    }
                    break;

                case 'R':
                    if (D == Direction.N)
                    {
                        D = Direction.E;
                    }
                    else if (D == Direction.S)
                    {
                        D = Direction.W;
                    }
                    else if (D == Direction.E)
                    {
                        D = Direction.S;
                    }
                    else if (D == Direction.W)
                    {
                        D = Direction.N;
                    }
                    break;

                case 'M':

                    if (D == Direction.N)
                    {
                        if (Y == p.maxY)
                        {
                            throw new CantMoveException("Can't move anymore");
                        }
                        Y++;
                    }

                    else if (D == Direction.S)
                    {
                        if (Y == p.minY)
                        {
                            throw new CantMoveException("Can't move anymore");
                        }
                        Y--;
                    }

                    else if (D == Direction.E)
                    {
                        if (X == p.maxX)
                        {
                            throw new CantMoveException("Can't move anymore");
                        }
                        X++;
                    }

                    else if (D == Direction.W)
                    {
                        if (X == p.minX)
                        {
                            throw new CantMoveException("Can't move anymore");
                        }
                        X--;
                    }

                    break;


                default:
                    break;
            }
        }

        /// <summary>
        /// Shows the current information of the Rover. X Y coordinates and direction.
        /// </summary>
        public void ShowStatus()
        {
            Console.WriteLine($"{X} {Y} {D}");
        }
    }
}
