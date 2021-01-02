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
        
        // Color variable for changing player turns
        private Color currentColor;

        private GameStage gameStage;

        public override void Start()
        {
            board = new BoardManager();
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            // Yellow plays first
            currentColor = Color.Yellow;
        }

        public override void Update()
        {
            // Coordinates for the placed piece 
            // [0] = column (x) / [1] = row (y)
            int[] pieceCoords = {1, 1};

            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                // Convert player's input to the specificied boardColumn 
                // accounting for the array's [0, 0] space
                switch (key)
                {
                    case ConsoleKey.D1:
                        pieceCoords[0] = 0;
                        break;
                    case ConsoleKey.D2:
                        pieceCoords[0] = 1;
                        break;
                    case ConsoleKey.D3:
                        pieceCoords[0] = 2;
                        break;
                    case ConsoleKey.D4:
                        pieceCoords[0] = 3;
                        break;
                    case ConsoleKey.D5:
                        pieceCoords[0] = 4;
                        break;
                    case ConsoleKey.D6:
                        pieceCoords[0] = 5;
                        break;
                    case ConsoleKey.D7:
                        pieceCoords[0] = 6;
                        break;
                    default:
                        break;
                } 
            }

            // "Is it possible to add a piece in the column?"
            if (board.TryAddingPiece(pieceCoords[0]))
            {
                // Add a piece of color 'color' in the column 'column', on 
                // the lowest free row
                pieceCoords[1] = board.AddPiece(pieceCoords[0], currentColor);
            }

            // "Did the placed piece created any winning sequence(s)"
            // Then print 'victory message' according to the placed 
            // piece's color
            if (board.CheckWin(pieceCoords))
            {
                if(currentColor == Color.Yellow)
                    //Yellow player won
                    gameStage = GameStage.Yellow;

                if (currentColor == Color.Red)
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
                    Console.WriteLine(board.AnnounceWinner(GameStage.Draw));
            }

            // Change the currentColor to reflect the change of turn in the game
            if (currentColor == Color.Yellow) currentColor = Color.Red;
            else if (currentColor == Color.Red) currentColor = Color.Yellow;
        }
    }
}
