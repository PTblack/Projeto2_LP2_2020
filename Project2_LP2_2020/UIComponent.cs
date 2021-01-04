using Project2_LP2_2020;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CoreGameEngine;
using System.Linq;

namespace Project2_LP2_2020
{
    public class UIComponent : RenderableComponent
    {
        private Color color;
        private ConsoleSprite renderString;
        private KeyObserver keyObserver;
        private Vector2 helpPos;
        private IEnumerable<KeyValuePair<Vector2, ConsolePixel>> uiPixels;

       public override IEnumerable<KeyValuePair<Vector2, ConsolePixel>> Pixels => renderString.Pixels; 

        public override void Start()
        {
            uiPixels = new List<KeyValuePair<Vector2, ConsolePixel>>();
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            color = Color.Yellow;
            helpPos = new Vector2(0,0);
        }
        public override void Update()
        {
            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                switch (key)
                {
                    case ConsoleKey.H:
                        if (ParentScene.paused)
                        {
                            ParentScene.paused = false;
                            break;
                        }
                        else
                        {
                            ParentScene.paused = true;
                            /*help = UI.Help().ToCharArray();
                            Console.WriteLine(help);
                            uiPixels[new Vector2(6, 7)] = new ConsolePixel();*/
                        }
                        break;
                    case ConsoleKey.Q:
                        break;
                }
            }          
          // renderString = new ConsoleSprite(ConvertToChar(str), ConsoleColor.White, ConsoleColor.Red);         
        }
        private char[,] ConvertToChar(string[] str)
        {
            char[,] chr = new char[str.Length,100];

            for (int i = 0; i < str.Length; i++)
            {
                char[] ch =  new char[str[i].Length];

                for (int j = 0; j < str[i].Length; j++)
                {

                    chr[i, j] = ch[j];
                }
            }
            return chr;
        }
    }
}
