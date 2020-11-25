using Helpers;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarsRoverBusiness
{
    public class Rover
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public Direction Direction { get; set; }
        public List<Movement> MovementList { get; set; }

        /// <summary>
        /// It calculates the new last position's coordinates and direction.
        /// It takes three parameter: squad, plateau and considerBoundaryAndCrash
        /// </summary>
        /// <param name="squad"></param>
        /// <param name="plateau"></param>
        /// <param name="considerBoundaryAndCrash"></param>
        /// <returns></returns>
        public Result MakeTheRoverMove(Squad squad = null, Plateau plateau = null, bool considerBoundaryAndCrash = false)
        {
            //Find the rover index in squad to compare it later.
            int roverIndex = -1;
            int idx = -1;
            if (squad != null && squad.rovers.Count > 0)
            {
                roverIndex = squad.rovers.FindIndex(x => x.CoordinateX == CoordinateX && x.CoordinateY == CoordinateY);
            };
            foreach (var movement in MovementList)
            {
                //switch the movement letter
                switch (movement)
                {
                    case Movement.Move:
                        CalculateNewCoordinates(this);
                        //Controlling if the calculated point is out of border or not.
                        if (considerBoundaryAndCrash && (CoordinateX > plateau.UpperRightX || CoordinateY > plateau.UpperRightY))
                        {
                            return new Result()
                            {
                                Success = false,
                                ErrorMessage = "The route is not within the boundaries!"
                            };
                        }
                        //Finding the index of rover that is at the same point with this rover.
                        if (considerBoundaryAndCrash && squad != null && squad.rovers.Count > 0)
                        {
                            idx = squad.rovers.FindIndex(x => x.CoordinateX == CoordinateX && x.CoordinateY == CoordinateY);
                            //if there is rover at the corresponding point and this is an another rover, return error message
                            if (idx > -1 && idx != roverIndex)
                            {
                                return new Result()
                                {
                                    Success = false,
                                    ErrorMessage = "The rover will crash with another rover with this route. Please change the route!"
                                };
                            }
                        }
                        break;
                    case Movement.TurnLeft:
                    case Movement.TurnRight:
                        CalculateNewDirection(this, movement);
                        break;
                    default:
                        break;
                }
            };
            return new Result()
            {
                Success = true,
                ErrorMessage = ""
            };
        }

        /// <summary>
        /// It calculates the new coordinates according to the rover direction.
        /// </summary>
        /// <param name="rover"></param>
        private static void CalculateNewCoordinates(Rover rover)
        {
            switch (rover.Direction) //If direction is "E" or "W" the rover will move on the X axis else it will move on Y axis
            {
                case Direction.East:
                    rover.CoordinateX += 1;
                    break;
                case Direction.North:
                    rover.CoordinateY += 1;
                    break;
                case Direction.West:
                    rover.CoordinateX -= 1;
                    break;
                case Direction.South:
                    rover.CoordinateY -= 1;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// It calculates the new direction according to the rover's previous direction and movement command.
        /// </summary>
        /// <param name="rover"></param>
        /// <param name="movement"></param>
        private static void CalculateNewDirection(Rover rover, Movement movement)
        {
            switch (rover.Direction)
            {
                case Direction.East:
                    rover.Direction = movement == Movement.TurnLeft ? Direction.North : Direction.South;
                    break;
                case Direction.North:
                    rover.Direction = movement == Movement.TurnLeft ? Direction.West : Direction.East;
                    break;
                case Direction.West:
                    rover.Direction = movement == Movement.TurnLeft ? Direction.South : Direction.North;
                    break;
                case Direction.South:
                    rover.Direction = movement == Movement.TurnLeft ? Direction.East : Direction.West;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// It checks the string co-ordinate value of the rover, if it matches with the format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsPointHasValidFormat(string value)
        {
            Regex regex = new Regex(@"^(\d+)\s(\d+)\s([NWSE])$");
            Match match = regex.Match(value);
            if (!match.Success)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// It checks the string movement commands value of the rover, if it matches with the format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsMovementHasValidFormat(string value)
        {
            Regex regex = new Regex(@"^([LMR])+$");
            Match match = regex.Match(value);
            if (!match.Success)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// It checks if the rovers co-ordinate is within the boundaries.
        /// It takes the plateau as parameter.
        /// </summary>
        /// <param name="plateau"></param>
        /// <returns></returns>
        public bool IsRoverPointWithinBorder(Plateau plateau)
        {
            if ((CoordinateX < 0 || CoordinateX > plateau.UpperRightX) ||
                    (CoordinateY < 0 || CoordinateY > plateau.UpperRightY))
            {
                return false;
            }
            return true;
        }

    }
}
