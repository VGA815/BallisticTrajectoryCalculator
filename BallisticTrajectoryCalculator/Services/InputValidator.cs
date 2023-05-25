namespace BallisticTrajectoryCalculator.Services
{
    public class InputValidator
    {        
        // bcBox Validate
        [Required]
        public string? SelectedItemBCbox { get; set; }
        
        // initialVelocityBox Validate
        [Required]
        [Range(0,7000,ErrorMessage = "Wrong initial velocity value")]        
        public double SelectedInitialVelocity { get; set; }
        
        // shootAngelBox Validate
        [Required]
        [Range(0,90,ErrorMessage = "Wrong shooting angle value")]        
        public int SelectedAngle { get; set; }
        
        // temperatureBox Validate
        [Required]
        [Range(-273,5000,ErrorMessage = "Wrong temperature value")]
        public int SelectedTemperature { get; set; }
        
        // pressureBox Validate
        [Required]
        [Range(0,2500,ErrorMessage = "Wrong pressure value")]
        public int SelectedPressure { get; set; }
        
        // humidityBox Validate
        [Required]
        [Range(0,100,ErrorMessage = "Wrong humidity value")]
        public int SelectedHumidity { get; set; }
        
        // airDensityBox Validate
        [Required]
        [Range(0,100,ErrorMessage = "Wrong air density value")]
        public double SelectedAirDensity { get; set; }
        
        [Required]
        [Range(1,30000,ErrorMessage = "Wrong chart size value")]
        public int SelectedChartSize { get; set; }
        
        public double BallisticCoefficient { get; set; }

        [Required]
        [Range(0,200,ErrorMessage = "Wrong wind velocity value")]
        public double SelectedWindVelocity { get; set; }
    }
}
