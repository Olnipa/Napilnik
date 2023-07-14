namespace Napilnik
{
    internal class Program
    {
        static void Main(string[] args)
        { }
    }

    class Weapon
    {
        public int Damage { get; private set; }
        public int Bullets { get; private set; }

        public Weapon(int damage, int bullets = 0)
        {
            if (damage < 0 || bullets < 0)
                throw new ArgumentException();

            Damage = damage;
            Bullets = bullets;
        }

        public void Fire(Player player)
        {
            player.TryTakeDamage(Damage);
            Bullets -= 1;
        }
    }

    class Player
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

    class Bot
    {
        private Weapon Weapon;

        public Bot(Weapon weapon)
        {
            Weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            Weapon.Fire(player);
        }
    }
}