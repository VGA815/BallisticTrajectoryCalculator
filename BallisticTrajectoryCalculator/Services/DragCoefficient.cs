using BallisticTrajectoryCalculator.ExtencionMethods;

namespace BallisticTrajectoryCalculator.Services
{
    public class DragCoefficient
    {
        private double mass;                
        private double diameter;            
        private double velocity;            
        private double temperature;         
        private double density;
        private double angle;

        public DragCoefficient(double mass, double diameter, double velocity, double temperature, double density, double angle)
        {
            this.mass = mass;
            this.diameter = diameter;

            this.velocity = velocity;
            this.temperature = temperature;


            this.density = density;
            this.angle = angle.ToRadians();
        }

        public double CalculateCd(bool isSupersonic = false)
        {
           
            double projectileArea = diameter.CrossSectionArea(); 
            double atmosphericDensity = density; 

            double Cd;
            if (isSupersonic)
            {
                double MachNumber = velocity / Math.Sqrt(1.4 * 287.058 * (temperature + 273.15));
                Cd = 0.26 / Math.Pow(MachNumber, 0.15);
            }
            else
            {
                Cd = 0.5 * atmosphericDensity * projectileArea / mass * Math.Pow(velocity, 2.0);
            }

            return Cd;
        }
        public double CalculateCdByGaborSommerfeld(double force)
        {
            double cd = 2 * force / (density * angle * velocity * velocity);
            return cd;
        }

        public double CalculateCdByLabroAndJonker(double k)
        {
            double b = 1 / (0.5 * density * angle * velocity * velocity);
            double cd = k / b;
            return cd;
        }

        public double CalculateKByCd(double cd)
        {
            double k = 1 / (0.5 * density * angle * velocity * velocity * cd);
            return k;
        }
    }
}
