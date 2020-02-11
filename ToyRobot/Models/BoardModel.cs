using Robot.Enums;
using Robot.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToyRobot.Models
{
    public class BoardModel
    {
        public BoardModel() { }
        public BoardModel(IGameManager manager)
        {
            this.FinishedCommands = (List<string>)manager.FinishedCommands;
            this.Reports = (List<string>)manager.Reports;
        }

        [Display(Name = "Facing")]
        public Direction Direction { get; set; }

        [Display(Name = "X")]
        public int? PlaceX { get; set; }

        [Display(Name = "Y")]
        public int? PlaceY { get; set; }

        [Display(Name = "Finished cmd")]
        public List<string> FinishedCommands { get; set; }

        [Display(Name = "Reports")]
        public List<string> Reports { get; set; }
    }
}