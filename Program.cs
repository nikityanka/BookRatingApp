using System;
using System.Windows.Forms;

namespace BookRatingApp
{
    static class Program
    {
        private const string ConnectionString =
            "Host=172.20.7.53;Username=st2991;Password=pwd2991;Database=db2991_04;SearchPath=book_rating";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var dbHelper = new DatabaseHelper(ConnectionString);

            while (true)
            {
                using (var loginForm = new LoginForm(dbHelper))
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }

                    using (var mainForm = new MainForm(loginForm.CurrentUser, dbHelper))
                    {
                        if (mainForm.ShowDialog() != DialogResult.Cancel)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}