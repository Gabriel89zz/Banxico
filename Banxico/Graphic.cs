using Newtonsoft.Json.Linq;
using ScottPlot;
using ScottPlot.Colormaps;

namespace Banxico
{
    public partial class Graphic : Form
    {
        private string apiKey = "5d2cc4f982875659c557933657f2ea00f7d6e251c23104f771ab5f9f7d68c130";
        public Graphic()
        {
            InitializeComponent();
        }

        private async void btnConsult_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            // Validar que la fecha de inicio sea menor o igual a la fecha de fin
            if (startDate > endDate)
            {
                MessageBox.Show("La fecha de inicio debe ser menor o igual a la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Consultar datos del dólar y del euro
                string dollarUrl = $"https://www.banxico.org.mx/SieAPIRest/service/v1/series/SF43718/datos/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}?token={apiKey}";
                string euroUrl = $"https://www.banxico.org.mx/SieAPIRest/service/v1/series/SF46410/datos/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}?token={apiKey}";

                var dollarData = await FetchDataFromApi(dollarUrl);
                var euroData = await FetchDataFromApi(euroUrl);

                // Mostrar los resultados en las gráficas
                DisplayGraphs(dollarData, euroData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar la API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<JObject> FetchDataFromApi(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Lanza una excepción si la respuesta no es exitosa
                string responseBody = await response.Content.ReadAsStringAsync();
                return JObject.Parse(responseBody); // Parsear la respuesta JSON
            }
        }

        private void DisplayGraphs(JObject dollarData, JObject euroData)
        {
            // Extraer datos del dólar
            var dollarObservations = dollarData["bmx"]["series"][0]["datos"];
            List<DateTime> dates = new List<DateTime>();
            List<double> dollarValues = new List<double>();

            foreach (var obs in dollarObservations)
            {
                dates.Add(DateTime.Parse(obs["fecha"].ToString()));
                dollarValues.Add(double.Parse(obs["dato"].ToString()));
            }

            // Extraer datos del euro
            var euroObservations = euroData["bmx"]["series"][0]["datos"];
            List<double> euroValues = new List<double>();

            foreach (var obs in euroObservations)
            {
                euroValues.Add(double.Parse(obs["dato"].ToString()));
            }

            // Crear índices para el eje X
            double[] xValues = Enumerable.Range(0, dates.Count).Select(i => (double)i).ToArray();

            // Gráfica 1: Comparación del dólar y el euro
            dolarvsEuro.Reset();
            var dollarScatter = dolarvsEuro.Plot.Add.Scatter(xValues, dollarValues.ToArray());
            dollarScatter.Label = "Dólar";
            var euroScatter = dolarvsEuro.Plot.Add.Scatter(xValues, euroValues.ToArray());
            euroScatter.Label = "Euro";
            dolarvsEuro.Plot.Title("Comparación Dólar vs Euro");
            dolarvsEuro.Plot.XLabel("Índice");
            dolarvsEuro.Plot.YLabel("Valor");
            dolarvsEuro.Plot.ShowLegend();
            dolarvsEuro.Refresh();

            // Gráfica 2: Valor del dólar en una gráfica de barras
            barPlot.Reset();
            barPlot.Plot.Add.Bars(dollarValues.ToArray()); // Agregar barras sin barWidth
            barPlot.Plot.HideLegend();
            barPlot.Plot.Title("Valor del Dólar (Gráfica de Barras)");
            barPlot.Plot.XLabel("Índice");
            barPlot.Plot.YLabel("Valor");

            // Configurar etiquetas personalizadas para el eje X
            //string[] tickLabels = dates.Select(d => d.ToString("yyyy-MM-dd")).ToArray();
            //double[] tickPositions = xValues;
            //barPlot.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(tickPositions, tickLabels);

            barPlot.Refresh();

            // Gráfica 3: Gráfica de dispersión (scatter plot)
            formsPlot1.Reset();
            var scatter = formsPlot1.Plot.Add.Scatter(xValues, dollarValues.ToArray());
            scatter.Label = "Tipo de Cambio";
            formsPlot1.Plot.Title("Tipo de Cambio Peso a Dólar");
            formsPlot1.Plot.XLabel("Índice");
            formsPlot1.Plot.YLabel("Valor");
            formsPlot1.Refresh();
        }
    }
}
