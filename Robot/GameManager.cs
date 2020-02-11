using Robot.Commands;
using Robot.Constants;
using Robot.Enums;
using Robot.Interfaces;
using System.Collections.Generic;

namespace Robot
{
    public class GameManager : IGameManager
    {
        public IBot Bot { get; }

        public IGrid Grid { get; }

        public IList<string> FinishedCommands { get; }

        public IList<string> Reports { get; }

        public int? PlaceX { get; set; }

        public int? PlaceY { get; set; }

        public Direction? PlaceDirection { get; set; }


        public GameManager(IGrid grid, IBot bot)
        {
            this.Bot = bot;
            this.Grid = grid;
            this.FinishedCommands = new List<string>();
            this.Reports = new List<string>();
        }

        /// <summary>
        /// Auxiliary method used to check if a command can be executed.
        /// Without a valid Place Command, all other commands are considered invalid
        /// </summary>
        /// <param name="command">Command passed by the user</param>
        /// <returns></returns>
        private bool IsValidCommand(ICommand command)
        {
            if (command == null || (this.Bot.Position == null && !(command.GetType() == typeof(PlaceCommand))))
            {
                return false;
            }

            var processedCommand = command.ProcessCommand();

            if (this.Grid.CheckAvailability(processedCommand))
            {
                Bot.Position = processedCommand;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method used to cache the history of given commands
        /// </summary>
        /// <param name="command">Command passed</param>
        /// <param name="robot">The bot that is inside the grid</param>
        public void AddCommandResult(ICommand command, IBot robot)
        {
            var isValid = IsValidCommand(command);

            //If the given cmd is invalid, we just store the command in a cache
            if (!isValid)
            {
                this.FinishedCommands.Add(string.Format(GeneralCt.INVALID_CMD, this.FinishedCommands.Count + 1, command.Name));
            }
            else
            {
                //If the given cmd is a valid Report command, we will store the command in cache and also store the output
                if (command is ReportCommand)
                {
                    this.FinishedCommands.Add(string.Format(GeneralCt.VALID_CMD, this.FinishedCommands.Count + 1, command.Name));
                    this.Reports.Add(string.Format(GeneralCt.OUTPUT_CMD, this.FinishedCommands.Count, command.Bot.Position.GetCurrentPosition()));
                }
                else
                {
                    //If the given cmd is a valid command that is not a report, we just store the command in a cache
                    this.FinishedCommands.Add(string.Format(GeneralCt.VALID_CMD, this.FinishedCommands.Count + 1, command.Name));
                }
            }
        }

        /// <summary>
        /// Method used to create the requested commands
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bot"></param>
        /// <returns></returns>
        public ICommand CreateCommand(CommandType type, IBot bot)
        {
            switch (type)
            {
                case CommandType.PLACE:
                    return ComputePlaceCommand(bot);
                case CommandType.MOVE:
                    return new MoveCommand(bot);
                case CommandType.LEFT:
                    return new LeftCommand(bot);
                case CommandType.RIGHT:
                    return new RightCommand(bot);
                case CommandType.REPORT:
                    return new ReportCommand(bot);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Auxiliary method used to process the place command;
        /// This command needed a suplimentary check before being created
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        private ICommand ComputePlaceCommand(IBot bot)
        {
            if (this.PlaceX.HasValue && this.PlaceY.HasValue && this.PlaceDirection.HasValue)
            {
                return new PlaceCommand(this.PlaceX.Value, this.PlaceY.Value, this.PlaceDirection.Value, bot);
            }

            return new PlaceCommand(bot);
        }
    }
}
