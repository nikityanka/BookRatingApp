using Npgsql;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRatingApp
{
    public partial class RegisterForm : Form
    {
        private readonly DatabaseHelper dbHelper;

        public string Email => txtEmail.Text.Trim();

        public RegisterForm(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            this.dbHelper = dbHelper;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            try
            {
                await RegisterUserAsync(username, email, password);
                MessageBox.Show("Регистрация успешна! Теперь вы можете войти.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}");
            }
        }

        private async Task RegisterUserAsync(string username, string email, string password)
        {
            using (var conn = await dbHelper.OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT book_rating.register_user(@username, @email, @password)", conn))
            {
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("password", password);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}