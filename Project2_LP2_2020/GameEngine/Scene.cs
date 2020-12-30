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
        private int frame;
        private bool running;
        private Thread gameThread;
        private ICollection<GameObject> gameObjects;
        private DoubleBuffer2D<char> buffer2D;

        public Scene()
        {
            gameObjects = new List<GameObject>();
            buffer2D = new DoubleBuffer2D<char>(totRows, totColumns);
            gameThread = new Thread(GameLoop);
        }
        
        private void SetupScene()
        {
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

            while(running)
            {
                int current = DateTime.Now.Millisecond; // time of the new frame
                int elapsed = current - previous;
                previous = current;

                lag += elapsed; // real time passed

                //ProcessInput();

                while( lag >= msPerFrame)
                {
                    // Update the game time until it's the same as real time
                    //Update();
                    lag -= msPerFrame;
                }
                // Render()
            }
        }

        private void Render()
        {
            
        }
    }
}