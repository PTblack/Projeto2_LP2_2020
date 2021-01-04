/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 *
 * Author: Nuno Fachada
 * */

using System;

namespace CoreGameEngine
{

    /// <summary>
    /// Represents a console pixel with Shape (char), foreground and background
    /// colors
    /// </summary>
    public struct ConsolePixel
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly char Shape;
        /// <summary>
        /// 
        /// </summary>
        public readonly ConsoleColor ForegroundColor;
        /// <summary>
        /// 
        /// </summary>
        public readonly ConsoleColor BackgroundColor;


        /// <summary>
        /// Gets a value indicating whether this is pixel renderable.
        /// </summary>
        public bool IsRenderable
        {
            get
            {
                // The pixel is renderable if any of its fields is not the
                // default to the specific type
                return !Shape.Equals(default(char))
                    && !ForegroundColor.Equals(default(ConsoleColor))
                    && !BackgroundColor.Equals(default(ConsoleColor));
            }
        }


        /// <summary>
        /// Below there are several constructors for building a console pixel
        /// </summary>
        /// <param name="Shape"></param>
        /// <param name="ForegroundColor"></param>
        /// <param name="BackgroundColor"></param>
        public ConsolePixel(char Shape,
            ConsoleColor ForegroundColor, ConsoleColor BackgroundColor)
        {
            this.Shape = Shape;
            this.ForegroundColor = ForegroundColor;
            this.BackgroundColor = BackgroundColor;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Shape"></param>
        /// <param name="ForegroundColor"></param>
        public ConsolePixel(char Shape, ConsoleColor ForegroundColor)
        {
            this.Shape = Shape;
            this.ForegroundColor = ForegroundColor;
            BackgroundColor = Console.BackgroundColor;
        }

        public ConsolePixel(char Shape)
        {
            this.Shape = Shape;
            ForegroundColor = Console.ForegroundColor;
            BackgroundColor = Console.BackgroundColor;
        }
    }
}
