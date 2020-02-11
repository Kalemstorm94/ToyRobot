using Robot.Constants;
using Robot.Enums;
using Robot.Interfaces;

namespace Robot
{
    public class Position : IPosition
    {
        public int PosX { get; set; }

        public int PosY { get; set; }

        public Direction Direction { get; set; }

        public Position(int x, int y, Direction dir)
        {
            this.PosX = x;
            this.PosY = y;
            this.Direction = dir;
        }

        /// <summary>
        /// Method used to get the output for a valid report command
        /// </summary>
        /// <returns></returns>
        public string GetCurrentPosition()
        {
            return string.Format(GeneralCt.POSITION_TEMPLATE, this.PosX, this.PosY, Direction.ToString());
        }
    }
}
