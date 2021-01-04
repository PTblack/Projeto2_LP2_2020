using CoreGameEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project2_LP2_2020
{
    class Quitter : Component
    {
        private KeyObserver keyObserver;

        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
        }

        public override void Update()
        {
            foreach (ConsoleKey key in keyObserver.GetCurrentKeys())
            {
                if (key == ConsoleKey.Escape)
                {
                    Console.WriteLine(" Bye :(");
                    ParentScene.Terminate();
                }
            }
        }
    }
}
