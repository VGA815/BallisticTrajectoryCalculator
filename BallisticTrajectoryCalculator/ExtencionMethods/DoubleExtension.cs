namespace BallisticTrajectoryCalculator.ExtencionMethods
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Convert degrees to radians
        /// </summary>
        /// <param name="angleDegrees"></param>
        /// <returns></returns>
        public static double ToRadians(this double angleDegrees) => angleDegrees * Math.PI / 180;

        /// <summary>
        /// Calculate cross section area  meters^2 
        /// </summary>
        /// <param name="diameter"></param>
        /// <returns></returns>
        public static double CrossSectionArea(this double diameter) => Math.PI * Math.Pow(diameter / 1000.0 / 2.0, 2.0);

    }
}
