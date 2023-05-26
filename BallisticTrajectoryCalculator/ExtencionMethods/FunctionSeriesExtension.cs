using CsvHelper;
using CsvHelper.Configuration;
using OxyPlot;
using OxyPlot.Series;
using System.Data;

namespace BallisticTrajectoryCalculator.ExtencionMethods
{
    public static class FunctionSeriesExtension
    {
        public static void ToCsv(this FunctionSeries series, string finalFileName = "data")
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("X", typeof(double));
            dataTable.Columns.Add("Y", typeof(double));

            foreach (var dataPoint in series.Points)
            {
                dataTable.Rows.Add(dataPoint.X, dataPoint.Y);
            }

            var csvConfig = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true // Change to false if you don't want header row
            };

            using (var writer = new StreamWriter($"./Data/{finalFileName}.csv"))
            using (var csv = new CsvWriter(writer, csvConfig))
            {
                csv.WriteRecords<DataPoint>(dataTable.AsEnumerable().Select(r => new DataPoint((double)r["X"], (double)r["Y"])));
            }
        }
    }
}
