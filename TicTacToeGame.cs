using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class TicTacToeGame
    {
        public static void Run()
        {
            Board board = new Board();
            Player player1 = CreatePlayer("Player 1", "X");
            Player player2= CreatePlayer("Player 2", "O");

            DisplayText("Welcome to Tic Tac Toe!\n");
            DisplayText("Here's the current board:");
            board.DisplayBoard();

            // PLAYER TURN 
            // DISPLAY
            DisplayText($"{player1.Name} enter a coord x,y to place your {player1.Marker} or enter 'q' to give up: ");
            // INPUT
            string playerInput = Console.ReadLine();
            // ASSESS
            if (playerInput.ToLower() == "q")
            {
                System.Console.WriteLine("Player quit, gaming ending...");
                return;
            }
            // TODO: DOESN'T ACCOUNT FOR RANDOM INPUTS
            // ACCEPTED
            List<int> coordinates = FormatPlayerInput(playerInput);
            System.Console.WriteLine($"Coordinates size is {coordinates.Count}");
            
            if (coordinates.Count == 0)
            {
                return;
            }

            int Xcoordinate = coordinates[0];
            int Ycoordinate = coordinates[1];
            System.Console.WriteLine($"X coordinate is {Xcoordinate} and Y corrdinate is {Ycoordinate}.");
            board.AddToBoard(Xcoordinate, Ycoordinate, player1);
            board.DisplayBoard();
        }

        private static Board CreateBoard()
        {
            return new Board();
        }

        private static Player CreatePlayer(string name, string marker)
        {
            return new Player(name, marker);
        }

        private static void DisplayText(string text)
        {
            Console.WriteLine(text);
        }

        // private static void AssessInput(string text)
        // {
        //     if (text == "q")
        //     {
        //         System.Console.WriteLine("Player quit, gaming ending...");
        //     }
        // }

        private static List<int> FormatPlayerInput(string playerInput)
        {
            // CONVERT TO STRING ARRAY
            string[] preformattedCoordinate =  playerInput.Split(",");
            // REMOVE WHITESPACE AND CONVERT TO INT
            int xcoordinate = Convert.ToInt32(preformattedCoordinate[0].Trim('\r', '\n'));
            int ycoordinate = Convert.ToInt32(preformattedCoordinate[1].Trim('\r', '\n'));

            if (xcoordinate > 0 && ycoordinate > 0 && xcoordinate < 4 && ycoordinate < 4)
            {
                System.Console.WriteLine("Valid coordinates entered...");
                return new List<int> { 
                    xcoordinate, 
                    xcoordinate
                };
            }
            else 
            {
                System.Console.WriteLine("Invalid coordinates entered...");
                return new List<int>();
            }
        }
    }
}