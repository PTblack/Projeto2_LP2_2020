namespace Project2_LP2_2020
{
    /// <summary>
    /// Facade class for BoardFiller and BoardSearcher
    /// </summary>
    public class BoardManager
    {
        Board board;
        BoardFiller boardFiller;
        BoardSearcher boardSearcher;
        
        /// <summary>
        /// Constructor creates an instance of the 'Board' class and shares 
        /// its reference with the classes 'BoardFiller' and 'BoardSearcher' 
        /// so that they are all working with the same board
        /// </summary>
        public BoardManager()
        {
            board = new Board();
            boardFiller = new BoardFiller(board);
            boardSearcher = new BoardSearcher(board);
        }

        /// <summary>
        /// If the chosen column is valid, place piece in its lowest free space,
        /// else, send error message.
        /// </summary>
        /// <param name="givenColumn">Column number given by the player</param>
        /// <param name="playerColor">Identifies the current player</param>
        private void TryAddingPiece(int givenColumn, Color playerColor)
        {
            if (boardFiller.CanAdd(givenColumn))
            {
                boardFiller.Add(givenColumn, playerColor);
            }
            else ExceptionManager.ExceptionControl(ErrorCodes.InvalidColumn);
        }

        /// <summary>
        /// Applies the 'SearchWinSeq' methods to search for a victory sequence
        /// with the most recent piece's location
        /// </summary>
        /// <param name="newPieceLoc">The location of the most recent 
        /// piece</param>
        /// <returns>Boolean indicating if there is a victory sequence</returns>
        private bool CheckWin (int[] pieceCoordinates)
        {
            if (boardSearcher.SearchWinSeqTanPlus(pieceCoordinates)||
                boardSearcher.SearchWinSeqTanNeg(pieceCoordinates)||
                boardSearcher.SearchWinSeqHoriz(pieceCoordinates)||
                boardSearcher.SearchWinSeqVert(pieceCoordinates))
                return true;
            else return false;
        }

        /// <summary>
        /// Accesses the Board class' ToString() method
        /// </summary>
        /// <returns>String returned by the Board class' ToString() 
        /// method</returns>
        private string GetBoardString()
        {
            return board.ToString();
        }
    }
}