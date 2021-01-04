using System;
using System.Collections.Generic;
using CoreGameEngine;

namespace Project2_LP2_2020
{
    class Program
    {// World dimensions
        int xdim = 9, ydim = 8;

        // Frame duration in miliseconds
        int frameLength = 20;

        // The (only) game scene
        private Scene gameScene;

        // Program starts here
        public static void Main(string[] args)
        {
            // Create a new small game and run it
            Program Connect4 = new Program();
            //show Menu
            UI.Welcome();
            UI.Options();
            //run game
            Connect4.Run();
        }

        private Program()
        {
            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Escape };
            gameScene = new Scene(xdim, ydim,
                new InputHandler(quitKeys),
                new ConsoleRenderer(xdim, ydim, new ConsolePixel(' ')),
                new CollisionHandler(xdim, ydim));

            // Create quitter object
            GameObject quitter = new GameObject("Quitter");
            KeyObserver quitSceneKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.Escape });
            quitter.AddComponent(quitSceneKeyListener);
            quitter.AddComponent(new Quitter());
            gameScene.AddGameObject(quitter);

            // Create board object         
            GameObject board = new GameObject("Board");
            KeyObserver boardKeyListener = new KeyObserver(new ConsoleKey[] {
                ConsoleKey.D1,
                ConsoleKey.D2,
                ConsoleKey.D3,
                ConsoleKey.D4,
                ConsoleKey.D5,
                ConsoleKey.D6,
                ConsoleKey.D7});
            board.AddComponent(boardKeyListener);
            board.AddComponent(new BoardComponent());
            board.AddComponent(new Position(1f,0f,0f));
            gameScene.AddGameObject(board);

            // Create walls
            GameObject walls = new GameObject("Walls");
            ConsolePixel wallPixel = new ConsolePixel(
                '*', ConsoleColor.White, ConsoleColor.DarkCyan);
            Dictionary<Vector2, ConsolePixel> wallPixels =
                new Dictionary<Vector2, ConsolePixel>();
            for (int x = 0; x < 9; x++)
                wallPixels[new Vector2(x, 7 - 1)] = wallPixel;
            for (int y = 0; y < 7; y++)
                wallPixels[new Vector2(0, y)] = wallPixel;
            for (int y = 0; y < 7; y++)
                wallPixels[new Vector2(9 - 1, y)] = wallPixel;
            walls.AddComponent(new ConsoleSprite(wallPixels));
            walls.AddComponent(new Position(0, 0, 1));
            gameScene.AddGameObject(walls);
        }

        private void Run()
        {
            // Start game loop
            gameScene.GameLoop(frameLength);
        }
    }
}


