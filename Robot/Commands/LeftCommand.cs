using Robot.Enums;
using Robot.Interfaces;
using System;

namespace Robot.Commands
{
    public class LeftCommand : ICommand
    {
        public IBot Bot { get; }
        public string Name { get; }

        public LeftCommand(IBot bot)
        {
            this.Bot = bot;
            this.Name = CommandType.LEFT.ToString();
        }

        /// <summary>
        /// Method used to update the robot position after the Left Command
        /// </summary>
        /// <returns></returns>
        public IPosition ProcessCommand()
        {
            var numberOfDirections = Enum.GetNames(typeof(Direction)).Length;
            var updatedDirection = (Direction)(((int)this.Bot.Position.Direction - 1 + numberOfDirections) % numberOfDirections);

            return new Position(Bot.Position.PosX, Bot.Position.PosY, updatedDirection);
        }
    }
}
