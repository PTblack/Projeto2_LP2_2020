using System;
using System.Collections.Generic;
using System.Text;

namespace Project2_LP2_2020
{
    /// <summary>
    /// Describes current game state:
    /// Draw, [victory for] Yellow, [victory for] Red.
    /// </summary>
    public enum GameStage
    {
        /// <summary>
        /// Draw game.
        /// </summary>
        Draw,

        /// <summary>
        /// Yellow won.
        /// </summary>
        Yellow,

        /// <summary>
        /// Red won.
        /// </summary>
        Red,
    }
}
