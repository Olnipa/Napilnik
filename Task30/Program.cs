class Task30
{
    public void EnableAnimation()
    {
        _effects.StartEnableAnimation();
        _enable = true;
    }

    public void DoSomethingWithPool()
    {
        _pool.Free(this);
        _enable = false;
    }
}
