namespace BallisticTrajectoryCalculator.Services
{
    public class MachNumber
    {
        private const double R = 287.058;
        private double velocity;
        private int temperature;
        private double lambda;
        public MachNumber(double velocity, int temperature, double lambda = 1.4)
        {
            this.velocity = velocity;
            this.temperature = temperature;
            this.lambda = lambda;
        }
        public double GetSonicVelocity()
        {
            int t = temperature + 273;
            return Math.Sqrt(lambda * R * t);
        }
        public double GetMachNumber()
        {
            return velocity / GetSonicVelocity();
        }
    }
}
