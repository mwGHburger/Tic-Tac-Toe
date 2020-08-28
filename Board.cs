using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class Board
    {
        public Board()
        {
            CurrentState = new List<List<string>> {
                new List<string> {"*", "*", "*"},
                new List<string> {"*", "*", "*"},
                new List<string> {"*", "*", "*"}
            };
        }

        // PROPERTIES
        public List<List<string>> CurrentState
        {
            get; set;
        }

        // METHODS
        public void DisplayBoard()
        {
            Console.WriteLine();
            foreach(List<string> row in this.CurrentState)
            {
                foreach(string space in row)
                {
                    Console.Write($"{space} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool AddToBoard(int xcoordinate, int ycoordinate, Player currentPlayer)
        {
            if (CurrentState[xcoordinate - 1][ycoordinate - 1] == "*")
            {
                // TODO: Determine the input
                CurrentState[xcoordinate - 1][ycoordinate - 1] = currentPlayer.Marker;
                return true;
            }
            else{
                return false;
            }
            
        }

        public bool CheckForWinner()
        {
            // CHECK ROWS
            if(CurrentState[0][0] == CurrentState[0][1] &&  CurrentState[0][1] == CurrentState[0][2] && CurrentState[0][0] != "*")
            {
                return true;
            }
            else if (CurrentState[1][0] == CurrentState[1][1] &&  CurrentState[1][1] == CurrentState[1][2] && CurrentState[1][1] != "*")
            {
                return true;
            }
            else if (CurrentState[2][0] == CurrentState[2][1] &&  CurrentState[2][1] == CurrentState[2][2] && CurrentState[2][0] != "*")
            {
                return true;
            }
            // CHECK COLUMNS
            else if (CurrentState[0][0] == CurrentState[1][0] && CurrentState[1][0] == CurrentState[2][0] && CurrentState[0][0] != "*")
            {
                return true;
            }
            else if (CurrentState[0][1] == CurrentState[1][1] && CurrentState[1][1] == CurrentState[2][1] && CurrentState[1][1] != "*")
            {
                return true;
            }
            else if (CurrentState[0][2] == CurrentState[1][2] && CurrentState[1][2] == CurrentState[2][2] && CurrentState[1][2] != "*")
            {
                return true;
            }
            // CHECK DIAGONALS
            else if (CurrentState[0][0] == CurrentState[1][1] && CurrentState[1][1] == CurrentState[2][2] && CurrentState[1][1] != "*")
            {
                return true;
            }
            else if (CurrentState[0][2] == CurrentState[1][1] && CurrentState[1][1] == CurrentState[2][0] && CurrentState[1][1] != "*")
            {
                return true;
            }
            
            return false;
        }
    }
}