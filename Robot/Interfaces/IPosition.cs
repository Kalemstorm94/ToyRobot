using Robot.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Interfaces
{
    public interface IPosition
    {
        int PosX { get; set; }

        int PosY { get; set; }

        Direction Direction { get; set; }

        string GetCurrentPosition();
    }
}
