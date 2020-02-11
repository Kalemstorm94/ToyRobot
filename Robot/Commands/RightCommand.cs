using Robot.Enums;
using Robot.Interfaces;
using System;

namespace Robot.Commands
{
    public class RightCommand : ICommand
    {
        public IBot Bot { get; }
        public string Name { get; }

        public RightCommand(IBot bot)
        {
            this.Bot = bot;
            this.Name = CommandType.RIGHT.ToString();
        }

        /// <summary>
        /// Method used to update the robot position, after the Right command. 
        /// </summary>
        /// <returns></returns>
        public IPosition ProcessCommand()
        {
            var numberOfDirections = Enum.GetNames(typeof(Direction)).Length;
            var updatedDirection = (Direction)(((int)this.Bot.Position.Direction + 1) % numberOfDirections);

            return new Position(Bot.Position.PosX, Bot.Position.PosY, updatedDirection);
        }
    }
}
