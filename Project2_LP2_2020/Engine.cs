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
        private Thread gameThread;
        private Thread inputThread;

        public Engine()
        {
            input = new BlockingCollection<ConsoleKey>();
            inputThread = new Thread(ReadKeys);
            gameThread = new Thread(GameLoop);
        }
        private void GameLoop()
        {
            int msPerFrame = 16;
            int previous = DateTime.Now.Millisecond; // time of the last frame
            int lag = 0;
            Console.Clear();
            running = true;
            inputThread.Start();

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
                    //Update();
                    lag -= msPerFrame;
                }
                //Renderer();
            }
        }

        private void ProcessInput()
        {
            ConsoleKey key;
            if(input.TryTake(out key))
            {
                switch (key)
                {
                    case ConsoleKey.Q:
                        // do something
                        break;
                    case ConsoleKey.A:
                        // do something
                        break;
                    case ConsoleKey.Z:
                        // do something
                        break;
                    // Add more keys
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            }
        }

        private void Finish()
        {
            inputThread.Join();
        }
        private void ReadKeys()
        {
            ConsoleKey ck;
            
            do
            {
                ck = Console.ReadKey(true).Key; // (true) so it doesn't print on the screen
                input.Add(ck);
            } while(ck != ConsoleKey.Escape);
        }
    }
}