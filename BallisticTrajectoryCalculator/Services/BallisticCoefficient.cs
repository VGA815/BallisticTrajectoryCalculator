using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticTrajectoryCalculator.Services
{
    public class BallisticCoefficient
    {
        private const double pi = Math.PI;
        private double[] aCoefficients;
        private double[] bCoefficients;
        private double[] cCoefficients;
        private double[] dCoefficients;

        public BallisticCoefficient()
        {
            // Задаем значения коэффициентов a, b, c и d
            aCoefficients = new double[] { 0.2519, -0.012, -0.0006, 0.000041, -0.00000030 };
            bCoefficients = new double[] { 0.3183, -0.019, 0.0005, 0.000003, -0.00000005 };
            cCoefficients = new double[] { -0.1554, 0.021, -0.0003, 0.000003 };
            dCoefficients = new double[] { 0.0095, 0.0002, -0.000003 };
        }

        // Рассчитываем значение баллистического коэффициента по методу Габора-Спитцера
        public double CalculateBC(double dragCoefficient, double bulletDiameter, double airDensity, double bulletMass, double bulletVelocity, double temperature, double machNumber = 0.0)
        {
            double k;
            if (machNumber == 0.0) k = 0.5 * dragCoefficient * airDensity / (bulletMass / pi / 4 * bulletDiameter * bulletDiameter);

            else
            {
                double kSubsonic = 0.5 * dragCoefficient * airDensity / (bulletMass / pi / 4 * bulletDiameter * bulletDiameter);
                double M = machNumber / Math.Sqrt(1.4 * 287.058 * 273.15 + temperature);
                k = kSubsonic / Math.Pow(M, 2.0 / 3.0);
            }

            double v = bulletVelocity / 295.05;
            double sumA = aCoefficients[0];
            double sumB = bCoefficients[0];
            double sumC = cCoefficients[0];

            for (int i = 1; i < aCoefficients.Length; i++)
            {
                sumA += aCoefficients[i] * Math.Pow(v, i);
                sumB += bCoefficients[i] * Math.Pow(v, i);

                if (i < cCoefficients.Length) sumC += cCoefficients[i] * Math.Pow(v, i);

                if (i < dCoefficients.Length) sumC += dCoefficients[i] * Math.Pow(v, i);

            }

            return k / Math.Pow((sumA + sumB * v + sumC * v * v), 2);
        }
    }
}
