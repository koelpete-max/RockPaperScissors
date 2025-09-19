namespace RockPaperScissors.test
{
    public sealed class SequenceRandom : IRandom
    {
        private readonly int[] _values; private int _i;
        public SequenceRandom(params int[] values) => _values = values;
        public int Next(int maxExclusive)
        {
            var v = _values[_i++ % _values.Length] % maxExclusive;
            return v < 0 ? v + maxExclusive : v;
        }
    }
}