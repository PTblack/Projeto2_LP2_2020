using Project2_LP2_2020;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using CoreGameEngine;

namespace Project2_LP2_2020
{
    public class UIComponent : Component
    {
        private Color color;
        private Color lastColor;
        private KeyObserver keyObserver;

        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
            color = Color.Yellow;
            lastColor = Color.None;
        }
        public override void Update()
        {
            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                switch (key)
                {
                    case ConsoleKey.H:
                        if(ParentScene.paused) ParentScene.paused = false;
                        else
                        {
                            ParentScene.paused = true;
                            UI.Help();
                        }                       
                        break;
                    case ConsoleKey.Q:
                        break;
                }
            }

            if (color == lastColor)
            {
                if (lastColor == Color.Yellow) color = Color.Red;
                else color = Color.Yellow;
            }
            lastColor = color;
        }
    }
}
