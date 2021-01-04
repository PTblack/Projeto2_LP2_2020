using System;
using System.Collections.Generic;
using System.Text;

namespace Project2_LP2_2020
{
    /// <summary>
    /// The three possible colors for a board space, indicating if it is empty
    /// or if it is occupied by one of the players.
    /// </summary>
    public enum Color
    {
        /// <summary>
        /// Empty space.
        /// </summary>
        None,

        /// <summary>
        /// Yellow piece / player.
        /// </summary>
        Yellow,

        /// <summary>
        /// Red piece / player.
        /// </summary>
        Red,
    }
}
