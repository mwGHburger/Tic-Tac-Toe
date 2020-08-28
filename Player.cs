namespace Tic_Tac_Toe
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name {get; private set; }
    }
}