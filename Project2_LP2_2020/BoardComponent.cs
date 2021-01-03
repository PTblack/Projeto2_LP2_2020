using CoreGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_LP2_2020
{
    public class BoardComponent : RenderableComponent
    {
        private BoardManager board;
        private KeyObserver keyObserver;
        private Color color;

        private GameStage gameStage;
        private bool animation, keyPressed;
        ConsolePixel RedPlayerPixel, YellowPlayerPixel;
        Dictionary<Vector2, ConsolePixel> playersPixels;

        public override IEnumerable<KeyValuePair<Vector2, ConsolePixel>> Pixels
        {
            get => playersPixels;
        }

        public override void Start()
        {
            board = new BoardManager();
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            // Yellow plays first
            color = Color.Yellow;
            animation = false;

            playersPixels = new Dictionary<Vector2, ConsolePixel>();

            RedPlayerPixel = new ConsolePixel(
                'R', ConsoleColor.Red, ConsoleColor.DarkCyan);
            YellowPlayerPixel = new ConsolePixel(
                'Y', ConsoleColor.Yellow, ConsoleColor.DarkCyan);
        }

        public override void Update()
        {
            animation = !animation;

            // Default coordinates for the placed piece 
            // [0] = column (x) / [1] = row (y)
            int[] pieceCoords = {0, 0};

            // Print game board
            UI.ColumnOptions(color, ParentScene, animation);

            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                // Convert player's input to the specificied boardColumn
                // accounting for the array's [0, 0] space
                switch (key)
                {
                    case ConsoleKey.D1:
                        pieceCoords[0] = 0;
                        keyPressed = true;
                        break;
                    case ConsoleKey.D2:
                        pieceCoords[0] = 1;
                        keyPressed = true;
                        break;
                    case ConsoleKey.D3:
                        pieceCoords[0] = 2;
                        keyPressed = true;
                        break;
                    case ConsoleKey.D4:
                        pieceCoords[0] = 3;
                        keyPressed = true;
                        break;
                    case ConsoleKey.D5:
                        pieceCoords[0] = 4;
                        keyPressed = true;
                        break;
                    case ConsoleKey.D6:
                        pieceCoords[0] = 5;
                        keyPressed = true;
                        break;
                    case ConsoleKey.D7:
                        pieceCoords[0] = 6;
                        keyPressed = true;
                        break;
                }
            }
            if (keyPressed)
            {
                // "Is it possible to add a piece in the chosen column?"
                if (board.TryAddingPiece(pieceCoords[0]))
                {
                    // Add a piece of color 'color' in the column 'column', on 
                    // the lowest free row, returning its 'y' coordinate
                    pieceCoords[1] = board.AddPiece(pieceCoords[0], color);

                    // Change color of pixel to paint placed piece with the 
                    // right color
                    if (color == Color.Red)
                    {
                        playersPixels[
                            new Vector2(pieceCoords[0], pieceCoords[1])] = 
                            RedPlayerPixel;
                    }
                    else if (color == Color.Yellow)
                    {
                        playersPixels[
                            new Vector2(pieceCoords[0], pieceCoords[1])] = 
                            YellowPlayerPixel;
                    }
                    
                    ChangePlayer();
                }

                // "Did the placed piece created any winning sequence(s)"
                // Then print 'victory message' according to the placed 
                // piece's color
                if (board.CheckWin(pieceCoords))
                {
                    if (color == Color.Yellow)
                        //Yellow player won
                        gameStage = GameStage.Yellow;

                    if (color == Color.Red)
                        //Red player won
                        gameStage = GameStage.Red;

                    Console.WriteLine(board.AnnounceWinner(gameStage));

                    // THE MATCH MUST BE ENDED HERE
                }
            }
            keyPressed = false;

            // "Is the board full?"
            // Then announce that its a draw
            if(board.CheckFull())
            {
                Console.WriteLine(board.AnnounceWinner(GameStage.Draw));
            }
        }

        private void ChangePlayer()
        {
            if (color == Color.Yellow) color = Color.Red;
            else if (color == Color.Red) color = Color.Yellow;
        }
    }
}
