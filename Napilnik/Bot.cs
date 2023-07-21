namespace Napilnik
{

    internal class Bot
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