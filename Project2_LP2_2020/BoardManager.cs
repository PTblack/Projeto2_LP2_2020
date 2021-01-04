namespace Project2_LP2_2020
{
    /// <summary>
    /// Facade class for BoardFiller and BoardSearcher.
    /// </summary>
    public class BoardManager
    {
        private readonly Board board;
        private readonly BoardFiller boardFiller;
        private readonly BoardSearcher boardSearcher;
        
        /// <summary>
        /// Constructor creates an instance of the 'Board' class and shares 
        /// its reference with the classes 'BoardFiller' and 'BoardSearcher' 
        /// so that they are all working with the same board.
        /// </summary>
        public BoardManager()
        {
            board = new Board();
            boardFiller = new BoardFiller(board);
            boardSearcher = new BoardSearcher(board);
        }

        /// <summary>
        /// If the chosen column is valid, place piece in its lowest free space.
        /// Else, send an error message.
        /// </summary>
        /// <param name="givenColumn">Column number given by the player.</param>
        /// <returns>bool.</returns>
        public bool TryAddingPiece(int givenColumn)
        {
            bool canAdd = false;
            if (boardFiller.CanAdd(givenColumn)) 
                canAdd = true;
            return canAdd;
        }

        /// <summary>
        ///  Places piece in the lowest row of the chosen column and returns
        /// the row of the placed piece.
        /// </summary>
        /// <param name="givenColumn">Column chosen by player.</param>
        /// <param name="playerColor">Color of the player.</param>
        /// <returns>Integer identifying the placed piece's row.</returns>
        public int AddPiece(int givenColumn, Color playerColor)
        {
            return boardFiller.Add(givenColumn, playerColor);
        }

        /// <summary>
        /// Applies the 'SearchWinSeq' methods to search for a victory sequence
        /// with the most recent piece's location.
        /// </summary>
        /// <param name="pieceCoordinates">The location of the most recent
        /// piece.</param>
        /// <returns>Boolean indicating if there is a victory sequence.</returns>
        public bool CheckWin(int[] pieceCoordinates)
        {
            // If any of the 'SearchWinSeq' methods find a winning sequence
            // (returning a 'true' boolean), the method returns 'true' as well.
            if (boardSearcher.SearchWinSeqTanPlus(pieceCoordinates) ||
                boardSearcher.SearchWinSeqTanNeg(pieceCoordinates) ||
                boardSearcher.SearchWinSeqHoriz(pieceCoordinates) ||
                boardSearcher.SearchWinSeqVert(pieceCoordinates))
                return true;
            else 
                return false;
        }

        /// <summary>
        /// Checks if the board is completely full.
        /// </summary>
        /// <returns>Bool indicating if the board is full.</returns>
        public bool CheckFull()
        {
            bool isFull = false;
            isFull = boardSearcher.BoardFull();

            return isFull;
        }

        /// <summary>
        /// Accesses the Board class' ToString() method.
        /// </summary>
        /// <returns>String returned by the Board class' ToString() 
        /// method.</returns>
        public string GetBoardString()
        {
            return board.ToString();
        }
    }
}