/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreGameEngine
{
    /// <summary>
    /// This component is an key observer.
    /// </summary>
    public class KeyObserver : Component, IObserver<ConsoleKey>
    {
        private readonly IEnumerable<ConsoleKey> keysToObserve;
        private readonly Queue<ConsoleKey> observedKeys;
        private readonly object queueLock;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="keysToObserve"></param>
        public KeyObserver(IEnumerable<ConsoleKey> keysToObserve)
        {
            this.keysToObserve = keysToObserve;
            observedKeys = new Queue<ConsoleKey>();
            queueLock = new object();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Start()
        {
            ParentScene.InputHandler.RegisterObserver(keysToObserve, this);
        }

        /// <summary>
        /// This method will be called by the subject when an observed key is
        /// pressed. 
        /// </summary>
        /// <param name="notification"></param>
        public void Notify(ConsoleKey notification)
        {
            lock (queueLock)
            {
                observedKeys.Enqueue(notification);
            }
        }

        /// <summary>
        /// Return the currently observed keys.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ConsoleKey> GetCurrentKeys()
        {
            IEnumerable<ConsoleKey> currentKeys;
            lock (queueLock)
            {
                currentKeys = observedKeys.ToArray();
                observedKeys.Clear();
            }

            return currentKeys;
        }
    }
}
