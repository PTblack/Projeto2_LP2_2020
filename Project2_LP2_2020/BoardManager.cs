namespace Project2_LP2_2020
{
    public class BoardManager
    {
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
    }
}