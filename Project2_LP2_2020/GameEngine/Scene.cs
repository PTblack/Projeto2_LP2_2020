using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;

namespace Project2_LP2_2020.GameEngine
{
    public class Scene 
    {
        private const int totRows = 6;
        private const int totColumns = 7;
        private const int msPerFrame = 17;
        private KeyObserver keyListener;
        public readonly InputHandler inputHandler;
        private int frame;
        private bool running;
        private Thread gameThread;
        private ICollection<GameObject> gameObjects;
        private DoubleBuffer2D<char> buffer2D;

        public Scene(InputHandler inputHandler)
        {
            gameThread = new Thread(GameLoop);
            this.inputHandler = inputHandler;
            gameObjects = new List<GameObject>();
            buffer2D = new DoubleBuffer2D<char>(totRows, totColumns);
            keyListener = new KeyObserver(new ConsoleKey[] {
                ConsoleKey.D1,
                ConsoleKey.D2,
                ConsoleKey.D3,
                ConsoleKey.D4});
            SetupScene();
            GameLoop();

        }
        
        private void SetupScene()
        {
            GameObject board = new GameObject("Board");
            GameObject ui = new GameObject("UI");
            board.AddComponent(new BoardComponent());
            board.AddComponent(keyListener);
            ui.AddComponent(new UIComponent());
            gameObjects.Add(board);
            gameObjects.Add(ui);
            // Criar gameObjects necessarios
            // componentes dos gameobjects
            // input
            // render
            // Adicionar os gameobjects a lista de gameobjects
        }
        private void GameLoop()
        {
            int previous = DateTime.Now.Millisecond; // time of the last frame
            int lag = 0;
            Console.Clear();
            running = true;

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Start();
            }


            while(running)
            {
                int current = DateTime.Now.Millisecond; // time of the new frame
                int elapsed = current - previous;
                previous = current;

                lag += elapsed; // real time passed

                foreach (GameObject gameObject in gameObjects)
                {
                    gameObject.Update();
                }

                //ProcessInput();
                inputHandler.StartReadingInput();

                while ( lag >= msPerFrame)
                {
                    // Update the game time until it's the same as real time
                    //Update();
                    lag -= msPerFrame;
                }
                Render();
            }
            inputHandler.StopReadingInput();
        }

        private void Render()
        {
            // Swap buffers in the double buffer
            buffer2D.Swap();
            // Set cursor position to top of the console
            Console.SetCursorPosition(0, 0);

            // Render information in the double buffer
            for (int y = 0; y < buffer2D.YDim; y++)
            {
                for (int x = 0; x < buffer2D.XDim; x++)
                {
                    if (buffer2D[x, y] == default) Console.Write(' ');
                    else Console.Write(buffer2D[x, y]);
                }
                Console.WriteLine();
            }

            // Render frame number (just for debugging purposes)
            Console.Write($"Frame: {frame++}\n");

            // Note for this rendering solution:
            // - This approach does not work for colored characters.
            // - It does not consider the z-buffer, so it's not possible to
            //   define when game objects should appear in front or behind
            //   others.
            // - It's very inefficient and will probably not work when there's
            //   too many game objects.
            // See https://github.com/fakenmc/CoreGameEngine/ for possible
            // solutions and ideas.
        }
    }
}