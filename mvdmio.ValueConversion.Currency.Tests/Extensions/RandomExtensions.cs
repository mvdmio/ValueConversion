namespace mvdmio.ValueConversion.Currency.Tests.Extensions
{
    public static class RandomExtensions
    {
        public static double NextDouble(this Random random, double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}
