using System;

namespace Project2_LP2_2020
{
    /// <summary>
    /// Class tasked with adding pieces to the board and checking if the
    /// board's column is available (not full).
    /// </summary>
    public class BoardFiller
    {
        private readonly Board board;

        /// <summary>
        /// Saves the same board reference as the BoardManager and
        /// BoardSearcher.
        /// </summary>
        /// <param name="board">Reference to the board.</param>
        public BoardFiller(Board board)
        {
            this.board = board;
        }

        // ______________________________________________________________________
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
        // ______________________________________________________________________

        /// <summary>
        /// Checks if the top row of the chosen column is free.
        /// </summary>
        /// <param name="givenColumn">Int identifying the column chosen by
        /// the player.</param>
        /// <returns>Bool stating if the top row of the chosen column
        /// is free.</returns>
        public bool CanAdd(int givenColumn)
        {
            int boardColumn = givenColumn;

            // If the highest space in the chosen column is free, return 'true'
            return board.BoardArray[boardColumn, 0] == Color.None;
        }

        /// <summary>
        /// Places piece in the lowest row of the chosen column and returns
        /// the row of the placed piece.
        /// </summary>
        /// <param name="givenColumn">Column chosen by the player.</param>
        /// <param name="color">Color of the piece.</param>
        /// <returns>Integer with the placed piece's row.</returns>
        public int Add(int givenColumn, Color color)
        {
            int boardColumn = givenColumn;

            // Loop starts at the top where the only garanteed free space is
            int currentRow = 0;

            // Starting from the top of the board, descend through the rows 
            // of the column until an occupied space is found
            while (currentRow <= board.TotRows - 2 &&
                board.BoardArray[boardColumn, currentRow + 1] == Color.None)
            {
                currentRow++;
            }

            // Fill the lowest free space found in the column
            board.BoardArray[boardColumn, currentRow] = color;

            return currentRow;
        }
    }
}