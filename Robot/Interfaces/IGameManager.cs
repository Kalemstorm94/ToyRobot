using Robot.Commands;
using Robot.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Interfaces
{
    public interface IGameManager
    {
        IBot Bot { get; }
        IGrid Grid { get; }
        IList<string> FinishedCommands { get; }
        IList<string> Reports { get; }
        int? PlaceX { get; set; }
        int? PlaceY { get; set; }
        Direction? PlaceDirection { get; set; }
        void AddCommandResult(ICommand command, IBot bot);
        ICommand CreateCommand(CommandType type, IBot bot);


    }
}
