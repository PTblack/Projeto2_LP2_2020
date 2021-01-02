using Project2_LP2_2020.GameEngine;
using System.Data;

namespace Project2_LP2_2020
{
    /// <summary>
    /// Facade class for BoardFiller and BoardSearcher
    /// </summary>
    public class BoardManager
    {
        private Board board;
        private BoardFiller boardFiller;
        private BoardSearcher boardSearcher;
        
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
        /// If the chosen column is valid, place piece in its lowest free space.
        /// Else, send an error message.
        /// </summary>
        /// <param name="givenColumn">Column number given by the player</param>
        /// <param name="playerColor">Identifies the current player</param>
        public bool TryAddingPiece(int givenColumn, Color playerColor)
        {
            bool canAdd = false;
            
            if (boardFiller.CanAdd(givenColumn)) 
                canAdd = true;
            else 
                ExceptionManager.ExceptionControl(ErrorCodes.InvalidColumn);

            return canAdd;
        }

        // Places piece in the lowest row of the chosen column and returns 
        // the row of the placed piece
        public int AddPiece(int givenColumn, Color playerColor)
        {
            return boardFiller.Add(givenColumn, playerColor);
        }

        /// <summary>
        /// Applies the 'SearchWinSeq' methods to search for a victory sequence
        /// with the most recent piece's location
        /// </summary>
        /// <param name="pieceCoordinates">The location of the most recent 
        /// piece</param>
        /// <returns>Boolean indicating if there is a victory sequence</returns>
        public bool CheckWin (int[] pieceCoordinates)
        {
            // If any of the 'SearchWinSeq' methods find a winning sequence
            // (returning a 'true' boolean), the method returns 'true' as well.
            if (boardSearcher.SearchWinSeqTanPlus(pieceCoordinates) ||
                boardSearcher.SearchWinSeqTanNeg(pieceCoordinates) ||
                boardSearcher.SearchWinSeqHoriz(pieceCoordinates) ||
                boardSearcher.SearchWinSeqVert(pieceCoordinates))
                return true;
            else return false;
        }

        /// <summary>
        /// Checks if the board is completely full.
        /// </summary>
        /// <returns>Bool indicating if the board is full</returns>
        public bool CheckFull()
        {
            bool isFull = false;
            isFull = boardSearcher.BoardFull();

            return isFull;
        }

        /// <summary>
        /// Sends message announcing the end of the match, stating what end 
        /// condition was met.
        /// </summary>
        /// <param name="gameStage">parameter that allows method to identify 
        /// the end condition that made this method be called</param>
        public string AnnounceWinner(GameStage gameStage)
        {
            string anounceState = "Match is Over";
            switch (gameStage)
            {
                case GameStage.Draw:
                    anounceState =  "\nIt's a DRAW!\n";
                    break;

                case GameStage.Yellow:
                    anounceState = "\nIt's a Victory for YELLOW!\n";
                    break;

                case GameStage.Red:
                    anounceState = "\nIt's a Victory for RED!\n";
                    break;
            }

            return anounceState;
        }

        /// <summary>
        /// Accesses the Board class' ToString() method
        /// </summary>
        /// <returns>String returned by the Board class' ToString() 
        /// method</returns>
        public string GetBoardString()
        {
            return board.ToString();
        }
    }
}