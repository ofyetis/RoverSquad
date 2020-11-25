using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Helpers
{
    public enum Direction
    {
        [Description("E")]
        East = 1,
        [Description("W")]
        West = 2,
        [Description("S")]
        South = 3,
        [Description("N")]
        North = 4
    }
    public enum Movement
    {
        [Description("L")]
        TurnLeft = 1,
        [Description("R")]
        TurnRight = 2,
        [Description("M")]
        Move = 3
    }
}
