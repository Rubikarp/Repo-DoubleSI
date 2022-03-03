namespace Core
{
    [System.Flags]
    public enum Season
    {
        Error = 0,
        Winter = 1 << 0,
        Spring = 1 << 1,
        Summer = 1 << 2,
        Autumn = 1 << 3,
        Neutral = ~Error,
    }
}

