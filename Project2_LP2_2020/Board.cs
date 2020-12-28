using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Project2_LP2_2020
{
    public class Board
    {
        private readonly int row;
        private readonly int column;
        
        // Array bidimensional de chars
        private Color[,] boardArray;

        public Board()
        {
            row = 6;
            column = 7;
            // Define boardArray como array bidimensional com tamanho 
            // igual a pretendido
            boardArray = new Color[row, column];

            CreateEmptyBoard();
        }

        /// <summary>
        /// Fills the board with empty values.
        /// </summary>
        private void CreateEmptyBoard()
        {
            for (int ro = 0; ro < row; ro++)
            {
                for (int col = 0; col < column; col++)
                {
                    boardArray[ro, col] = Color.None;
                }
            }
        }

        /// <summary>
        /// Determines if a token can be added to the top of the given row.
        /// </summary>
        public bool CanAdd(int column)
        {
            if (boardArray[0, column] == Color.None) { return true; }
            else { return false; }
        }

        /// <summary>
        /// Adds the given color to the column given.
        /// </summary>
        public void Add(int column, Color color)
        {
            // If it is full, give up.
            if (!CanAdd(column)) { return; }

            // Starting at the top, look down to see how far down gravity will
            // pull it.
            int currentRow = 0;
            while (currentRow < row - 1 &&
                boardArray[currentRow + 1, column] == Color.None)
            {
                currentRow++;
            }

            // When we either get to the bottom or to another token, we can
            // go ahead and place the current token.
            boardArray[currentRow, column] = color;
        }

        public override string ToString()
        {
            string board = "";
           
            for (int ro = row; ro > 0; ro--)
            {
                Console.ForegroundColor = ConsoleColor.White;
                board += "| ";
                for (int col= 0; col< column; col++)
                {
                    Color color = boardArray[row, column];
                    switch (color)
                    {
                        case Color.None:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            board += ". | ";
                            break;
                        case Color.Red:
                            Console.ForegroundColor = ConsoleColor.Red;
                            board += "R | "; ;
                            break;
                        case Color.Yellow:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            board += "Y | ";
                            break;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                board += "\n";
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            board += "_____________________________\n";

            return board;
        }
    }
}
