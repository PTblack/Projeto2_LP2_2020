using System;
using System.Threading;
using System.Collections.Concurrent;

namespace Project2_LP2_2020.GameEngine
{
    public class KeyReaderComponent : Component
    {
        GameStage gameStage = GameStage.Menus;
        private BlockingCollection<ConsoleKey> input;
        private Thread inputThread;

        public override void Start()
        {
            input = new BlockingCollection<ConsoleKey>();
            inputThread = new Thread(ReadKeys);
            inputThread.Start();
        }

        public override void Update()
        {
            ConsoleKey key;
            if(input.TryTake(out key))
            {
                switch (key)
                {
                    case ConsoleKey.Q:
                        gameStage = GameStage.Ongoing;
                        break;
                    case ConsoleKey.A:
                        // do something
                        break;
                    case ConsoleKey.Z:
                        // do something
                        break;
                    case ConsoleKey.D0:
                        // do something
                        break;
                    case ConsoleKey.D1:
                        // do something
                        break;
                    case ConsoleKey.D2:
                        // do something
                        break;
                    case ConsoleKey.D3:
                        // do something
                        break;
                    case ConsoleKey.D4:
                        // do something
                        break;
                    case ConsoleKey.D5:
                        // do something
                        break;
                    case ConsoleKey.D6:
                        // do something
                        break;
                    case ConsoleKey.D7:
                        // do something
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        break;
                }
            }
        }
        
        public override void Finish()
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