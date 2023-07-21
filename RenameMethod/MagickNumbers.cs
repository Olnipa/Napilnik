namespace CleanCode
{
    internal class Weapon
    {
        private const int _minBulletsToShoot  = 0;
        private const int _bulletsPerShoot = 1;
        
        private int _bullets;

        public bool CanShoot() => _bullets > _minBulletsToShoot;

        public void Shoot() => _bullets -= _bulletsPerShoot;
    }

}
