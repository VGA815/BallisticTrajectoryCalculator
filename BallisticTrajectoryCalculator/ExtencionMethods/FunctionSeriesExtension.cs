using OxyPlot.Series;
using System.Data;
using System.Text;

namespace BallisticTrajectoryCalculator.ExtencionMethods
{
    public static class FunctionSeriesExtension
    {
        async public static void ToCsv(this FunctionSeries series, string path = @"D:\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\BallisticTrajectoryCalculator\Data\data.csv")
        {
            await using var streamWriter = new StreamWriter(path, true);
            string[] columns = { "X", "Y" };
            await streamWriter.WriteLineAsync(string.Join(";", columns));

            foreach (var p in series.Points)
            {
                string[] row = { p.X.ToString(), p.Y.ToString() };
                await streamWriter.WriteLineAsync(string.Join(";", row));
            }
        }
    }
}
