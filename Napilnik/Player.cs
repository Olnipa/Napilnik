namespace Napilnik
{

    internal class Player
    {
        public int Health { get; private set; }

        public Player(int health)
        {
            if (health < 0)
                throw new ArgumentException();

            Health = health;
        }

        public void TryTakeDamage(int damage)
        {
            if (damage > 0)
                Health -= damage;
        }
    }
}