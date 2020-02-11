using System.ComponentModel.DataAnnotations;

namespace ToyRobot.Models
{
    public class GameModel
    {
        [Required]
        [Display(Name = "Rows")]
        public int Rows { get; set; }

        [Required]
        [Display(Name = "Columns")]
        public int Columns { get; set; }
    }
}