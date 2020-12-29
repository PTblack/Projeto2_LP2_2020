using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Project2_LP2_2020
{
    public class Board
    {
        // X axis of the board
        public readonly int totColumns;
        
        // Y axis of the board
        public readonly int totRows;
        
        // Array bi-dimensional de chars
        public Color [,] boardArray;

        public Board()
        {
            // Board dimensions. (totColumns = X, totRows = Y)
            totRows = 6;
            totColumns = 7;
            // Sets the dimensions of the bi-dimensional array 'boardArray' 
            // to the dimensions of the board
            boardArray = new Color[totColumns, totRows];

            CreateEmptyBoard();
        }

        /// <summary>
        /// Fills the board array with empty values. 
        /// (Column by column, bottom up)
        /// </summary>
        private void CreateEmptyBoard()
        {
            for (int col = 0; col < totColumns; col++)
            {
                for (int row = 0; row < totRows; row++)
                {
                    boardArray[col, row] = Color.None;
                }
            }
        }

        public override string ToString()
        {
            string boardString = "";
           
            for (int ro = totRows; ro > 0; ro--)
            {
                Console.ForegroundColor = ConsoleColor.White;
                boardString += "| ";
                for (int col= 0; col< totColumns; col++)
                {
                    Color color = boardArray[col, ro];
                    switch (color)
                    {
                        case Color.None:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            boardString += ".";
                            break;
                        case Color.Red:
                            Console.ForegroundColor = ConsoleColor.Red;
                            boardString += "R"; ;
                            break;
                        case Color.Yellow:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            boardString += "Y";
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    boardString += " | ";
                }

                boardString += "\n";
            }

            Console.ForegroundColor = ConsoleColor.White;
            boardString += "_____________________________\n";

            return boardString;
        }
    }
}