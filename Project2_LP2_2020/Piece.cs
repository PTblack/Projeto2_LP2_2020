using System;
using System.Collections.Generic;
using System.Text;

namespace Project2_LP2_2020
{
    public struct Piece
    {
        /// <summary>The piece position.</summary>
        public readonly Pos position;

        /// <summary>The piece color.</summary>
        public readonly Color color;

        public Piece(Pos pos, Color color)
        {
            position = pos;
            this.color = color;
        }

        /// <summary>
        /// Provides a string representation of the board position in the form
        /// "(row,col), color".
        /// </summary>
        /// <returns>A string representation of the board position.</returns>
        public override string ToString() => $"{position}, {color}";
    }
}
