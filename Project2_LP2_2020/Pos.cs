using System;
using System.Collections.Generic;
using System.Text;

namespace Project2_LP2_2020
{
    public struct Pos
    {
        /// <summary>Board row.</summary>
        public readonly int row;

        /// <summary>Board column.</summary>
        public readonly int col;

        /// <summary>
        /// Creates a new board position.
        /// </summary>
        /// <param name="row">Board row.</param>
        /// <param name="col">Board column.</param>
        public Pos(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        /// <summary>
        /// Provides a string representation of the board position in the form
        /// "(row,col)".
        /// </summary>
        /// <returns>A string representation of the board position.</returns>
        public override string ToString() => $"({row},{col})";
    }
}
