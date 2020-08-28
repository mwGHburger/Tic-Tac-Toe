namespace Tic_Tac_Toe
{
    public class Player
    {
        public Player(string name, string marker, bool turn)
        {
            this.Name = name;
            this.Marker = marker;
            this.Turn = turn;
        }

        // PROPERTIES
        public string Name { get;  set; }
        public string Marker{ get;  set;}
        public bool Turn {get; set;}
    }
}