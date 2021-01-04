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
    /// colors.
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
        public ConsolePixel(char shape,
            ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            this.Shape = shape;
            this.ForegroundColor = foregroundColor;
            this.BackgroundColor = backgroundColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Shape"></param>
        /// <param name="ForegroundColor"></param>
        public ConsolePixel(char shape, ConsoleColor foregroundColor)
        {
            this.Shape = shape;
            this.ForegroundColor = foregroundColor;
            BackgroundColor = Console.BackgroundColor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Shape"></param>
        public ConsolePixel(char shape)
        {
            this.Shape = shape;
            ForegroundColor = Console.ForegroundColor;
            BackgroundColor = Console.BackgroundColor;
        }
    }
}
