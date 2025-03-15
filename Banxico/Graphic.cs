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
            List<double> values = new List<double>();

            foreach (var obs in observations)
            {
                values.Add(double.Parse(obs["dato"].ToString()));
            }

            // Crear la gráfica
            if (values.Count > 0)
            {
                // Crear un array de índices para el eje X (en lugar de fechas)
                double[] xValues = Enumerable.Range(0, values.Count).Select(i => (double)i).ToArray();
                double[] yValues = values.ToArray();

                // Añadir los datos a la gráfica
                var scatter = formsPlot1.Plot.Add.Scatter(xValues, yValues);
                scatter.Label = "Tipo de Cambio";

                // Configurar el título y las etiquetas de los ejes
                formsPlot1.Plot.Title("Tipo de Cambio Peso a Dólar");
                formsPlot1.Plot.XLabel("Índice");
                formsPlot1.Plot.YLabel("Valor");

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
