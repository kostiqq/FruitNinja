namespace Data
{
    public class Player
    {
        public int MaxHealth;
        public int CurrentHealth;

        public Player(int startHealth)
        {
            MaxHealth = startHealth;
            CurrentHealth = MaxHealth;
        }
    }
}