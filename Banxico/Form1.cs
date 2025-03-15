namespace Banxico
{
    public partial class Form1 : Form
    {
        private string correctUsername = "ichigo";
        private string correctPassword = "bankai";
        public Form1()
        {
            InitializeComponent();

            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate credentials
            if (username == correctUsername && password == correctPassword)
            {
                MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //open the menu form
                Menu menu = new Menu();
                menu.Show();

                // Hide the login form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Show text
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Hide text
            }
        }

    }
}
