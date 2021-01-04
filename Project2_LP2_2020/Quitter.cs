using System;
using System.Collections.Generic;
using System.Text;
using CoreGameEngine;

namespace Project2_LP2_2020
{
    /// <summary>
    /// ola.
    /// </summary>
    public class Quitter : Component
    {
        private KeyObserver keyObserver;

        /// <summary>
        /// Start
        /// </summary>
        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
        }

        /// <summary>
        /// Update
        /// </summary>
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
