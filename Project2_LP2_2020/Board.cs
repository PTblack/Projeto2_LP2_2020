using System;
using System.Collections.Generic;
using System.Text;

namespace Project2_LP2_2020
{
    public class Board
    {
        public readonly int length;
        public readonly int height;
        
        // Array bidimensional de chars
        private char[] boardArray;

        Board()
        {
            length = 7;
            height = 8;
            // Define boardArray como array bidimensional com tamanho 
            // igual a pretendido
            boardArray = new char[length, height];
        }

        /// <summary>
        /// Returns value in position with coordinates equal to the 
        /// parameters given
        /// </summary>
        /// <param name="x">Board Collumn</param>
        /// <param name="y">Board Row</param>
        /// <returns></returns>
        private char GetSpaceStatus(int x, int y)
        {
            return boardArray[x, y];
        }
    }
}
