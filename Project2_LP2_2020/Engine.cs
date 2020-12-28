using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;

namespace Project2_LP2_2020
{
    public class Engine
    {
        private bool running;
        private BlockingCollection<ConsoleKey> input;

        public Engine()
        {
            input = new BlockingCollection<ConsoleKey>();
        }
        private void GameLoop()
        {
            int msPerFrame = 16;
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

                ProcessInput();

                while( lag >= msPerFrame)
                {
                    // Update the game time until it's the same as real time
                    Update()
                    lag -= msPerFrame;
                }
                Render();
            }
        }

        private void ProcessInput()
        {

        }

        private void ReadKeys()
        {
            ConsoleKey ck;
            
            do
            {
                ck = Console.ReadKey(true).Key; // (true) so it doesn't print on the screen
                input.Add();
            } while(ck != ConsoleKey.Escape);


        }
    }
}