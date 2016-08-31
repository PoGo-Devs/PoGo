namespace System
{

    /// <summary>
    /// 
    /// </summary>
    public static class RandomExtensions
    {

        /// <summary>Calculates random value in [0;max], it includes maximum as well</summary>
        /// <param name="rnd">Random instance</param>
        /// <param name="max">Maximum, that is also included</param>
        /// <returns>Returns random value in [0;max]</returns>
        public static int NextInclusive(this Random rnd, int max) =>
            rnd.Next(max + 1);

        /// <summary>Calculates random value in [min;max], it includes maximum as well</summary>
        /// <param name="rnd">Random instance</param>
        /// <param name="min">Minimum</param>
        /// <param name="max">Maximum, that is also included</param>
        /// <returns>Returns random value in [min;max]</returns>
        public static int NextInclusive(this Random rnd, int min, int max) =>
            rnd.Next(min, max + 1);

    }

}