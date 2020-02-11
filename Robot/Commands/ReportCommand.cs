using Robot.Enums;
using Robot.Interfaces;

namespace Robot.Commands
{
    public class ReportCommand : ICommand
    {
        public IBot Bot { get; }
        public string Name { get; }
        public ReportCommand(IBot bot)
        {
            this.Bot = bot;
            this.Name = CommandType.REPORT.ToString();
        }

        /// <summary>
        /// Method used to get the robot position, after the Report Command
        /// </summary>
        /// <returns></returns>
        public IPosition ProcessCommand()
        {
            return Bot.Position;
        }
    }
}
