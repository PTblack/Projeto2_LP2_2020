﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project2_LP2_2020
{
    /// <summary>
    /// Describes current game state:
    /// Menus, Ongoing, Draw, [victory for] Yellow, [victory for] Red.
    /// </summary>
    public enum  Winner
    {
        Menus,
        Ongoing,
        Draw,
        Yellow,
        Red,
    }
}
