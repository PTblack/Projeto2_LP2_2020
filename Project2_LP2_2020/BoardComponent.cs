using Project2_LP2_2020.GameEngine;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project2_LP2_2020
{
    public class BoardComponent : Component
    {
        private BoardManager board;
        private Color color;
        private Color lastColor;
        private GameStage gameStage;
        private PlayerInput Player_input;

        private int[] ola;
        private int column;

        public override void Start()
        {
            board = new BoardManager();
            color = Color.Yellow;
            lastColor = Color.None;
        }

        public override void Update()
        {
            switch (Player_input)
            {
                case Player_input.1:
                    column = 1;
                    break;
                case Player_input.2:
                    column = 2;
                    break;
                case Player_input.3:
                    column = 3;
                    break;
                case Player_input.4:
                    column = 4;
                    break;
                case Player_input.5:
                    column = 5;
                    break;
                case Player_input.6:
                    column = 6;
                    break;
                case Player_input.7:
                    column = 7;
                    break;
                default:
                    break;
            }
            ola[0] = column;

            if (board.TryAddingPiece(column, color))
            {
                ola[1] = board.AddPiece(column, color);
            }

            if(board.CheckDraw())
            {
                gameStage = GameStage.Draw;
                Console.WriteLine(board.AnnounceWinner(gameStage));
            }

            if (board.CheckWin(ola))
            {
                if(color == Color.Yellow)
                    //Yellow player won
                    gameStage = GameStage.Yellow;

                if (color == Color.Red)
                    //Red player won
                    gameStage = GameStage.Red;

                Console.WriteLine(board.AnnounceWinner(gameStage));
            }

            if (color == lastColor)
            {
                if (lastColor == Color.Yellow) color = Color.Red;
                else color = Color.Yellow;
            }
            lastColor = color;
        }
    }
}
