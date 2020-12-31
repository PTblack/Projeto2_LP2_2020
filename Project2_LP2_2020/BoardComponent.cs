using Project2_LP2_2020.GameEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project2_LP2_2020
{
    public class BoardComponent : Component
    {
        private BoardManager board;
        private Color color;
        private Color lastColor;
        private GameStage gameStage;
        private PlayerInput Player_input;

        // Coordinates for the placed piece 
        // [0] = column (x) / [1] = row (y)
        private int[] pieceCoords;

        // Board column chosen (input) by the user
        private int column;

        public override void Start()
        {
            board = new BoardManager();
            color = Color.Yellow;
            lastColor = Color.None;
        }

        public override void Update()
        {
            // Write Board

            switch (Player_input)
            {
                case Player_input.1:
                    column = 1;
                    break;
                case Player_input.2:
                    column = 2;
                    break;
                case Player_input.3:
                    column = 3;
                    break;
                case Player_input.4:
                    column = 4;
                    break;
                case Player_input.5:
                    column = 5;
                    break;
                case Player_input.6:
                    column = 6;
                    break;
                case Player_input.7:
                    column = 7;
                    break;
                default:
                    break;
            }

            pieceCoords[0] = column;

            // "Is it possible to add a piece of color 'color' in the 
            // column 'column'?"
            if (board.TryAddingPiece(column, color))
            {
                // Add a piece of color 'color' in the column 'column', on 
                // the lowest free row
                pieceCoords[1] = board.AddPiece(column, color);
            }

            // "Did the placed piece created any winning sequence(s)"
            // Then print 'victory message' according to the placed 
            // piece's color
            if (board.CheckWin(pieceCoords))
            {
                if(color == Color.Yellow)
                    //Yellow player won
                    gameStage = GameStage.Yellow;

                if (color == Color.Red)
                    //Red player won
                    gameStage = GameStage.Red;

                Console.WriteLine(board.AnnounceWinner(gameStage));
                
                // THE MATCH MUST BE ENDED HERE
            }

            else
            {
                // "Is the board full?"
                // Then announce that its a draw
                if(board.CheckFull())
                {
                    gameStage = GameStage.Draw;
                    Console.WriteLine(board.AnnounceWinner(gameStage));
                }
            }

            // Change the color to reflect the change of turn in the game
            if (color == lastColor)
            {
                if (lastColor == Color.Yellow) color = Color.Red;
                else color = Color.Yellow;
            }
            lastColor = color;
        }
    }
}
