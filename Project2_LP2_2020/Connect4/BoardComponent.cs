using CoreGameEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project2_LP2_2020
{
    public class BoardComponent : Component
    {
        private BoardManager board;
        private KeyObserver keyObserver;
        private Color color;
        private Color lastColor;
        private GameStage gameStage;

        public override void Start()
        {
            board = new BoardManager();
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            color = Color.Yellow;
            lastColor = Color.None;
        }

        public override void Update()
        {
            // Coordinates for the placed piece 
            // [0] = column (x) / [1] = row (y)
            int[] pieceCoords = { 1 ,1 };

            // Print game board
           // Console.WriteLine(board.GetBoardString());

            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                switch (key)
                {
                    case ConsoleKey.D1:
                        pieceCoords[0] = 1;
                        break;
                    case ConsoleKey.D2:
                        pieceCoords[0] = 2;
                        break;
                    case ConsoleKey.D3:
                        pieceCoords[0] = 3;
                        break;
                    case ConsoleKey.D4:
                        pieceCoords[0] = 4;
                        break;
                    case ConsoleKey.D5:
                        pieceCoords[0] = 5;
                        break;
                    case ConsoleKey.D6:
                        pieceCoords[0] = 6;
                        break;
                    case ConsoleKey.D7:
                        pieceCoords[0] = 7;
                        break;
                    default:
                        break;
                } 
            }

            // "Is it possible to add a piece of color 'color' in the 
            // column 'column'?"
            if (board.TryAddingPiece(pieceCoords[0], color))
            {
                // Add a piece of color 'color' in the column 'column', on 
                // the lowest free row
                pieceCoords[1] = board.AddPiece(pieceCoords[0], color);
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
