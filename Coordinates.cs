using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class Coordinates
    {
        enum Valid
        {
            MinValue = 1,
            MaxValue = 3
        }
        public Coordinates(int xCoordinate, int yCoordinate)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.isValid = CheckCoordinateValidity(xCoordinate, yCoordinate);
        }

        private static bool CheckCoordinateValidity(int xCoordinate, int yCoordinate)
        {
            var validCoordinateCondition = xCoordinate >= (int)Valid.MinValue && yCoordinate >= (int)Valid.MinValue && xCoordinate <= (int)Valid.MaxValue && yCoordinate <= (int)Valid.MaxValue;
            
            return (validCoordinateCondition) ? true : false;
        }
        public int XCoordinate { get; set;}
        public int YCoordinate { get; set;}
        public bool isValid { get; set;}
    }
}