namespace BallisticTrajectoryCalculator.Services
{
    public class WindAffect
    {
        private double originalBC;
        private double windVelocity;
        private double bulletVelocity;
        public WindAffect(BallisticCoefficient bc, double windVelocity, double bulletVelocity)
        {
            this.originalBC = bc.CalculateBC();
            this.windVelocity = windVelocity;
            this.bulletVelocity = bulletVelocity;
        }
        public double CalculateAdjustedBCForWind()
        {
            double vRatio = windVelocity / bulletVelocity;
            double vRatioSquared = Math.Pow(vRatio, 2);
            double adjustedBC = originalBC * (1 - vRatioSquared);
            return adjustedBC;
        }

        public double CalculateAdjustedBCForWindAngle(double windAngle)
        {
            double alpha = Math.Cos(windAngle);
            double vRatio = (windVelocity * alpha) / bulletVelocity;
            double vRatioSquared = Math.Pow(vRatio, 2);
            double adjustedBC = originalBC * (1 - vRatioSquared);
            return adjustedBC;
        }
    }
}
