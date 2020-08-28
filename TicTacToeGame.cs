using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class TicTacToeGame
    {   
        // METHODS
        public static void Run()
        {
            Board board = new Board();
            Player currentPlayer = CreatePlayer("Player 1", "X", true);
            Player idlePlayer = CreatePlayer("Player 2", "O", false);
            TicTacToeGame.PlayerList = new List<Player> {currentPlayer, idlePlayer};
            winnerExists = false;
            // Player currentPlayer = player1;
            // Player idlePlayer = player2;

            DisplayText("Welcome to Tic Tac Toe!\n");
            DisplayText("Here's the current board:");
            board.DisplayBoard();


            while (winnerExists == false)
            {
                System.Console.WriteLine($"Beginning turn of {currentPlayer.Name} with {currentPlayer.Marker}");
                BeginTurnOf(TicTacToeGame.PlayerList[0], TicTacToeGame.PlayerList[1], board);
                System.Console.WriteLine("\n");                
                System.Console.WriteLine($"Current player is now {TicTacToeGame.PlayerList[0].Name}");
                System.Console.WriteLine($"Idle player is now {TicTacToeGame.PlayerList[1].Name}");
            }

            System.Console.WriteLine("Ending...");
        }

        private static void BeginTurnOf(Player currentPlayer, Player idlePlayer, Board board)
        {
            // DISPLAY
            DisplayText($"{currentPlayer.Name} enter a coord x,y to place your {currentPlayer.Marker} or enter 'q' to give up: ");
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
            
            bool moveIsAccepted = board.AddToBoard(Xcoordinate, Ycoordinate, currentPlayer);
            if (moveIsAccepted)
            {
                // CHECK IF WINNING MOVE
                if(board.CheckForWinner())
                {
                    System.Console.WriteLine("Move accepted, well done you've won the game!");
                    board.DisplayBoard();
                    winnerExists = true;
                    return;
                }
                System.Console.WriteLine("Move accepted, here's the current board:");
                board.DisplayBoard();
                // SWITCH PLAYER TURN
                System.Console.WriteLine("Switching turns\n");
                SwitchTurns(currentPlayer, idlePlayer);
            }
            else
            {
                System.Console.WriteLine("Oh no, a piece is already at this place! Try again...2");
            }
        }

        private static void SwitchTurns(Player currentPlayer, Player idlePlayer)
        {
            TicTacToeGame.PlayerList[0] = idlePlayer;
            TicTacToeGame.PlayerList[1] = currentPlayer;
            
            System.Console.WriteLine($"Current player is now {TicTacToeGame.PlayerList[0].Name} should now be player 2");
            System.Console.WriteLine($"Idle player is now {TicTacToeGame.PlayerList[1].Name} should be player 1");
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

        // PROPERTIES
        private static bool winnerExists;
        private static List<Player> PlayerList;

    }
}