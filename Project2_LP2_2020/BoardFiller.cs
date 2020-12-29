namespace Project2_LP2_2020
{
    public class BoardFiller
    {
        Board board;

        public BoardFiller(Board board)
        {
            this.board = board;
        }

        /// <summary>
        /// Checks if a piece can be added to the chosen row.
        /// </summary>
        /// <param name="givenColumn">The chosen column as given by the 
        /// player</param>
        /// <returns>A bool indicating if the given column is a valid 
        /// position to place a piece</returns>
        public bool CanAdd(int givenColumn)
        {
            // Convert given number to account for array starting at '0'
            int boardColumn = givenColumn - 1;

            // TEM QUE SE VERIFICAR SE O 'TOPO' DO TABULEIRO É '0' OU 'ROWS'!!!!
            // If the highest space in the chosen column is free, return 'true'
            if (board.boardArray[boardColumn, 0] == Color.None) return true;
            else return false;
        }

        /// <summary>
        /// Adds the player piece to the chosen valid column in the lowest 
        /// free space.
        /// </summary>
        /// <param name="givenColumn">The chosen column as given by the 
        /// player</param>
        /// <param name="color">The color of the piece (represents the 
        /// player)</param>
        public void Add(int givenColumn, Color color)
        {
            // Convert given number to account for array starting at '0'
            int boardColumn = givenColumn - 1;

            // Loop starts at the top where the only garanteed free space is
            int currentRow = 0;

            // TEM QUE SE VERIFICAR SE O 'TOPO' DO TABULEIRO É '0' OU 'ROWS'!!!!            
            // Starting from the top of the board, descend through the rows 
            // of the column until an occupied space is found
            while (currentRow < board.totRows - 1 &&
                board.boardArray[boardColumn, currentRow + 1] == Color.None)
            {
                currentRow++;
            }

            // Fill the lowest free space found in the column
            board.boardArray[boardColumn, currentRow] = color;
        }
    }
}