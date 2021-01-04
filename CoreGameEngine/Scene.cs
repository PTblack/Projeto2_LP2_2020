/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */
using System;
using System.Threading;
using System.Collections.Generic;
using System.Globalization;

namespace CoreGameEngine
{
    /// <summary>
    /// This class represents a game scene.
    /// </summary>
    public class Scene
    {
        // Scene dimensions
        private readonly int xdim;
        private readonly int ydim;


        /// <summary>
        /// Gets Input handler for this scene.
        /// </summary>
        public InputHandler InputHandler { get; }

        // Collision handler for this scene
        private readonly CollisionHandler collisionHandler;

        // Game objects in this scene
        private readonly Dictionary<string, GameObject> gameObjects;

        // Renderer for this scene
        private readonly ConsoleRenderer renderer;

        // Is the scene terminated?
        private bool terminate;

        /// <summary>
        /// Create a new scene.
        /// </summary>
        /// <param name="xdim"></param>
        /// <param name="ydim"></param>
        /// <param name="inputHandler"></param>
        /// <param name="renderer"></param>
        /// <param name="collisionHandler"></param>
        public Scene(
            int xdim,
            int ydim,
            InputHandler inputHandler,
            ConsoleRenderer renderer,
            CollisionHandler collisionHandler)
        {
            this.xdim = xdim;
            this.ydim = ydim;
            this.InputHandler = inputHandler;
            this.renderer = renderer;
            this.collisionHandler = collisionHandler;
            terminate = false;
            gameObjects = new Dictionary<string, GameObject>();
        }

        /// <summary>
        /// Add a game object to this scene.
        /// </summary>
        /// <param name="gameObject"></param>
        public void AddGameObject(GameObject gameObject)
        {
            gameObject.ParentScene = this;
            gameObjects.Add(gameObject.Name, gameObject);
        }

        /// <summary>
        /// Find a game object by name in this scene.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>GameObject.</returns>
        public GameObject FindGameObjectByName(string name)
        {
            return gameObjects[name];
        }

        /// <summary>
        /// Terminate scene.
        /// </summary>
        public void Terminate()
        {
            terminate = true;
        }

        /// <summary>
        /// Game loop
        /// </summary>
        /// <param name="msFramesPerSecond"></param>
        public void GameLoop(int msFramesPerSecond)
        {
            // Initialize all game objects
            foreach (GameObject gameObject in gameObjects.Values)
            {
                gameObject.Start();
            }

            // Initialize renderer
            renderer?.Start();

            // Start reading input
            InputHandler.StartReadingInput();

            // Perform the game loop until the scene is terminated
            while (!terminate)
            {
                // Time to wait until next frame
                int timeToWait;

                // Get real time in ticks (10000 ticks = 1 milisecond)
                long start = DateTime.Now.Ticks;

                // Update game objects
                foreach (GameObject gameObject in gameObjects.Values)
                {
                    gameObject.Update();
                }

                // Update collision information
                collisionHandler.Update(gameObjects.Values);

                // Render current frame
                renderer?.Render(gameObjects.Values);

                // Time to wait until next frame
                timeToWait = (int)((start / TimeSpan.TicksPerMillisecond)
                    + msFramesPerSecond
                    - (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond));

                // If this time is negative, we cheat by making it zero
                // Note this should be handled with a more robust game loop
                // and not like this
                timeToWait = timeToWait > 0 ? timeToWait : 0;

                // Wait until next frame
                Thread.Sleep(timeToWait);
            }

            // Stop reading input
            InputHandler.StopReadingInput();

            // Teardown the game objects in this scene
            foreach (GameObject gameObject in gameObjects.Values)
            {
                gameObject.Finish();
            }

            // Teardown renderer
            renderer?.Finish();
        }
    }
}
