using System;
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

        /// <summary>
        /// Builds a string illustrating boardArray as a 2D matrix with 
        /// coloured elements
        /// </summary>
        /// <returns>A string with the current boardArray</returns>
        public override string ToString()
        {
            string boardString = "";
           
           // Starts printing the top-row, progressing until reaching the 
           // end of the board (the bottom-row)
            for (int ro = 0; ro < totRows; ro++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                boardString += "| ";
                
                // Prints every space with the specified row, progressing from 
                // the left to the right of the board
                for (int col = 0; col < totColumns; col++)
                {
                    // Checks the color of the space in the coordinates 
                    // [col, ro], and adds to the string the appropriate simbol
                    Color coordinateColor = boardArray[col, ro];
                    switch (coordinateColor)
                    {
                        case Color.None:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            boardString += ".";
                            break;
                        case Color.Red:
                            Console.ForegroundColor = ConsoleColor.Red;
                            boardString += "R"; ;
                            break;
                        case Color.Yellow:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            boardString += "Y";
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    boardString += " | ";
                }
                // At the end of a row, begins a new line (for the next row)
                boardString += "\n";
            }

            Console.ForegroundColor = ConsoleColor.White;
            boardString += "_____________________________\n";

            return boardString;
        }
    }
}