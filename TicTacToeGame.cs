using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class TicTacToeGame
    {
        public static void Run()
        {
            Board board = new Board();
            Player player1 = CreatePlayer("Player 1", "X", true);
            Player player2 = CreatePlayer("Player 2", "O", false);

            DisplayText("Welcome to Tic Tac Toe!\n");
            DisplayText("Here's the current board:");
            board.DisplayBoard();

            // return;

            // while (noWinner == true)
            // {
            //     if(player1.Turn == true)
            //     {

            //     }
            //     else
            //     {}
            // }

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
                System.Console.WriteLine("Move not accepted!");
                return;
            }

            // CONTINUE
            int Xcoordinate = coordinates[0];
            int Ycoordinate = coordinates[1];

            System.Console.WriteLine($"Xcoordinate is {Xcoordinate}, Ycoordinate is {Ycoordinate}");
            
            bool moveIsAccepted = board.AddToBoard(Xcoordinate, Ycoordinate, player1);
            if (moveIsAccepted)
            {
                // CHECK IF WINNING MOVE
                if(board.CheckForWinner())
                {
                    System.Console.WriteLine("Move accepted, well done you've won the game!");
                    board.DisplayBoard();
                    return;
                }
                System.Console.WriteLine("Move accepted, here's the current board:");
                board.DisplayBoard();
            }
            else
            {
                System.Console.WriteLine("Oh no, a piece is already at this place! Try again...2");
            }
            
        }

        private static Board CreateBoard()
        {
            return new Board();
        }

        private static Player CreatePlayer(string name, string marker, bool turn)
        {
            return new Player(name, marker, turn);
        }

        private static void DisplayText(string text)
        {
            Console.WriteLine(text);
        }

        private static List<int> FormatPlayerInput(string playerInput)
        {
            // CONVERT TO STRING ARRAY
            string[] preformattedCoordinate =  playerInput.Split(",");
            // REMOVE WHITESPACE AND CONVERT TO INT
            int xcoordinate = Convert.ToInt32(preformattedCoordinate[0].Trim('\r', '\n'));
            int ycoordinate = Convert.ToInt32(preformattedCoordinate[1].Trim('\r', '\n'));

            if (xcoordinate > 0 && ycoordinate > 0 && xcoordinate < 4 && ycoordinate < 4)
            {
                return new List<int> { 
                    xcoordinate, 
                    ycoordinate
                };
            }
            else 
            {
                return new List<int>();
            }
        }

    }
}