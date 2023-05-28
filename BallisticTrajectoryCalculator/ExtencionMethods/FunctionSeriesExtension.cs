using OxyPlot.Series;
using System.Text;

namespace BallisticTrajectoryCalculator.ExtencionMethods
{
    public static class FunctionSeriesExtension
    {
        public static void ToCsv(this FunctionSeries series, string path = "./Data/data.csv")
        {
            string separator = ",";
            StringBuilder output = new StringBuilder();

            string[] headings = { "X", "Y" };
            output.AppendLine(string.Join(separator, headings));

            foreach (var p in series.Points)
            {
                string[] newLine = { p.X.ToString(), p.Y.ToString() };
                output.AppendLine(string.Join(separator, newLine));
            }
            try
            {
                File.AppendAllText(path, output.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data could not be written to the CSV file.");
                return;
            }


        }
    }
}
