namespace Project2_LP2_2020
{
    public class BoardFiller
    {
        private Board board;

        public BoardFiller(Board board)
        {
            this.board = board;
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
        /// Checks if the top row of the chosen column is free.
        /// </summary>
        /// <param name="givenColumn">Int identifying the column chosen by 
        /// the player</param>
        /// <returns>Bool stating if the top row of the chosen column 
        /// is free</returns>
        public bool CanAdd(int givenColumn)
        {
            // Convert given number to account for array starting at '0'
            int boardColumn = givenColumn - 1;

            // If the highest space in the chosen column is free, return 'true'
            if (board.boardArray[boardColumn, 0] == Color.None) return true;
            else return false;
        }

        /// <summary>
        /// Places piece in the lowest row of the chosen column and returns 
        /// the row of the placed piece.
        /// </summary>
        /// <param name="givenColumn">The column chosen by the player</param>
        /// <param name="color">The color of the piece/param>
        /// <returns>Int with 'y' position of the placed piece in the 
        /// boardArray</returns>
        public int Add(int givenColumn, Color color)
        {
            // Convert given number to account for array starting at '0'
            int boardColumn = givenColumn - 1;

            // Loop starts at the top where the only garanteed free space is
            int currentRow = 0;

            // Starting from the top of the board, descend through the rows 
            // of the column until an occupied space is found
            while (currentRow < board.totRows - 1 &&
                board.boardArray[boardColumn, currentRow + 1] == Color.None)
            {
                currentRow++;
            }

            // Fill the lowest free space found in the column
            board.boardArray[boardColumn, currentRow] = color;

            return currentRow;
        }
    }
}