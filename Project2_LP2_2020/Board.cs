﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Project2_LP2_2020
{
    public class Board
    {
        // X axis of the board
        public readonly int totColumns;
        
        // Y axis of the board
        public readonly int totRows;
        
        // Array bi-dimensional de chars
        public Color [,] boardArray;

        public Board()
        {
            // Board dimensions. (totColumns = X, totRows = Y)
            totColumns = 7;
            totRows = 6;
            // Sets the dimensions of the bi-dimensional array 'boardArray' 
            // to the dimensions of the board
            boardArray = new Color[totColumns, totRows];

            CreateEmptyBoard();
        }

        //______________________________________________________________________
        //
        //       1   2   3   4   5   6   7
        //    -----------------------------
        //  1 |  O   O   O   O   O   O   O
        //  2 |  O   O   O   O   O   O   O
        //  3 |  O   O   O   O   O   O   O
        //  4 |  O   O   O   O   O   O   O
        //  5 |  O   O   O   O   O   O   O
        //  6 |  O   O   O   O   O   O   O
        //
        // Important info for all methods that work with the boardArray:
        //
        // The boardArray's [0, 0] position is equivalent to the game board's
        // top-left corner, with the [totColumns - 1, totRows - 1] position 
        // being the bottom-right corner.
        //______________________________________________________________________

        /// <summary>
        /// Fills the board array with empty values. 
        /// (Column by column, top-row to bottom-row)
        /// </summary>
        private void CreateEmptyBoard()
        {
            for (int col = 0; col < totColumns; col++)
            {
                for (int row = 0; row < totRows; row++)
                {
                    boardArray[col, row] = Color.None;
                }
            }
        }
    }
}