using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticTrajectoryCalculator.Services
{
    public class DragCoefficient
    {
        private double mass;                // масса пули (в граммах)
        private double diameter;            // диаметр пули (в миллиметрах)
        private double length;              // длина пули (в миллиметрах)
        private double velocity;            // скорость пули (в метрах в секунду)
        private double temperature;         // температура воздуха (в градусах Цельсия)
        private double pressure;            // атмосферное давление (в миллиметрах ртутного столба)
        private double humidity;            // относительная влажность (в процентах)

        public DragCoefficient(double mass, double diameter, double length, double velocity, double temperature, double pressure, double humidity)
        {
            this.mass = mass;
            this.diameter = diameter;
            this.length = length;
            this.velocity = velocity;
            this.temperature = temperature;
            this.pressure = pressure;
            this.humidity = humidity;
        }

        public double GetCd(bool isSupersonic = false)
        {
            // Расчёт коэффициента лобового сопротивления
            double projectileArea = Math.PI * Math.Pow(diameter / 1000.0 / 2.0, 2.0); // площадь поперечного сечения пули (в квадратных метрах)
            double atmosphericDensity = pressure * 100.0 / (287.058 * (temperature + 273.15)); // плотность воздуха (в килограммах на кубический метр)

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
    }
}
