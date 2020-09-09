using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class Board
    {
        public Board()
        {
            CurrentBoardState = new List<List<string>> {
                new List<string> {"*", "*", "*"},
                new List<string> {"*", "*", "*"},
                new List<string> {"*", "*", "*"}
            };
        }

        public List<List<string>> CurrentBoardState
        {
            get; set;
        }

        public void DisplayBoard()
        {
            Console.WriteLine();
            foreach(List<string> row in this.CurrentBoardState)
            {
                foreach(string space in row)
                {
                    Console.Write($"{space} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void AddToBoard(int xcoordinate, int ycoordinate, Player currentPlayer)
        {
            CurrentBoardState[xcoordinate - 1][ycoordinate - 1] = currentPlayer.Marker;
        }

        public bool IsThereWinner()
        {
            // CHECK ROWS
            if(CurrentBoardState[0][0] == CurrentBoardState[0][1] &&  CurrentBoardState[0][1] == CurrentBoardState[0][2] && CurrentBoardState[0][0] != "*")
            {
                return true;
            }
            else if (CurrentBoardState[1][0] == CurrentBoardState[1][1] &&  CurrentBoardState[1][1] == CurrentBoardState[1][2] && CurrentBoardState[1][1] != "*")
            {
                return true;
            }
            else if (CurrentBoardState[2][0] == CurrentBoardState[2][1] &&  CurrentBoardState[2][1] == CurrentBoardState[2][2] && CurrentBoardState[2][0] != "*")
            {
                return true;
            }
            // CHECK COLUMNS
            else if (CurrentBoardState[0][0] == CurrentBoardState[1][0] && CurrentBoardState[1][0] == CurrentBoardState[2][0] && CurrentBoardState[0][0] != "*")
            {
                return true;
            }
            else if (CurrentBoardState[0][1] == CurrentBoardState[1][1] && CurrentBoardState[1][1] == CurrentBoardState[2][1] && CurrentBoardState[1][1] != "*")
            {
                return true;
            }
            else if (CurrentBoardState[0][2] == CurrentBoardState[1][2] && CurrentBoardState[1][2] == CurrentBoardState[2][2] && CurrentBoardState[1][2] != "*")
            {
                return true;
            }
            // CHECK DIAGONALS
            else if (CurrentBoardState[0][0] == CurrentBoardState[1][1] && CurrentBoardState[1][1] == CurrentBoardState[2][2] && CurrentBoardState[1][1] != "*")
            {
                return true;
            }
            else if (CurrentBoardState[0][2] == CurrentBoardState[1][1] && CurrentBoardState[1][1] == CurrentBoardState[2][0] && CurrentBoardState[1][1] != "*")
            {
                return true;
            }
            
            return false;
        }
    }
}