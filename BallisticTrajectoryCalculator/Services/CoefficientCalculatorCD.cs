using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticTrajectoryCalculator.Services
{
    public class CoefficientCalculatorCD
    {
        public double CalculateLinearCoefficient(double[] velocities, double[] resistances)
        {
            double averageVelocity = velocities.Average();
            double numerator = 0;
            double denominator = 0;

            for (int i = 0; i < velocities.Length; i++)
            {
                double resistance = resistances[i];
                double velocityDifference = velocities[i] - averageVelocity;

                numerator += velocityDifference * resistance;
                denominator += Math.Pow(velocityDifference, 2);
            }

            return numerator / denominator;
        }

        public double CalculateQuadraticCoefficient(double[] velocities, double[] resistances)
        {
            double averageVelocity = velocities.Average();
            double numerator = 0;
            double denominator = 0;

            for (int i = 0; i < velocities.Length; i++)
            {
                double resistance = resistances[i];
                double velocityDifference = velocities[i] - averageVelocity;

                numerator += Math.Pow(velocityDifference, 2) * resistance;
                denominator += Math.Pow(velocityDifference, 4);
            }

            return numerator / denominator;
        }

        public double CalculateNthOrderCoefficient(double[] velocities, double[] resistances, int n)
        {
            double averageVelocity = velocities.Average();
            double numerator = 0;
            double denominator = 0;

            for (int i = 0; i < velocities.Length; i++)
            {
                double resistance = resistances[i];
                double velocityDifference = velocities[i] - averageVelocity;

                numerator += Math.Pow(velocityDifference, n) * resistance;
                denominator += Math.Pow(velocityDifference, 2 * n);
            }

            return numerator / denominator;
        }
    }
}
