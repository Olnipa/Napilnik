namespace Napilnik
{
    internal class Weapon
    {
        public Weapon(int damage, int bullets = 0)
        {
            if (damage < 0 || bullets < 0)
                throw new ArgumentException("Damage and/or bullets count < 0.");

            Damage = damage;
            Bullets = bullets;
        }

        public int Damage { get; private set; }

        public int Bullets { get; private set; }

        public void Fire(Player player)
        {
            player.TryTakeDamage(Damage);
            Bullets -= 1;
        }
    }
}