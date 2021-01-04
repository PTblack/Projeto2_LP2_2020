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
        private ConsolePixel defaultPixel, redPlayerPixel, yellowPlayerPixel;
        private Dictionary<Vector2, ConsolePixel> playersPixels;

        public override IEnumerable<KeyValuePair<Vector2, ConsolePixel>> 
            Pixels => playersPixels;

        public override void Start()
        {
            board = new BoardManager();
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            color = Color.Yellow;
            animation = false;

            playersPixels = new Dictionary<Vector2, ConsolePixel>();

            defaultPixel = new ConsolePixel(
               '.', ConsoleColor.White, ConsoleColor.DarkGray);

            redPlayerPixel = new ConsolePixel(
               'R', ConsoleColor.White, ConsoleColor.DarkRed);
            yellowPlayerPixel = new ConsolePixel(
              'Y', ConsoleColor.White, ConsoleColor.DarkYellow);

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    playersPixels[new Vector2(x, y)] = defaultPixel;
                }
            }
        }

        public override void Update()
        {
            animation = !animation;
            // Coordinates for the placed piece 
            // [0] = column (x) / [1] = row (y)
            int[] pieceCoords = {0,0};
            if (!ParentScene.paused)
            {
                // Print game board
                UI.ColumnOptions(color, ParentScene, animation);
                foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
                {
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            pieceCoords[0] = 1;
                            keyPressed = true;
                            break;
                        case ConsoleKey.D2:
                            pieceCoords[0] = 2;
                            keyPressed = true;
                            break;
                        case ConsoleKey.D3:
                            pieceCoords[0] = 3;
                            keyPressed = true;
                            break;
                        case ConsoleKey.D4:
                            pieceCoords[0] = 4;
                            keyPressed = true;
                            break;
                        case ConsoleKey.D5:
                            pieceCoords[0] = 5;
                            keyPressed = true;
                            break;
                        case ConsoleKey.D6:
                            pieceCoords[0] = 6;
                            keyPressed = true;
                            break;
                        case ConsoleKey.D7:
                            pieceCoords[0] = 7;
                            keyPressed = true;
                            break;
                    }
                }
                if (keyPressed)
                {
                    // "Is it possible to add a piece of color 'color' in the 
                    // column 'column'?"
                    if (board.TryAddingPiece(pieceCoords[0]))
                    {
                        // Add a piece of color 'color' in the column 'column', on 
                        // the lowest free row
                        pieceCoords[1] = board.AddPiece(pieceCoords[0], color);

                        if (color == Color.Red) playersPixels[new Vector2(pieceCoords[0], pieceCoords[1])] = redPlayerPixel;
                        else playersPixels[new Vector2(pieceCoords[0], pieceCoords[1])] = yellowPlayerPixel;
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

                        ParentScene.Terminate();
                        Console.Clear();

                        Console.WriteLine(board.AnnounceWinner(gameStage));
                    }
                }
                keyPressed = false;

                // "Is the board full?"
                // Then announce that its a draw
                if (board.CheckFull())
                {
                    gameStage = GameStage.Draw;
                    ParentScene.Terminate();
                    Console.Clear();
                    Console.WriteLine(board.AnnounceWinner(gameStage));
                    
                }
            }
        }

        private void ChangePlayer()
        {
            if (color == Color.Yellow) color = Color.Red;

            else if (color == Color.Red) color = Color.Yellow;
        }
    }
}
