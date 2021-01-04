using System;
using System.Collections.Generic;
using System.Text;
using CoreGameEngine;

namespace Project2_LP2_2020
{
    /// <summary>
    /// A component that listens to the specified key to quit the program when
    /// it is pressed.
    /// </summary>
    public class Quitter : Component
    {
        private KeyObserver keyObserver;

        /// <summary>
        /// Starts the keyObserver, to identify when the key is pressed.
        /// </summary>
        public override void Start()
        {
            keyObserver = ParentGameObject.GetComponent<KeyObserver>();
        }

        /// <summary>
        /// Loop that checks if the 'Escape' key is pressed, terminating the
        /// parent scene if so.
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
