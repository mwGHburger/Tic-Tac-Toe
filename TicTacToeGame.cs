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
            turnCount = 0;

            DisplayText("Welcome to Tic Tac Toe!\nHere's the current board:");
            board.DisplayBoard();

            while (!winnerExists && turnCount < 9)
            {
                BeginTurnOf(TicTacToeGame.PlayerList[0], TicTacToeGame.PlayerList[1], board);
            }

            GenerateResults(winnerExists);
        }

        private static void GenerateResults(bool winnerExists)
        {
            var result = (winnerExists) ?
                $"{TicTacToeGame.PlayerList[0].Name} is the winner!" :
                "It is a tie!";
            System.Console.WriteLine(result);
        }

        private static void BeginTurnOf(Player currentPlayer, Player idlePlayer, Board board)
        {
            string playerInput = GetUserInput(currentPlayer);

            
            if (HasPlayerQuit(playerInput))
            {
                return;
            }
           
            List<int> coordinates = FormatPlayerInput(playerInput);
            if (coordinates.Count == 0)
            {
                System.Console.WriteLine("Move not accepted!");
                return;
            }

            int Xcoordinate = coordinates[0];
            int Ycoordinate = coordinates[1];
            
            bool moveIsAccepted = board.AddToBoard(Xcoordinate, Ycoordinate, currentPlayer);
            if (moveIsAccepted)
            {
                if(board.CheckForWinner())
                {
                    System.Console.WriteLine("Move accepted, well done you've won the game!");
                    board.DisplayBoard();
                    winnerExists = true;
                    return;
                }
                System.Console.WriteLine("Move accepted, here's the current board:");
                turnCount++;
                board.DisplayBoard();
                SwitchTurns(currentPlayer, idlePlayer);
            }
            else
            {
                System.Console.WriteLine("Oh no, a piece is already at this place! Try again...\n");
            }
        }

        private static bool HasPlayerQuit(string playerInput)
        {
            if (playerInput.ToLower() == "q")
            {
                System.Console.WriteLine("Player quit, gaming ending...");
                winnerExists = true;
                return winnerExists;
            }
            return winnerExists;
        }

        private static string GetUserInput(Player player)
        {
            DisplayText($"{player.Name} enter a coord x,y to place your {player.Marker} or enter 'q' to give up: ");
            return Console.ReadLine();
        }

        private static void SwitchTurns(Player currentPlayer, Player idlePlayer)
        {
            TicTacToeGame.PlayerList[0] = idlePlayer;
            TicTacToeGame.PlayerList[1] = currentPlayer;
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
            string[] preformattedCoordinate =  playerInput.Split(",");
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

        private static bool winnerExists;
        private static int turnCount;
        private static List<Player> PlayerList;

    }
}