namespace Napilnik
{
    class Weapon
    {
        public int Damage { get; private set; }
        public int Bullets { get; private set; }

        public void Fire(Player player)
        {
            player.TakeDamage(Damage);
            Bullets -= 1;
        }
    }

    class Player
    {
        public int Health { get; private set; }

        public void TakeDamage(int damage)
        {
            if (damage > 0)
                Health -= damage;
        }
    }

    class Bot
    {
        private Weapon Weapon;

        public void OnSeePlayer(Player player)
        {
            Weapon.Fire(player);
        }
    }
}