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
        public readonly InputHandler inputHandler;
        private int frame;
        private bool running;
        private Thread gameThread;
        private ICollection<GameObject> gameObjects;
        private DoubleBuffer2D<char> buffer2D;

        public Scene(InputHandler inputHandler)
        {
            gameObjects = new List<GameObject>();
            buffer2D = new DoubleBuffer2D<char>(totRows, totColumns);
            gameThread = new Thread(GameLoop);
            this.inputHandler = inputHandler;
        }
        
        private void SetupScene()
        {
            GameObject board = new GameObject("Board");
            GameObject ui = new GameObject("UI");
            board.AddComponent(new BoardComponent());
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

                while ( lag >= msPerFrame)
                {
                    // Update the game time until it's the same as real time
                    //Update();
                    lag -= msPerFrame;
                }
                Render();
            }
        }

        private void Render()
        {
            //render do toString do boardComponent que é um gameObject da lista GameObjectes, os UIs.
        }
    }
}