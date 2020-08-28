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
        }

        public void AddToBoard()
        {
            // TODO: Determine the input
        }
    }
}