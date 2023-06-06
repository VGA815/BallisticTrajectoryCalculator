using OxyPlot.Series;
using System.Globalization;

namespace BallisticTrajectoryCalculator.ExtencionMethods
{
    public static class FunctionSeriesExtension
    {
        /// <summary>
        /// Convert data series to csv file (columns "X" "Y")
        /// </summary>
        /// <param name="series"></param>
        /// <param name="path"></param>
        async public static void ToCsv(this FunctionSeries series, string path = @"D:\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\Data\data.csv")
        {
            var culture = new CultureInfo("en-US");
            await using var streamWriter = new StreamWriter(path, true);
            string[] columns = { "X", "Y" };
            await streamWriter.WriteLineAsync(string.Join(";", columns));
            foreach (var p in series.Points)
            {
                double x = ((double)p.X);
                double y = ((double)p.Y);
                string[] row = { x.ToString("F2",culture), y.ToString("F",culture) };
                await streamWriter.WriteLineAsync(string.Join(";", row));
            }
        }
    }
}
