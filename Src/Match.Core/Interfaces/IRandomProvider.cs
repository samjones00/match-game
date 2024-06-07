namespace Match.Core.Interfaces
{
    public interface IRandomProvider
    {
        T[] Shuffle<T>(T[] source);
    }
}