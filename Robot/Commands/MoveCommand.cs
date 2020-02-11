using Robot.Enums;
using Robot.Interfaces;

namespace Robot.Commands
{
    public class MoveCommand : ICommand
    {
        public IBot Bot { get; }
        public string Name { get; }

        private int _accX = 0;
        private int _accY = 0;

        public MoveCommand(IBot bot)
        {
            this.Bot = bot;
            this.Name = CommandType.MOVE.ToString();
        }

        /// <summary>
        /// Method used to update the robot position after the move command
        /// </summary>
        /// <returns></returns>
        public IPosition ProcessCommand()
        {
            SetAccumulator();
            return new Position(Bot.Position.PosX + _accX, Bot.Position.PosY + _accY, Bot.Position.Direction);
        }

        /// <summary>
        /// Method used to set the accumulator for the current move command.
        /// </summary>
        private void SetAccumulator()
        {
            switch (Bot.Position.Direction)
            {
                case Enums.Direction.NORTH:
                    _accX = 0;
                    _accY = 1;
                    break;
                case Enums.Direction.EAST:
                    _accX = 1;
                    _accY = 0;
                    break;
                case Enums.Direction.SOUTH:
                    _accX = 0;
                    _accY = -1;
                    break;
                case Enums.Direction.WEST:
                    _accX = -1;
                    _accY = 0;
                    break;
                default:
                    _accX = 0;
                    _accY = 0;
                    break;
            }
        }
    }
}
