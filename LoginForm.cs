using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRatingApp
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseHelper dbHelper;
        public User CurrentUser { get; private set; }

        public LoginForm(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            this.dbHelper = dbHelper;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string identifier = txtIdentifier.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(identifier) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин/email и пароль");
                return;
            }

            try
            {
                CurrentUser = await dbHelper.AuthenticateUserAsync(identifier, password);
                if (CurrentUser != null)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверные учетные данные");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка авторизации: {ex.Message}");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var registerForm = new RegisterForm(dbHelper))
            {
                if (registerForm.ShowDialog() == DialogResult.OK)
                {
                    txtIdentifier.Text = registerForm.Email;
                    txtPassword.Text = "";
                }
            }
        }
    }
}