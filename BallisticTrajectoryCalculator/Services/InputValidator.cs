namespace BallisticTrajectoryCalculator.Services
{
    public delegate void ValidateHadler();
    public class InputValidator
    {
        public event ValidateHadler UnValidated;
        private void ValidateOnValidate()
        {
            if (UnValidated != null) UnValidated();
            else Console.WriteLine("OnValidate is null");
        }
        // bcBox Validate
        private string? _selectedItemBCbox;
        public string? SelectedItemBCbox
        {
            get => _selectedItemBCbox;
            set
            {

                if (value != null) _selectedItemBCbox = value;
                else ValidateOnValidate();
            }
        }
        // initialVelocityBox Validate
        private double _selectedInitialVelocity;
        public double SelectedInitialVelocity
        {
            get => _selectedInitialVelocity;
            set
            {

                if (value != null && value >= 0 && value < 7000) _selectedInitialVelocity = value;
                else ValidateOnValidate();
            }
        }
        // shootAngelBox Validate
        private int _selectedAngle;
        public int SelectedAngle
        {
            get => _selectedAngle;
            set
            {

                if (value != null && value >= 0 && value <= 90) _selectedAngle = value;
                else ValidateOnValidate();
            }
        }
        // temperatureBox Validate
        private int _selectedTemperature;
        public int SelectedTemperature
        {
            get => _selectedTemperature;
            set
            {

                if (value != null && value > -270 && value < 4000) _selectedTemperature = value;
                else ValidateOnValidate();
            }
        }
        // pressureBox Validate
        private int _selectedPressure;
        public int SelectedPressure
        {
            get => _selectedPressure;
            set
            {

                if (value != null && value > 0) _selectedPressure = value;
                else ValidateOnValidate();
            }
        }
        // humidityBox Validate
        private int _selectedHumidity;
        public int SelectedHumidity
        {
            get => _selectedHumidity;
            set
            {

                if (value != null && value >= 0 && value <= 100) _selectedHumidity = value;
                else ValidateOnValidate();
            }
        }
        // airDensityBox Validate
        private double _selectedAirDensity;
        public double SelectedAirDensity
        {
            get => _selectedAirDensity;
            set
            {

                if (value != null && value > 0) _selectedAirDensity = value;
                else ValidateOnValidate();
            }
        }

        private int _selectedChartSize;

        public int SelectedChartSize
        {
            get => _selectedChartSize;
            set
            {
                if (value != null && value > 0) _selectedChartSize = value;
                else ValidateOnValidate();
            }
        }
        public double ballisticCoefficient { get; set; }
    }
}
