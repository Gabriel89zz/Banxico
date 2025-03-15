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
            // Get the selected dates
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            // Validate that the start date is less than or equal to the end date
            if (startDate > endDate)
            {
                MessageBox.Show("The start date must be less than or equal to the end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Perform the query to the Banxico API
                string url = $"https://www.banxico.org.mx/SieAPIRest/service/v1/series/SF43718/datos/{startDate:yyyy-MM-dd}/{endDate:yyyy-MM-dd}?token={apiKey}";
                var data = await FetchDataFromApi(url);

                // Display the results in the DataGridView
                DisplayResults(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error querying the API: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<JObject> FetchDataFromApi(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Throws an exception if the response is not successful
                string responseBody = await response.Content.ReadAsStringAsync();
                return JObject.Parse(responseBody); // Parse the JSON response
            }
        }

        private void DisplayResults(JObject data)
        {
            // Clear the DataGridView
            dgvResults.Rows.Clear();
            dgvResults.Columns.Clear();

            // Set up the columns of the DataGridView
            dgvResults.Columns.Add("date", "Date");
            dgvResults.Columns.Add("value", "Exchange Rate");

            // Extract data from the JSON response
            var observations = data["bmx"]["series"][0]["datos"];
            foreach (var obs in observations)
            {
                string date = obs["fecha"].ToString();
                string value = obs["dato"].ToString();

                // Add a row to the DataGridView
                dgvResults.Rows.Add(date, value);
            }
        }
    }
}
