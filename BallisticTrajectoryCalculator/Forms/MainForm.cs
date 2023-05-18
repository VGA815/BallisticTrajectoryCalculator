using BallisticTrajectoryCalculator.Services;
using OxyPlot.Series;

namespace BallisticTrajectoryCalculator.Forms
{
    
    public partial class MainForm : Form
    {
        private bool nenol = true;
        const double g = 9.81;
        public InputValidator validator = new();
        Dictionary<string, Models.BulletParameters> caliberData = BulletJsonParser.Parse();
        public MainForm()
        {
            InitializeComponent();
            temperatureBox.Text = "15";
            humidityBox.Text = "50";
            pressureBox.Text = "330";
            airDensityBox.Text = "1,2";
        }

        private void createGraphButton_Click(object sender, EventArgs e)
        {
            nenol = true;
            validator.SelectedAngle = Convert.ToInt32(shootAngleBox.Text);
            validator.SelectedInitialVelocity = Convert.ToDouble(initialVelocityBox.Text);
            validator.SelectedPressure = Convert.ToInt32(pressureBox.Text);
            validator.SelectedAirDensity = Convert.ToDouble(airDensityBox.Text);
            validator.SelectedHumidity = Convert.ToInt32(humidityBox.Text);
            validator.SelectedTemperature = Convert.ToInt32(temperatureBox.Text);
            validator.SelectedItemBCbox = caliberBox.GetItemText(caliberBox.SelectedItem);
            string caliber = caliberBox.GetItemText(caliberBox.SelectedItem);
            var s = new FunctionSeries(Y, 0, CalculateDistance(), 0.1);

            s.Title = $"Caliber: {caliber}\nInitial velocity: {validator.SelectedInitialVelocity}\nAngle: {validator.SelectedAngle}";
            plotModel.Series.Add(s);
            plotView.Model = plotModel;
            plotView.InvalidatePlot(true);


        }
        public double Y(double xo)
        {
            if (nenol)
            {

                BallisticCoefficient bc = new();

                var velocity = validator.SelectedInitialVelocity;
                var temperature = validator.SelectedTemperature;
                var humidity = validator.SelectedHumidity;
                var pressure = validator.SelectedPressure;
                var airDensity = validator.SelectedAirDensity;
                string caliber = caliberBox.GetItemText(caliberBox.SelectedItem);
                double diameter = caliberData[caliber].Diameter;
                double lenght = caliberData[caliber].Lenght;
                double weight = caliberData[caliber].Weight;
                int angle = validator.SelectedAngle;
                MachNumber machNumber = new(velocity, temperature);
                DragCoefficient dragCoefficient = new(weight, diameter, lenght, velocity, temperature, pressure, humidity);
                double bk = bc.CalculateBC(dragCoefficient.GetCd(velocity > machNumber.GetSonicVelocity() ? true : false), diameter, validator.SelectedAirDensity, weight, velocity, temperature);
                validator.ballisticCoefficient = bk;
                //velocity > machNumber.GetSonicVelocity() ? machNumber.GetMachNumber() : 0
                //string dictAsString = string.Join(", ", bullet.Calibers.Select(kv => $"{kv.Key}={kv.Value}"));
                double k = dragCoefficient.GetCd() / 100000000;


                bcBox.Text = Convert.ToString(k);
                var A = (Math.PI * Math.Pow(diameter, 2) / 4);

                //double v = Math.Sqrt((2 * weight * g) / (airDensity * A * dragCoefficient.GetCd())) * Math.Tanh(Math.Sqrt((airDensity * A * dragCoefficient.GetCd() * g * xo) / (2 * weight)));
                double v = velocity;
                double a = Math.PI * angle / 180;

                //double t = (2 * velocity * Math.Sin(a)) / g;
                double y = xo * Math.Tan(a) - (g * Math.Pow(xo, 2) / (2 * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2))) * (1 + k * Math.Pow(v, 2) * xo);
                if (y < 0)
                {
                    nenol = false;
                }
                //double y = xo * Math.Tan(a) - (g * Math.Pow(xo, 2)) / (2 * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2)) + (Math.Pow(xo, 2) * k) / (2 * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2));
                //double y = velocity * Math.Sin(a) - (g * Math.Pow(t, 2)) / 2 - (k * airDensity * (Math.PI * Math.Pow(diameter, 2) / 4) * Math.Pow(v, 2) * t) / (2 * weight);
                //var y = 1.5 + (xo * Math.Tan(a)) - (g * Math.Pow(xo, 2)) / (2 * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2)) + (Math.Pow(xo, 2) * (Math.Pow(k, 2) * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2) / (Math.Pow(g, 2)))) / (2 * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2) * Math.Sqrt((Math.Pow(k, 2) * Math.Pow(v, 4) * Math.Pow(Math.Cos(a), 4))) / (Math.Pow(g, 2)) + 1);
                return y;
            }
            else
            {
                
                return 0;
            }
            
            
        }
        public double CalculateDistance()
        {
            double velocity = validator.SelectedInitialVelocity;
            var theta = validator.SelectedAngle;
            double D = (Math.Pow(velocity, 2) / g) * Math.Sin(2 * theta * (Math.PI / 180));
            return D;
        }

        private void clearGraphButton_Click(object sender, EventArgs e)
        {
            plotModel.Series.Clear();
            plotView.Model = plotModel;
            plotView.InvalidatePlot(true);
            

        }
    }
}
