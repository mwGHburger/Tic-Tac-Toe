using System;
namespace Tic_Tac_Toe
{
    public class TicTacToeGame
    {
        public static void Run()
        {
            Board board = new Board();
            // TODO: Create Players
            DisplayText("Welcome to Tic Tac Toe!\n");
            DisplayText("Here's the current board:");
            board.DisplayBoard();
        }

        private static Board CreateBoard()
        {
            return new Board();
        }

        // private static Player CreatePlayer(string name)
        // {
        //     return new Player(name);
        // }

        private static void DisplayText(string text)
        {
            Console.WriteLine(text);
        }
    }
}