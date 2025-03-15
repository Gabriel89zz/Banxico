using Newtonsoft.Json.Linq;

namespace Banxico
{
    public partial class Dgv : Form
    {
        private string apiKey = "ec4f2878f9a5310d31989587f6fda1f43a883e1c0c95e032ddb1e1cc05034558";
        public Dgv()
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

                // Mostrar los resultados en el DataGridView
                DisplayResults(data);
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

        private void DisplayResults(JObject data)
        {
            // Limpiar el DataGridView
            dgvResults.Rows.Clear();
            dgvResults.Columns.Clear();

            // Configurar las columnas del DataGridView
            dgvResults.Columns.Add("date", "Fecha");
            dgvResults.Columns.Add("value", "Tipo de Cambio");

            // Extraer los datos de la respuesta JSON
            var observations = data["bmx"]["series"][0]["datos"];
            foreach (var obs in observations)
            {
                string date = obs["fecha"].ToString();
                string value = obs["dato"].ToString();

                // Agregar una fila al DataGridView
                dgvResults.Rows.Add(date, value);
            }
        }
    }
}
