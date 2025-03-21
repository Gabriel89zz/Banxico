using ScottPlot;
using System.Data;

namespace Banxico
{
    public partial class PiePlot : Form
    {
        public PiePlot()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            List<double> data = new List<double>();
            for (int i = 0; i < 100; i++)
            {
                data.Add(rand.Next(1, 6));
            }

            // Count the frequency of each number
            Dictionary<double, double> frequencies = new Dictionary<double, double>();
            foreach (var number in data)
            {
                if (frequencies.ContainsKey(number))
                    frequencies[number]++;
                else
                    frequencies[number] = 1;
            }

            // Prepare data for the charts
            double[] values = new double[frequencies.Count];
            int index = 0;
            foreach (var item in frequencies)
            {
                values[index] = item.Value;
                index++;
            }

            ConfigureNormalPieChart(values);
            ConfigureDonutChart(values);
            ConfigurePieChartFromSlices(values);
            ConfigurePieWithPercentLabels(values);
        }

        private void ConfigureNormalPieChart(double[] values)
        {
            // NormalPieChart.Plot.Clear();
            var pie = NormalPieChart.Plot.Add.Pie(values);
            NormalPieChart.Plot.Title("Normal Pie Chart");
            pie.ExplodeFraction = .1;
            NormalPieChart.Plot.Axes.Frameless();
            NormalPieChart.Plot.HideGrid();
            NormalPieChart.Refresh();
        }

        private void ConfigureDonutChart(double[] values)
        {
            Donut.Plot.Clear();
            //var pie = Donut.Plot.Add.Pie(values);

            List<PieSlice> slices = new List<PieSlice>();
            string[] labels = { "1", "2", "3", "4", "5" };
            ScottPlot.Color[] colors = { Colors.Red, Colors.Orange, Colors.Gold, Colors.Green, Colors.Blue };

            for (int i = 0; i < values.Length; i++)
            {
                slices.Add(new PieSlice
                {
                    Value = values[i],
                    FillColor = colors[i],
                    Label = $"{labels[i]} ({values[i]})"
                });
            }

            var pie = Donut.Plot.Add.Pie(slices);
            pie.DonutFraction = .5; // Create a hole in the center
            Donut.Plot.Axes.Frameless();
            Donut.Plot.HideGrid();
            Donut.Plot.Title("Donut Chart");
            Donut.Refresh();
        }

        private void ConfigurePieChartFromSlices(double[] values)
        {
            // Create a list of PieSlice based on frequencies
            List<PieSlice> slices = new List<PieSlice>();
            string[] labels = { "One", "Two", "Three", "Four", "Five" };
            ScottPlot.Color[] colors = { Colors.Red, Colors.Orange, Colors.Gold, Colors.Green, Colors.Blue };

            for (int i = 0; i < values.Length; i++)
            {
                slices.Add(new PieSlice
                {
                    Value = values[i],
                    FillColor = colors[i],
                    Label = $"{labels[i]} ({values[i]})",
                    LegendText = labels[i]
                });
            }

            // Create the pie chart
            PieChartFromSlices.Reset();
            var pie = PieChartFromSlices.Plot.Add.Pie(slices);

            // Configure additional properties
            pie.ExplodeFraction = 0.1; // Slightly separate the segments
            pie.SliceLabelDistance = 1.4; // Distance of labels from the center

            // Show legend
            PieChartFromSlices.Plot.ShowLegend();

            // Hide unnecessary components
            PieChartFromSlices.Plot.Axes.Frameless();
            PieChartFromSlices.Plot.HideGrid();

            // Render the chart
            PieChartFromSlices.Refresh();
        }

        private void ConfigurePieWithPercentLabels(double[] values)
        {
            PieWithPercentLabels.Plot.Clear();
            var pie = PieWithPercentLabels.Plot.Add.Pie(values);
            pie.ExplodeFraction = .1;
            pie.SliceLabelDistance = 0.5;

            double total = pie.Slices.Select(x => x.Value).Sum();
            double[] percentages = pie.Slices.Select(x => x.Value / total * 100).ToArray();
            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].Label = $"{percentages[i]:0.0}%";
                pie.Slices[i].LabelFontSize = 20;
                pie.Slices[i].LabelBold = true;
                pie.Slices[i].LabelFontColor = Colors.Black.WithAlpha(.5);
            }
            PieWithPercentLabels.Plot.Title("Chart with Percentages");
            PieWithPercentLabels.Plot.Axes.Frameless();
            PieWithPercentLabels.Plot.HideGrid();
            PieWithPercentLabels.Refresh();
        }
    }
}