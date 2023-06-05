using OxyPlot;
using OxyPlot.Series;
namespace BallisticTrajectoryCalculator.Forms
{

    public partial class MainForm : Form
    {

        const double g = 9.81;
        public InputValidator validator = new();
        Dictionary<string, BulletParameters> caliberData = BulletJsonParser.Parse();


        public MainForm()
        {
            InitializeComponent();
            temperatureBox.Text = "15";
            humidityBox.Text = "50";
            pressureBox.Text = "660";
            airDensityBox.Text = "1,2";
            var startSeries = new FunctionSeries(stS, 0, 100, 0.1) { Color = OxyColor.FromArgb(BackColor.A, BackColor.R, BackColor.G, BackColor.B) };
            plotModel.Series.Add(startSeries);
            plotView.Model = plotModel;
        }

        private void createGraphButton_Click(object sender, EventArgs e)
        {

            validator.ShootingAngle = int.Parse(shootAngleBox.Text);
            validator.InitialVelocity = double.Parse(initialVelocityBox.Text);
            validator.Pressure = int.Parse(pressureBox.Text);
            validator.AirDensity = double.Parse(airDensityBox.Text);
            validator.Humidity = int.Parse(humidityBox.Text);
            validator.Temperature = int.Parse(temperatureBox.Text);
            validator.ChartSize = int.Parse(chartSizeBox.Text);
            validator.ItemBCbox = (string)caliberBox.SelectedItem;
            var s = new FunctionSeries(Y, 0, CalculateDistance(), 0.1);
            s.ToCsv();
            s.Title = $"Caliber: {validator.ItemBCbox}\nInitial velocity: {validator.InitialVelocity}\nAngle: {validator.ShootingAngle}";
            plotModel.Series.Add(s);
            plotView.Model = plotModel;

            plotView.InvalidatePlot(true);


        }

        public double Y(double xo)
        {
            const double g = 9.81;
            double velocity = validator.InitialVelocity;
            int temperature = validator.Temperature;
            double airDensity = validator.AirDensity;
            string caliber = (string)caliberBox.SelectedItem;
            double diameter = caliberData[caliber].Diameter;
            double weight = caliberData[caliber].Weight;
            double angle = validator.ShootingAngle;
            BallisticCoefficient bc = new(weight, diameter, velocity, temperature, airDensity, angle);
            double bk = bc.CalculateBC();


            validator.BallisticCoefficient = bk;            //velocity > machNumber.GetSonicVelocity() ? machNumber.GetMachNumber() : 0
            //string dictAsString = string.Join(", ", bullet.Calibers.Select(kv => $"{kv.Key}={kv.Value}"));
            double k = bc.cd / 1000000;
            



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
            var startSeries = new FunctionSeries(stS, 0, 100, 0.1) { Color = OxyColor.FromArgb(BackColor.A, BackColor.R, BackColor.G, BackColor.B) };
            plotModel.Series.Add(startSeries);
            plotView.Model = plotModel;
            string filePath = @"D:\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\Data\data.csv";
            File.WriteAllText(filePath, string.Empty);

        }

        private void create3dGraphBtn_Click(object sender, EventArgs e)
        {
            //var ipy = Python.CreateRuntime();
            //var engine = ipy.GetEngine("Python");


            //var paths = engine.GetSearchPaths();
            //paths.Add(@"D:\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\Scripts\3dGraph.py");
            //engine.SetSearchPaths(paths);
            //ipy.UseFile(@"D:\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\Scripts\3dGraph.py");
        }
        private static double stS(double xo)
        {
            double a = 45.0.ToRadians();
            int v = 250;
            double k = 0.00001;


            double y = 1.5 + xo * Math.Tan(a) - (g * Math.Pow(xo, 2) / (2 * Math.Pow(v, 2) * Math.Pow(Math.Cos(a), 2))) * (1 + k * Math.Pow(v, 2) * xo);
            return y;
        }
    }
}
