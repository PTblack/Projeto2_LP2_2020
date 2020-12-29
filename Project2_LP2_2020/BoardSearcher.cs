namespace Project2_LP2_2020
{
    public class BoardSearcher
    {
        // Distance of the value being evaluated to the placed piece
        int distance;
        
        // Booleans to verify if there are no more valid spaces in an area
        bool noValidSpacePos, noValidSpaceNeg;
        
        // Array containing the 2D coordinates of the space being evaluated for 
        // a sequence
        int[] checkCoordinates = new int[2];

        Board board;

        public BoardSearcher(Board board)
        {
            this.board = board;
        }

        // Search sequence in the positive tangent diagonal 
        // (1st and 3rd Quadrants)
        public bool SearchWinSeqTanPlus(int[] placedCoordinates)
        {
            checkCoordinates = placedCoordinates;

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 0;

            // Check spaces at a distance fit for a sequence with 
            // the placedPiece
            for (distance = 1; distance < 4; distance++)
            {
                // Reset checkCoordinates for operation with distance 
                checkCoordinates = placedCoordinates;
                
                if (noValidSpacePos == false)
                {
                    // Search in the 1st Quadrant
                    checkCoordinates[0] = checkCoordinates[0] + distance;
                    checkCoordinates[1] = checkCoordinates[1] + distance;

                    // Is the checked position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkCoordinates[0] >= board.totColumns || 
                        checkCoordinates[1] >= board.totRows ||
                        board.boardArray[checkCoordinates[0], 
                                         checkCoordinates[1]] != 
                        board.boardArray[placedCoordinates[0], 
                                         placedCoordinates[1]])
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }

                // Reset checkCoordinates for operation with distance 
                checkCoordinates = placedCoordinates;
                
                if (noValidSpaceNeg == false)
                {
                    // Search in the 3rd Quadrant
                    checkCoordinates[0] = checkCoordinates[0] - distance;
                    checkCoordinates[1] = checkCoordinates[1] - distance;

                    // Is the checked position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkCoordinates[0] < 0 || 
                        checkCoordinates[1] < 0 ||
                        board.boardArray[checkCoordinates[0], 
                                         checkCoordinates[1]] != 
                        board.boardArray[placedCoordinates[0], 
                                         placedCoordinates[1]])
                    {
                        noValidSpaceNeg = true;
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

        // Search sequence in the negative tangent diagonal 
        // (2nd and 4th Quadrants)
        public bool SearchWinSeqTanNeg(int[] placedCoordinates)
        {
            checkCoordinates = placedCoordinates;

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 0;

            // Check spaces at a distance fit for a sequence with 
            // the placedPiece
            for (distance = 1; distance < 4; distance++)
            {
                // Reset checkCoordinates for operation with distance 
                checkCoordinates = placedCoordinates;
                
                if (noValidSpacePos == false)
                {
                    // Search in the 2nd Quadrant
                    checkCoordinates[0] = checkCoordinates[0] - distance;
                    checkCoordinates[1] = checkCoordinates[1] + distance;

                    // Is the checked position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkCoordinates[0] < 0 || 
                        checkCoordinates[1] >= board.totRows ||
                        board.boardArray[checkCoordinates[0], 
                                         checkCoordinates[1]] != 
                        board.boardArray[placedCoordinates[0], 
                                         placedCoordinates[1]])
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }

                // Reset checkCoordinates for operation with distance 
                checkCoordinates = placedCoordinates;
                
                if (noValidSpaceNeg == false)
                {
                    // Search in the 4th Quadrant
                    checkCoordinates[0] = checkCoordinates[0] + distance;
                    checkCoordinates[1] = checkCoordinates[1] - distance;

                    // Is the checked position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkCoordinates[0] >= board.totColumns || 
                        checkCoordinates[1] < 0 ||
                        board.boardArray[checkCoordinates[0], 
                                         checkCoordinates[1]] != 
                        board.boardArray[placedCoordinates[0], 
                                         placedCoordinates[1]])
                    {
                        noValidSpaceNeg = true;
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

        // Search sequence in the horizontal axis
        public bool SearchWinSeqHoriz(int[] placedCoordinates)
        {
            checkCoordinates = placedCoordinates;

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 0;

            // Check spaces at a distance fit for a sequence with 
            // the placedPiece
            for (distance = 1; distance < 4; distance++)
            {
                // Reset checkCoordinates for operation with distance 
                checkCoordinates = placedCoordinates;
                
                if (noValidSpacePos == false)
                {
                    // Search in the 'positive X' field
                    checkCoordinates[0] = checkCoordinates[0] + distance;

                    // Is the checked position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkCoordinates[0] >= board.totColumns ||
                        board.boardArray[checkCoordinates[0], 
                                         checkCoordinates[1]] != 
                        board.boardArray[placedCoordinates[0], 
                                         placedCoordinates[1]])
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }

                // Reset checkCoordinates for operation with distance 
                checkCoordinates = placedCoordinates;
                
                if (noValidSpaceNeg == false)
                {
                    // Search in the 'negative X' field
                    checkCoordinates[0] = checkCoordinates[0] - distance;

                    // Is the checked position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkCoordinates[0] < 0 ||
                        board.boardArray[checkCoordinates[0], 
                                         checkCoordinates[1]] != 
                        board.boardArray[placedCoordinates[0], 
                                         placedCoordinates[1]])
                    {
                        noValidSpaceNeg = true;
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

        // Search sequence in the vertical axis
        public bool SearchWinSeqVert(int[] placedCoordinates)
        {
            checkCoordinates = placedCoordinates;

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 0;

            // Check spaces at a distance fit for a sequence with 
            // the placedPiece
            for (distance = 1; distance < 4; distance++)
            {
                // Reset checkCoordinates for operation with distance 
                checkCoordinates = placedCoordinates;
                
                if (noValidSpacePos == false)
                {
                    // Search in the 'positive Y' field
                    checkCoordinates[1] = checkCoordinates[1] + distance;

                    // Is the checked position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkCoordinates[1] >= board.totRows ||
                        board.boardArray[checkCoordinates[0], 
                                         checkCoordinates[1]] != 
                        board.boardArray[placedCoordinates[0], 
                                         placedCoordinates[1]])
                    {
                        noValidSpacePos = true;
                    }
                    // If the position is valid and of the wanted type
                    else
                    {
                        sequenceCount++;
                    }
                }

                // Reset checkCoordinates for operation with distance 
                checkCoordinates = placedCoordinates;
                
                if (noValidSpaceNeg == false)
                {
                    // Search in the 'negative Y' field
                    checkCoordinates[0] = checkCoordinates[1] - distance;

                    // Is the checked position outside the board or of a type 
                    // different of the placedPiece?
                    if (checkCoordinates[1] < 0 ||
                        board.boardArray[checkCoordinates[0], 
                                         checkCoordinates[1]] != 
                        board.boardArray[placedCoordinates[0], 
                                         placedCoordinates[1]])
                    {
                        noValidSpaceNeg = true;
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