using System;

namespace Project2_LP2_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            //---------------------------
            // Give default values for variables here (outside gameloop)
            GameStage gameStage = GameStage.Menus;
            string optionChoice = "";
            bool optionValid = false;
            //---------------------------

            UI.Welcome();

            while(gameStage == GameStage.Menus)
            {
                // Loop for player(s) to select 'valid' option 
                // (Could be a called method from another class)
                while (!optionValid)
                {
                    UI.Options();
                    optionChoice = Console.ReadLine();
                    if (optionChoice != "Q" && 
                        optionChoice != "A" && 
                        optionChoice != "Z")
                        {
                            Console.WriteLine("Invalid Choice");
                            optionValid = false;
                        }
                    else optionValid = true;
                }

                // Player(s) chose to play a match
                if (optionChoice == "Q")
                {
                    gameStage = GameStage.Ongoing;

                    // MAIN GAMELOOP (while the game is 'Ongoing')
                    while (gameStage == GameStage.Ongoing)
                    {

                    }

                    // If there is a match-ending condition
                    if (gameStage == GameStage.Draw   ||
                        gameStage == GameStage.Yellow ||
                        gameStage == GameStage.Red)
                    {
                        UI.AnnounceWinner(gameStage);
                    }
                    gameStage = GameStage.Menus;
                }

                else if (optionChoice == "A")
                {
                    UI.Help();
                    gameStage = GameStage.Menus;
                }

                else if (optionChoice == "Z")
                {
                    // É este o comando?
                    // Environment.Exit(-1);
                }
            }
        }
    }
}
