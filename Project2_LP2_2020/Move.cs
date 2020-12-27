using System;
using System.Collections.Generic;
using System.Text;

namespace Project2_LP2_2020
{
    public struct Move
    {
        /// <summary>Board row where the piece was placed.</summary>
        public readonly int row;

        /// <summary>Board column where the piece was placed.</summary>
        public readonly int col;

        /// <summary>Piece used for the move.</summary>
        public readonly Color color;

        /// <summary>Create a move.</summary>
        /// <param name="row">Board row where the piece was placed.</param>
        /// <param name="col">Board column where the piece was placed.</param>
        /// <param name="piece">Piece used for the move.</param>
        public Move(int row, int col, Color color)
        {
            this.row = row;
            this.col = col;
            this.color = color;
        }
    }
}
