namespace Tic_Tac_Toe
{
    public class Player
    {
        public Player(string name, string marker, bool turn)
        {
            this.Name = name;
            this.Marker = marker;
        }

        // PROPERTIES
        public string Name { get;  private set; }
        public string Marker{ get;  set;}
    }
}