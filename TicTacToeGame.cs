using System;
namespace Tic_Tac_Toe
{
    public class TicTacToeGame
    {
        public static void Run()
        {
            // Create Board
            // Create Players
            Display("Welcome to Tic Tac Toe!\n");
            Display("Here's the current board:");
        }

        // private static Board CreateBoard()
        // {
        //     return new Board();
        // }

        // private static Player CreatePlayer(string name)
        // {
        //     return new Player(name);
        // }

        private static void Display(string text)
        {
            Console.WriteLine(text);
        }
    }
}