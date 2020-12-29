namespace Project2_LP2_2020
{
    public class BoardSearcher
    {
        // In BoardSearcher
        /*
        Piece         - Struct saving a piece's position and Type (Cross or Circle)
        checkPiece    - Peça a ser usada para verificar posições no tabuleiro
        placedPiece   - Peça posta pelo jogador
        distance      - distancia da placedPiece para ser avaliada
        sequenceCount - Variable verifying if a sequence of four is found 
        */
        
        int distance;
        bool noValidSpacePos, noValidSpaceNeg;
        Board board;

        public BoardSearcher(Board board)
        {
            this.board = board;
        }


        // Para diagonal (45º) (TANGENTE POSITIVA)
        public bool SearchWinSeqTanPlus(int[] pieceCoordinates)
        {
            // Piece to be transformed in search of sequences with the placedPiece
            Piece checkPiece = new Piece();

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 0;

            // Check spaces at a distance fit for a sequence with the placedPiece
            for (distance = 1; distance < 3; distance++)
            {
                // Reset checkPiece Position for operation with distance (1st Quadrant)
                checkPiece = placedPiece;
                
                if (noValidSpacePos == false)
                {
                    checkPiece.AddToPositionX(distance);
                    checkPiece.AddToPositionY(distance);
                    // Is the proposed position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkPiece.PositionX > board.length || 
                        checkPiece.PositionY > board.height ||
                        board.GetSpaceStatus(
                            checkPiece.PositionX, checkPiece.PositionY) != 
                            placedPiece.PieceType)
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }

                // Reset checkPiece Position for operation with distance (3rd Quadrant)
                checkPiece = placedPiece;

                if (noValidSpaceNeg == false)
                {
                    checkPiece.AddToPositionX(-distance);
                    checkPiece.AddToPositionY(-distance);
                    // Is the proposed position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkPiece.PositionX < board.length || 
                        checkPiece.PositionY < board.height ||
                        board.GetSpaceStatus(
                            checkPiece.PositionX, checkPiece.PositionY) != 
                            placedPiece.PieceType)
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }
            }

            // if the sequence size reached 4 or more, declare a victory
            if (sequenceCount >= 4) return true;
            else return false;
        }


        // Para diagonal (135º) (TANGENTE NEGATIVA)
        public bool SearchWinSeqTanNeg(int[] pieceCoordinates)
        {
            // Piece to be transformed in search of sequences with the placedPiece
            Piece checkPiece = new Piece();

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 0;

            // Check spaces at a distance fit for a sequence with the placedPiece
            for (distance = 1; distance < 3; distance++)
            {
                // Reset checkPiece Position for operation with distance (2nd Quadrant)
                checkPiece = placedPiece;
                
                if (noValidSpacePos == false)
                {
                    checkPiece.AddToPositionX(-distance);
                    checkPiece.AddToPositionY(distance);
                    // Is the proposed position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkPiece.PositionX > board.length || 
                        checkPiece.PositionY > board.height ||
                        board.GetSpaceStatus(
                            checkPiece.PositionX, checkPiece. ) != 
                            placedPiece.PieceType)
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }

                // Reset checkPiece Position for operation with distance (4th Quadrant)
                checkPiece = placedPiece;

                if (noValidSpaceNeg == false)
                {
                    checkPiece.AddToPositionX(distance);
                    checkPiece.AddToPositionY(-distance);
                    // Is the proposed position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkPiece.PositionX > board.length || 
                        checkPiece.PositionY < 1 ||
                        board.GetSpaceStatus(
                            checkPiece.PositionX, checkPiece.PositionY) != 
                            placedPiece.PieceType)
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }
            }

            // if the sequence size reached 4 or more, declare a victory
            if (sequenceCount >= 4) return true;
            else return false;
        }


        // Para horizontal
        public bool SearchWinSeqHoriz(int[] pieceCoordinates)
        {
            // Piece to be transformed in search of sequences with the placedPiece
            Piece checkPiece = new Piece();

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 0;

            // Check spaces at a distance fit for a sequence with the placedPiece
            for (distance = 1; distance < 3; distance++)
            {
                // Reset checkPiece Position for operation with distance (Positive X)
                checkPiece = placedPiece;
                
                if (noValidSpacePos == false)
                {
                    checkPiece.AddToPositionX(distance);
                    // Is the proposed position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkPiece.PositionX > board.length || 
                        board.GetSpaceStatus(
                            checkPiece.PositionX, checkPiece.PositionY) != 
                            placedPiece.PieceType)
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }

                // Reset checkPiece Position for operation with distance (Negative X)
                checkPiece = placedPiece;

                if (noValidSpaceNeg == false)
                {
                    checkPiece.AddToPositionX(-distance);
                    // Is the proposed position outside the board (left of) or of a type 
                    // different of the placedPiece?
                    if (checkPiece.PositionX < 1 || 
                        board.GetSpaceStatus(
                            checkPiece.PositionX, checkPiece.PositionY) != 
                            placedPiece.PieceType)
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }
            }

            // if the sequence size reached 4 or more, declare a victory
            if (sequenceCount >= 4) return true;
            else return false;
        }


        // Para vertical
        public bool SearchWinSeqVert(int[] pieceCoordinates)
        {
            // Piece to be transformed in search of sequences with the placedPiece
            Piece checkPiece = new Piece();

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 0;

            // Check spaces at a distance fit for a sequence with the placedPiece
            for (distance = 1; distance < 3; distance++)
            {
                // Reset checkPiece Position for operation with distance (Positive Y)
                checkPiece = placedPiece;
                
                if (noValidSpacePos == false)
                {
                    checkPiece.AddToPositionY(distance);
                    // Is the proposed position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkPiece.PositionY > board.height ||
                        board.GetSpaceStatus(
                            checkPiece.PositionX, checkPiece.PositionY) != 
                            placedPiece.PieceType)
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }

                // Reset checkPiece Position for operation with distance (Negative X)
                checkPiece = placedPiece;

                if (noValidSpaceNeg == false)
                {
                    checkPiece.AddToPositionY(-distance);
                    // Is the proposed position outside the board (below) or of a type 
                    // different of the placedPiece?
                    if (checkPiece.PositionY < 1 ||
                        board.GetSpaceStatus(
                            checkPiece.PositionX, checkPiece.PositionY) != 
                            placedPiece.PieceType)
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }
            }

            // if the sequence size reached 4 or more, declare a victory
            if (sequenceCount >= 4) return true;
            else return false;
        }
    

    }
}