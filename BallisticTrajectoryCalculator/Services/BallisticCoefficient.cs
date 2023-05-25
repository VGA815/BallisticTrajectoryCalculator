namespace BallisticTrajectoryCalculator.Services
{
    public class BallisticCoefficient
    {
        private double cd;
        private double mass;
        private double diameter;
        public BallisticCoefficient(double mass, double diameter, double velocity, double temperature, double density, double angle)
        {
            var dragCoefficient = new DragCoefficient(mass, diameter, velocity, temperature, density, angle);
            this.cd = dragCoefficient.GetCd();
            this.mass = mass;
            this.diameter = diameter;
        }
        // Рассчитываем значение баллистического коэффициента не по методу Габора-Спитцера
        public double CalculateBC()
        {
            return (double)((mass * cd) * Math.Pow((diameter / 2), 2) * 0.00029556);
        }
    }
}
