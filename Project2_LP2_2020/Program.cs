using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using CoreGameEngine;

namespace Project2_LP2_2020
{
    class Program
    {// World dimensions
        int xdim = 9, ydim = 8;

        // Frame duration in miliseconds
        int frameLength = 100;

        // The (only) game scene
        private Scene gameScene;

        // Program starts here
        public static void Main(string[] args)
        {
            // Create a new small game and run it
            Program Connect4 = new Program();
            UI.Welcome();
            UI.Options();
            Connect4.Run();
        }

        private Program()
        {
            // Create scene
            ConsoleKey[] quitKeys = new ConsoleKey[] { ConsoleKey.Escape };
            gameScene = new Scene(xdim, ydim,
                new InputHandler(quitKeys),
                new ConsoleRenderer(xdim, ydim, new ConsolePixel('.')),
                new CollisionHandler(xdim, ydim));

            // Create quitter object
            GameObject quitter = new GameObject("Quitter");
            KeyObserver quitSceneKeyListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.Escape });
            quitter.AddComponent(quitSceneKeyListener);
            quitter.AddComponent(new Quitter());
            gameScene.AddGameObject(quitter);

            // Create Menu object
            GameObject menu = new GameObject("Menu");
            KeyObserver menuListener = new KeyObserver(new ConsoleKey[]
                { ConsoleKey.H, ConsoleKey.Q });
            menu.AddComponent(menuListener);
            menu.AddComponent(new UIComponent());
            gameScene.AddGameObject(menu);

            // Create player object         
            GameObject player = new GameObject("Player");
            KeyObserver playerKeyListener = new KeyObserver(new ConsoleKey[] {
                ConsoleKey.D1,
                ConsoleKey.D2,
                ConsoleKey.D3,
                ConsoleKey.D4,
                ConsoleKey.D5,
                ConsoleKey.D6,
                ConsoleKey.D7});
            player.AddComponent(playerKeyListener);
            player.AddComponent(new BoardComponent());
            player.AddComponent(new Position());
            gameScene.AddGameObject(player);

            // Create walls
            GameObject walls = new GameObject("Walls");
            ConsolePixel wallPixel = new ConsolePixel(
                '#', ConsoleColor.White, ConsoleColor.DarkCyan);
            Dictionary<Vector2, ConsolePixel> wallPixels =
                new Dictionary<Vector2, ConsolePixel>();
            for (int x = 0; x < xdim; x++)
                wallPixels[new Vector2(x, ydim - 1)] = wallPixel;
            for (int y = 0; y < ydim; y++)
                wallPixels[new Vector2(0, y)] = wallPixel;
            for (int y = 0; y < ydim; y++)
                wallPixels[new Vector2(xdim - 1, y)] = wallPixel;
            walls.AddComponent(new ConsoleSprite(wallPixels));
            walls.AddComponent(new Position(0, 0, 1));
            gameScene.AddGameObject(walls);

           /* // Create game object for showing date and time
            GameObject dtGameObj = new GameObject("Time");
            dtGameObj.AddComponent(new Position(xdim / 2 + 1, 0, 10));
            RenderableStringComponent rscDT = new RenderableStringComponent(
                () => DateTime.Now.ToString("F"),
                i => new Vector2(i, 0),
                ConsoleColor.DarkMagenta, ConsoleColor.White);
            dtGameObj.AddComponent(rscDT);
            gameScene.AddGameObject(dtGameObj);*/
        }

        private void Run()
        {
            // Start game loop
            gameScene.GameLoop(frameLength);
        }
    }
}


