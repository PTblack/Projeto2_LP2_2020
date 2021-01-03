using System;

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

        private Board board;

        public BoardSearcher(Board board)
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
        /// Checks if the top row of the board has any free space, indicating 
        /// that the board is not completely full
        /// </summary>
        /// <returns>Bool indicating if the board is full</returns>
        public bool BoardFull()
        {
            bool isFull = true;

            for (int col = 0; col < board.totColumns; col++)
            {
                if (board.boardArray[col, 0] == Color.None)
                    isFull = false;
            }

            return isFull;
        }
        
        /// <summary>
        /// Search for sequences in the positive tangent diagonal
        /// </summary>
        /// <param name="placedCoordinates">The coordinates of the placed 
        /// piece</param>
        /// <returns>Bool indicating if a winning sequence was found</returns>
        public bool SearchWinSeqTanPlus(int[] placedCoordinates)
        {
            int checkX = placedCoordinates[0];
            int checkY = placedCoordinates[1];

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 1;

            // Check spaces at a distance fit for a sequence with 
            // the placedPiece
            for (distance = 1; distance < 4; distance++)
            {
                // Reset checkCoordinates for operation with distance 
                checkX = placedCoordinates[0];
                checkY = placedCoordinates[1];

                if (noValidSpacePos == false)
                {
                    // Search in the 1st Quadrant
                    checkX += distance;
                    checkY -= distance;

                    // "Is the space INSIDE the board?"
                    if (checkX < board.totColumns && checkY >= 0)
                    {
                        // "Is the space of the SAME color as the placedPiece?"
                        if (board.boardArray[checkX, checkY] == 
                            board.boardArray[
                            placedCoordinates[0], placedCoordinates[1]])
                        
                            sequenceCount++;
                        
                        else
                            noValidSpacePos = true;
                    }

                    else
                        noValidSpacePos = true;
                }

                // Reset checkCoordinates for operation with distance 
                checkX = placedCoordinates[0];
                checkY = placedCoordinates[1];

                if (noValidSpaceNeg == false)
                {
                    // Search in the 3rd Quadrant
                    checkX -= distance;
                    checkY += distance;

                    // "Is the space INSIDE the board?"
                    if (checkX >= 0 && checkY < board.totRows)
                    {
                        // "Is the space of the SAME color as the placedPiece?"
                        if (board.boardArray[checkX, checkY] == 
                            board.boardArray[
                            placedCoordinates[0], placedCoordinates[1]])
                        
                            sequenceCount++;
                        
                        else
                            noValidSpaceNeg = true;
                    }

                    else
                        noValidSpaceNeg = true;
                }
            }
            // if the sequence size reached 4 or more, declare a victory
            if (sequenceCount >= 4) return true;
            else return false;
        }

        /// <summary>
        /// Search for sequences in the negative tangent diagonal
        /// </summary>
        /// <param name="placedCoordinates">The coordinates of the placed 
        /// piece</param>
        /// <returns>Bool indicating if a winning sequence was found</returns>
        public bool SearchWinSeqTanNeg(int[] placedCoordinates)
        {
            int checkX = placedCoordinates[0];
            int checkY = placedCoordinates[1];

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 1;

            // Check spaces at a distance fit for a sequence with 
            // the placedPiece
            for (distance = 1; distance < 4; distance++)
            {
                // Reset checkCoordinates for operation with distance 
                checkX = placedCoordinates[0];
                checkY = placedCoordinates[1];

                if (noValidSpacePos == false)
                {
                    // Search in the 2nd Quadrant
                    checkX -= distance;
                    checkY -= distance;

                    // "Is the space INSIDE the board?"
                    if (checkX >= 0 && checkY >= 0)
                    {
                        // "Is the space of the SAME color as the placedPiece?"
                        if (board.boardArray[checkX, checkY] == 
                            board.boardArray[
                            placedCoordinates[0], placedCoordinates[1]])
                        
                            sequenceCount++;
                        
                        else
                            noValidSpacePos = true;
                    }

                    else
                        noValidSpacePos = true;
                }

                // Reset checkCoordinates for operation with distance 
                checkX = placedCoordinates[0];
                checkY = placedCoordinates[1];

                if (noValidSpaceNeg == false)
                {
                    // Search in the 4th Quadrant
                    checkX += distance;
                    checkY += distance;

                    // "Is the space INSIDE the board?"
                    if (checkX < board.totColumns && checkY < board.totRows)
                    {
                        // "Is the space of the SAME color as the placedPiece?"
                        if (board.boardArray[checkX, checkY] == 
                            board.boardArray[
                            placedCoordinates[0], placedCoordinates[1]])
                        
                            sequenceCount++;
                        
                        else
                            noValidSpaceNeg = true;
                    }

                    else
                        noValidSpaceNeg = true;
                }
            }

            // if the sequence size reached 4 or more, declare a victory
            if (sequenceCount >= 4) return true;
            else return false;
        }

        /// <summary>
        /// Search for sequences in the horizontal axis
        /// </summary>
        /// <param name="placedCoordinates">The coordinates of the placed 
        /// piece</param>
        /// <returns>Bool indicating if a winning sequence was found</returns>
        public bool SearchWinSeqHoriz(int[] placedCoordinates)
        {
            int checkX = placedCoordinates[0];
            int checkY = placedCoordinates[1];

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 1;

            // Check spaces at a distance fit for a sequence with 
            // the placedPiece
            for (distance = 1; distance < 4; distance++)
            {
                // Reset checkCoordinates for operation with distance 
                checkX = placedCoordinates[0];
                checkY = placedCoordinates[1];

                if (noValidSpacePos == false)
                {
                    // Search in the 'positive X' field
                    checkX += distance;

                    // "Is the space INSIDE the board?"
                    if (checkX < board.totColumns)
                    {
                        // "Is the space of the SAME color as the placedPiece?"
                        if (board.boardArray[checkX, checkY] == 
                            board.boardArray[
                            placedCoordinates[0], placedCoordinates[1]])
                        
                            sequenceCount++;
                        
                        else
                            noValidSpacePos = true;
                    }

                    else
                        noValidSpacePos = true;
                }

                // Reset checkCoordinates for operation with distance 
                checkX = placedCoordinates[0];
                checkY = placedCoordinates[1];

                if (noValidSpaceNeg == false)
                {
                    // Search in the 'negative X' field
                    checkX -= distance;

                    // "Is the space INSIDE the board?"
                    if (checkX >= 0)
                    {
                        // "Is the space of the SAME color as the placedPiece?"
                        if (board.boardArray[checkX, checkY] == 
                            board.boardArray[
                            placedCoordinates[0], placedCoordinates[1]])
                        
                            sequenceCount++;
                        
                        else
                            noValidSpaceNeg = true;
                    }

                    else
                        noValidSpaceNeg = true;
                }
            }

            // if the sequence size reached 4 or more, declare a victory
            if (sequenceCount >= 4) return true;
            else return false;
        }

        /// <summary>
        /// Search for sequences in the vertical axis
        /// </summary>
        /// <param name="placedCoordinates">The coordinates of the placed 
        /// piece</param>
        /// <returns>Bool indicating if a winning sequence was found</returns>
        public bool SearchWinSeqVert(int[] placedCoordinates)
        {
            int checkX = placedCoordinates[0];
            int checkY = placedCoordinates[1];

            // Variables to check if there are more places to check for sequence
            noValidSpacePos = false;
            noValidSpaceNeg = false;

            // Variable to register size of current sequence
            int sequenceCount = 1;

            // Check spaces at a distance fit for a sequence with 
            // the placedPiece
            for (distance = 1; distance < 4; distance++)
            {
                // Reset checkCoordinates for operation with distance 
                checkX = placedCoordinates[0];
                checkY = placedCoordinates[1];

                if (noValidSpacePos == false)
                {
                    // Search in the 'positive Y' field
                    checkY -= distance;

                    // "Is the space INSIDE the board?"
                    if (checkY >= 0)
                    {
                        // "Is the space of the SAME color as the placedPiece?"
                        if (board.boardArray[checkX, checkY] == 
                            board.boardArray[
                            placedCoordinates[0], placedCoordinates[1]])
                        
                            sequenceCount++;
                        
                        else
                            noValidSpacePos = true;
                    }

                    else
                        noValidSpacePos = true;
                }

                // Reset checkCoordinates for operation with distance 
                checkX = placedCoordinates[0];
                checkY = placedCoordinates[1];

                if (noValidSpaceNeg == false)
                {
                    // Search in the 'negative Y' field
                    checkY += distance;

                    // "Is the space INSIDE the board?"
                    if (checkY < board.totRows)
                    {
                        // "Is the space of the SAME color as the placedPiece?"
                        if (board.boardArray[checkX, checkY] == 
                            board.boardArray[
                            placedCoordinates[0], placedCoordinates[1]])
                        
                            sequenceCount++;
                        
                        else
                            noValidSpaceNeg = true;
                    }

                    else
                        noValidSpaceNeg = true;
                }
            }

            // if the sequence size reached 4 or more, declare a victory
            if (sequenceCount >= 4) return true;
            else return false;
        }
    }
}