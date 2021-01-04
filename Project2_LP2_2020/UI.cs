using CoreGameEngine;
using System;
using System.Runtime.CompilerServices;
using static System.Console;

namespace Project2_LP2_2020
{
    public static class UI
    {
        /// <summary>
        /// 'Welcome' message with the general information 
        /// (authors, references and game goal)
        /// </summary>
        public static void Welcome()
        {
            Console.WriteLine("Welcome to Connect Four!");

            Console.WriteLine("\nImplementation developed by: " +
                "Diogo Henriques, João Dias and Pedro Fernandes");

            Console.WriteLine("With reference from the engine made available " +
                "by Nuno Fachada");

            Console.WriteLine("\nEach color, Yellow (\"Y\") and Red (\"R\") " +
                "corresponds to a player/competitor.");

            Console.WriteLine("\nThe first color to have a sequence of " +
                "four pieces (diagonally, vertically or horizontally) wins " +
                "the game!");
        }

        /// <summary>
        /// Text showing the main game options
        /// </summary>
        public static void Options()
        {
            bool choosing = true;
            while (choosing)
            {
                Console.WriteLine("\n'Q' - Start Match");
                Console.WriteLine("'H' - See 'Help' text");
                Console.WriteLine("'Escape' - Leave Game");
                ConsoleKeyInfo readKey = Console.ReadKey();
                switch (readKey.Key)
                {
                    case ConsoleKey.H:
                        UI.Help();
                        break;
                    case ConsoleKey.Q:
                        choosing = false;
                        break;
                    case ConsoleKey.Escape:
                        break;
                }
            }      
        }

        /// <summary>
        /// Tells the player to choose one column of the board to place a piece
        /// </summary>
        /// <param name="color">Color identifying the current player</param>
        public static void ColumnOptions(Color color, Scene scene, bool animation)
        {
            if (!scene.paused)
            {
                if (color == Color.Red) ForegroundColor = ConsoleColor.Red;
                else ForegroundColor = ConsoleColor.Yellow;
                BackgroundColor = ConsoleColor.Black;

                Console.WriteLine("\n{0} player, it's your turn!    \n", color);

                Console.WriteLine("Choose the column for your piece.");

                Console.WriteLine(
                    "\nInput the number, from 1 to 7, corresponding to the " +
                    "respective column (going from left to right)");

                if (animation) Console.WriteLine("\nWaiting. ");
                else Console.WriteLine("\nWaiting..");
            } 
        }

        /// <summary>
        /// 'Help' text with instructions on how to play and how the 
        /// program works
        /// </summary>
        public static string Help()
        {
            return "\n--CHOOSING A PLAY---\n" +

            "Each turn, the player of the corresponding " +
            "piece must pick a number equivalent to a column of the board.\n" +

            "The program will warn the user if the number " +
            "given is invalid, whether if it does not equate to any column " +
            "of the board, or if the specified column is completely full.\n" +
            "(it will also issue a warning if the number " +
            "given is not a number at all)\n" +

            "\nAfter issuing this warning, it will give " +
            "the player the chance to select a column again\n" +

            "---ANNOUNCING THE END OF A MATCH---\n\n" +

            "When an match-ending condition is met, a " +
            "message will appear signaling what it was, it can be a:\n" +
            "\t1) TIE (all spaces of the board are " +
            "occupied and no winning sequence exists)\n" +
            "\t2) VICTORY for YELLOW" +
            "(they made a yellow 4-piece sequence)\n" +
            "\t3) VICTORY for RED" +
            "(they made a red 4-piece sequence)";
        }
    }
}