using Match.Core.Interfaces;

namespace Match.Core
{
    public class RandomProvider : IRandomProvider
    {
        public T[] Shuffle<T>(T[] source)
        {
            Random.Shared.Shuffle(source);
            return source;
        }
    }
}