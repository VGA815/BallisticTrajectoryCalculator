using OxyPlot.Series;

namespace BallisticTrajectoryCalculator.Forms
{

    public partial class MainForm : Form
    {

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

            validator.ShootingAngle = Convert.ToInt32(shootAngleBox.Text);
            validator.InitialVelocity = Convert.ToDouble(initialVelocityBox.Text);
            validator.Pressure = Convert.ToInt32(pressureBox.Text);
            validator.AirDensity = Convert.ToDouble(airDensityBox.Text);
            validator.Humidity = Convert.ToInt32(humidityBox.Text);
            validator.Temperature = Convert.ToInt32(temperatureBox.Text);
            validator.ItemBCbox = caliberBox.GetItemText(caliberBox.SelectedItem);
            validator.ChartSize = Convert.ToInt32(chartSizeBox.Text);
            validator.WindVelocity = Convert.ToDouble(windVelocityBox.Text);
            string caliber = caliberBox.GetItemText(caliberBox.SelectedItem);
            var s = new FunctionSeries(Y, 0, CalculateDistance(), 0.1);

            s.Title = $"Caliber: {caliber}\nInitial velocity: {validator.InitialVelocity}\nAngle: {validator.ShootingAngle}";
            plotModel.Series.Add(s);
            plotView.Model = plotModel;
            plotView.InvalidatePlot(true);


        }
        public double Y(double xo)
        {


            double velocity = validator.InitialVelocity;
            int temperature = validator.Temperature;
            int humidity = validator.Humidity;
            int pressure = validator.Pressure;
            double airDensity = validator.AirDensity;
            string caliber = caliberBox.GetItemText(caliberBox.SelectedItem);
            double diameter = caliberData[caliber].Diameter;
            double lenght = caliberData[caliber].Lenght;
            double weight = caliberData[caliber].Weight;
            double angle = validator.ShootingAngle;
            double windVelocity = validator.S
            BallisticCoefficient bc = new(weight, diameter, velocity, temperature, airDensity, angle);
            var wa = new WindAffect(bc,);
            double bk = bc.CalculateBC();

            validator.BallisticCoefficient = bk;
            //velocity > machNumber.GetSonicVelocity() ? machNumber.GetMachNumber() : 0
            //string dictAsString = string.Join(", ", bullet.Calibers.Select(kv => $"{kv.Key}={kv.Value}"));
            double k = bk / 100000;


            bcBox.Text = Convert.ToString(k);
            double A = (Math.PI * Math.Pow(diameter, 2) / 4);

            //double v = Math.Sqrt((2 * weight * g) / (airDensity * A * dragCoefficient.GetCd())) * Math.Tanh(Math.Sqrt((airDensity * A * dragCoefficient.GetCd() * g * xo) / (2 * weight)));
            double v = velocity;
            double a = angle.ToRadians();

            //double t = (2 * velocity * Math.Sin(a)) / g;
            double y = 1.5 + xo * Math.Tan(a) - (g * Math.Pow(xo, 2) / (2 * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2))) * (1 + k * Math.Pow(v, 2) * xo);

            //double y = xo * Math.Tan(a) - (g * Math.Pow(xo, 2)) / (2 * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2)) + (Math.Pow(xo, 2) * k) / (2 * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2));
            //double y = velocity * Math.Sin(a) - (g * Math.Pow(t, 2)) / 2 - (k * airDensity * (Math.PI * Math.Pow(diameter, 2) / 4) * Math.Pow(v, 2) * t) / (2 * weight);
            //var y = 1.5 + (xo * Math.Tan(a)) - (g * Math.Pow(xo, 2)) / (2 * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2)) + (Math.Pow(xo, 2) * (Math.Pow(k, 2) * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2) / (Math.Pow(g, 2)))) / (2 * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2) * Math.Sqrt((Math.Pow(k, 2) * Math.Pow(v, 4) * Math.Pow(Math.Cos(a), 4))) / (Math.Pow(g, 2)) + 1);
            return y;
        }

        public double CalculateDistance()
        {
            //double velocity = validator.SelectedInitialVelocity;
            //double theta = validator.SelectedAngle * Math.PI / 180;
            //double D = (velocity * velocity / g) * (Math.Sin(2 * theta) + Math.Sqrt(Math.Sin(2 * theta) * Math.Sin(2 * theta) + (8 * g * 1.5) / (velocity * velocity)));
            //double D = (Math.Pow(velocity, 2) / g) * Math.Sin(2 * theta * (Math.PI / 180));
            return validator.ChartSize;
        }

        private void clearGraphButton_Click(object sender, EventArgs e)
        {
            plotModel.Series.Clear();
            plotView.Model = plotModel;
            plotView.InvalidatePlot(true);


        }
    }
}
