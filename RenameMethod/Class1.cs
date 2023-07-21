namespace CleanCode
{
    class Player { }

    class Gun { }

    class TargetFollower { }

    class UnitsGetter
    {
        public IReadOnlyCollection<Unit> UnitsToGet { get; private set; }
    }
}