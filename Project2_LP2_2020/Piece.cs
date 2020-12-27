using System;
using System.Collections.Generic;
using System.Text;

namespace Project2_LP2_2020
{
    /// <summary>
    /// Struct holding a piece's position on the board and its color.
    /// </summary>
    public struct Piece
    {
        /// <summary>The piece's position, obtained from the 
        /// struct 'Pos'.</summary>
        public readonly Pos position;

        /// <summary>The piece's color, obtained from the 
        /// enumeration 'Color'.</summary>
        public readonly Color color;

        public Piece(Pos position, Color color)
        {
            this.position = position;
            this.color = color;
        }

        /// <summary>
        /// Provides a string with the piece's attributes in the format: 
        /// "Position: (row,col]) / Color: color" 
        /// *see position attribute's ToString method from the 'Pos' struct
        /// </summary>
        /// <returns>A string with the piece's attributes.</returns>
        public override string ToString() => 
                        $"Position: {position} / Color: {color}";
    }
}
