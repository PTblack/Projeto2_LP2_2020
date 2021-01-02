using System;

namespace Project2_LP2_2020
{
    public class UI
    {
        /// <summary>
        /// 'Welcome' message with the general information 
        /// (authors, references and game goal)
        /// </summary>
        public void Welcome()
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
        public void Options()
        {
            Console.WriteLine("\n\t'Q' - Start (or Restart) Match");
            Console.WriteLine("\t'A' - See 'Help' text");
            Console.WriteLine("\t'Z' - Leave Game");         
        }

        /// <summary>
        /// Tells the player to choose one column of the board to place a piece
        /// </summary>
        /// <param name="color">Color identifying the current player</param>
        public void ColumnOptions(Color color)
        {
            Console.WriteLine($"{0} player, it's your turn!\n", color);

            Console.WriteLine("Choose the column for your piece.");
            
            Console.WriteLine(
                "\nInput the number, from 1 to 7, corresponding to the " + 
                "respective column (going from left to right)");
        }

        /// <summary>
        /// 'Help' text with instructions on how to play and how the 
        /// program works
        /// </summary>
        public void Help()
        {
            Console.WriteLine("---CHOOSING A PLAY---\n");

            Console.WriteLine("Each turn, the player of the corresponding " +
            "piece must pick a number equivalent to a column of the board.\n");

            Console.WriteLine("The program will warn the user if the number " +
            "given is invalid, whether if it does not equate to any column " +
            "of the board, or if the specified column is completely full.");
            Console.WriteLine("(it will also issue a warning if the number " +
            "given is not a number at all)");

            Console.WriteLine("\nAfter issuing this warning, it will give " +
            "the player the chance to select a column again");

            Console.WriteLine("---ANNOUNCING THE END OF A MATCH---\n");

            Console.WriteLine("When an match-ending condition is met, a " +
            "message will appear signaling what it was, it can be a:");
            Console.WriteLine("\t1) TIE (all spaces of the board are " +
            "occupied and no winning sequence exists)"); 
            Console.WriteLine("\t2) VICTORY for YELLOW" +
            "(they made a yellow 4-piece sequence)");
            Console.WriteLine("\t3) VICTORY for RED" +
            "(they made a red 4-piece sequence)");
        }
    }
}