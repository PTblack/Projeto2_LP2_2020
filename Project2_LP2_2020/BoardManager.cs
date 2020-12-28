namespace Project2_LP2_2020
{
    public class BoardManager
    {
        Board board = new Board();
        BoardSearcher boardSearcher = new BoardSearcher();
        private bool CheckWin (Piece placedPiece)
        {
            bool sequenceTanPlus, sequenceTanNeg, 
            sequenceHoriz, sequenceVert = false;

            sequenceTanPlus = boardSearcher.SearchWinSeqTanPlus(placedPiece);
            sequenceTanNeg  = boardSearcher.SearchWinSeqTanNeg(placedPiece);
            sequenceHoriz   = boardSearcher.SearchWinSeqHoriz(placedPiece);
            sequenceVert    = boardSearcher.SearchWinSeqVert(placedPiece);

            if (sequenceTanPlus || sequenceTanNeg || 
                sequenceHoriz || sequenceVert)
                return true;
            else 
                return false;
        }

        /// <summary>
        /// Checks if the number given by the player is a valid board column
        /// (if it is in the board and if it isn't full)
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private bool CheckPosition(int column)
        {
            // Checks if the chosen column exists in the board
            if (1 <= column <= board.lenght)
                {
                    // Checks if the column has space(s) available
                    if (board.boardArray[column, board.height] == "e")
                        return true;
                    else 
                        return false;
                }
            else return false;
        }
    }
}