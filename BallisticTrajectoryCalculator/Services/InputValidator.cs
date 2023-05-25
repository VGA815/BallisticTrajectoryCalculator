namespace BallisticTrajectoryCalculator.Services
{
    public class InputValidator
    {        
        // bcBox Validate
        [Required]
        public string ItemBCbox { get; set; }
        
        // initialVelocityBox Validate
        [Required, Range(0, 7000, ErrorMessage = "Wrong initial velocity value")]
        public double InitialVelocity { get; set; }
        
        // shootAngelBox Validate
        [Required, Range(0, 90, ErrorMessage = "Wrong shooting angle value")]
        public int ShootingAngle { get; set; }
        
        // temperatureBox Validate
        [Required, Range(-273, 5000, ErrorMessage = "Wrong temperature value")]
        public int Temperature { get; set; }
        
        // pressureBox Validate
        [Required, Range(0, 2500, ErrorMessage = "Wrong pressure value")]
        public int Pressure { get; set; }
        
        // humidityBox Validate
        [Required, Range(0, 100, ErrorMessage = "Wrong humidity value")]
        public int Humidity { get; set; }
        
        // airDensityBox Validate
        [Required, Range(0, 100, ErrorMessage = "Wrong air density value")]
        public double AirDensity { get; set; }
        
        [Required, Range(1, 30000, ErrorMessage = "Wrong chart size value")]
        public int ChartSize { get; set; }
        
        public double BallisticCoefficient { get; set; }

        [Required, Range(0, 200, ErrorMessage = "Wrong wind velocity value")]
        public double WindVelocity { get; set; }
    }
}
