using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class TicTacToeGame
    {   
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
            DisplayText(result);
        }

        private static void BeginTurnOf(Player currentPlayer, Player idlePlayer, Board board)
        {
            string playerInput = GetUserInput(currentPlayer);

            if (HasPlayerQuit(playerInput, currentPlayer, idlePlayer)) return;
           
            Coordinates coordinates = ConvertPlayerInputIntoCoordinates(playerInput);

            if (!coordinates.isValid)
            {
                DisplayText("Move not accepted! Try again!");
                return;
            }
            
            if (IsMoveAccepted(coordinates.XCoordinate, coordinates.YCoordinate, board))
            {
                ExecuteMove(board, coordinates, currentPlayer, idlePlayer);
            }
            else
            {
                DisplayText("Oh no, a piece is already at this place! Try again...\n");
            }
        }

        private static void ExecuteMove(Board board, Coordinates coordinates, Player currentPlayer, Player idlePlayer)
        {
            board.AddToBoard(coordinates.XCoordinate, coordinates.YCoordinate, currentPlayer);
            if(board.IsThereWinner())
            {
                DisplayText("Move accepted, well done you've won the game!");
                board.DisplayBoard();
                winnerExists = true;
                return;
            }
            DisplayText("Move accepted, here's the current board:");
            IncreaseTurnCount();
            board.DisplayBoard();
            SwitchTurns(currentPlayer, idlePlayer);
        }

        private static void IncreaseTurnCount()
        {
            turnCount++;
        }

        private static bool IsMoveAccepted(int Xcoordinate, int Ycoordinate, Board board)
        {
            return board.CurrentBoardState[Xcoordinate - 1][Ycoordinate - 1] == "*";
        }

        private static bool HasPlayerQuit(string playerInput, Player currentPlayer, Player idlePlayer)
        {
            if (playerInput.ToLower() == "q")
            {
                DisplayText($"{currentPlayer.Name} quit, gaming ending...");
                winnerExists = true;
                SwitchTurns(currentPlayer, idlePlayer);
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

        private static Coordinates ConvertPlayerInputIntoCoordinates(string playerInput)
        {
            try
            {
                string[] preformattedCoordinate =  playerInput.Split(",");
                int xcoordinate = Convert.ToInt32(preformattedCoordinate[0].Trim('\r', '\n'));
                int ycoordinate = Convert.ToInt32(preformattedCoordinate[1].Trim('\r', '\n'));
                return new Coordinates(xcoordinate, ycoordinate);
            }
            catch(Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
            return new Coordinates(-1, -1);
        }

        private static bool winnerExists;
        private static int turnCount;
        private static List<Player> PlayerList;

    }
}