using Robot.Enums;
using Robot.Interfaces;

namespace Robot.Commands
{
    public class PlaceCommand : ICommand
    {
        public IBot Bot { get; }
        public string Name { get; }

        private int _x { get; set; }
        private int _y { get; set; }
        private Direction _direction { get; set; }

        private bool _hasDirection { get; }

        public PlaceCommand(IBot bot)
        {
            this.Bot = bot;
            this.Name = CommandType.PLACE.ToString();
            _hasDirection = false;
        }

        public PlaceCommand(int x, int y, Direction dir, IBot bot)
        {
            this._x = x;
            this._y = y;
            this._direction = dir;
            this.Bot = bot;
            this.Name = CommandType.PLACE.ToString();
            this._hasDirection = true;
        }

        /// <summary>
        /// Method used to update the robot possition after the Place command
        /// </summary>
        /// <returns></returns>
        public IPosition ProcessCommand()
        {
            if (this._hasDirection)
            {
                return new Position(this._x, this._y, this._direction);
            }

            return null;
        }
    }
}
