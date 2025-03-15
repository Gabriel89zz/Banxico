using Newtonsoft.Json.Linq;
using ScottPlot;

namespace Banxico
{
    public partial class Graphic : Form
    {
        private string apiKey = "ec4f2878f9a5310d31989587f6fda1f43a883e1c0c95e032ddb1e1cc05034558";
        public Graphic()
        {
            InitializeComponent();
        }

        private async void btnConsult_Click(object sender, EventArgs e)
        {
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
                // Realizar la consulta a la API de Banxico
                string url = $"https://www.banxico.org.mx/SieAPIRest/service/v1/series/SF43718/datos/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}?token={apiKey}";
                var data = await FetchDataFromApi(url);

                // Mostrar los resultados en la gráfica
                DisplayGraph(data);
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

        private void DisplayGraph(JObject data)
        {
            // Limpiar la gráfica
            formsPlot1.Reset();

            // Extraer los datos de la respuesta JSON
            var observations = data["bmx"]["series"][0]["datos"];
            List<DateTime> dates = new List<DateTime>();
            List<double> values = new List<double>();

            foreach (var obs in observations)
            {
                dates.Add(DateTime.Parse(obs["fecha"].ToString()));
                values.Add(double.Parse(obs["dato"].ToString()));
            }

            // Crear la gráfica
            if (dates.Count > 0 && values.Count > 0)
            {
                // Convertir las fechas a números (necesario para ScottPlot)
                double[] dateNumbers = dates.Select(d => d.ToOADate()).ToArray();
                double[] exchangeRates = values.ToArray();

                // Añadir los datos a la gráfica
                var scatter = formsPlot1.Plot.Add.Scatter(dateNumbers, exchangeRates);
                scatter.Label = "Tipo de Cambio";

                // Configurar el título y las etiquetas de los ejes
                formsPlot1.Plot.Title("Tipo de Cambio Peso a Dólar");
                formsPlot1.Plot.XLabel("Fecha");
                formsPlot1.Plot.YLabel("Valor");

                // Configurar el eje X para mostrar fechas usando DateTimeTicksBottom
                formsPlot1.Plot.Axes.DateTimeTicksBottom(format: "yyyy-MM-dd");

                // Ajustar automáticamente los ejes
                formsPlot1.Plot.AxisAuto();

                // Renderizar la gráfica
                formsPlot1.Refresh();
            }
            else
            {
                MessageBox.Show("No hay datos disponibles para el rango de fechas seleccionado.", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
