namespace BallisticTrajectoryCalculator.Services
{
    public class BallisticCoefficient
    {
        private const double pi = Math.PI;
        private double cd;
        public BallisticCoefficient(double mass, double diameter, double velocity, double temperature, double density, double angle) 
        {
            DragCoefficient dragCoefficient = new DragCoefficient(mass, diameter, velocity, temperature, density, angle);
            this.cd = dragCoefficient.GetCd();
        }

        // Рассчитываем значение баллистического коэффициента не по методу Габора-Спитцера
        public double CalculateBC(double bulletDiameter, double bulletMass)
        {
            double bk = (bulletMass * cd) * Math.Pow((bulletDiameter / 2), 2) * 0.00029556;
            return bk;
        }
    }
}
