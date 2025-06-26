using Npgsql;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRatingApp
{
    public partial class MainForm : Form
    {
        private readonly User currentUser;
        private readonly DatabaseHelper dbHelper;
        private DataTable booksData;
        private DataTable reviewsData;

        public MainForm(User user, DatabaseHelper dbHelper)
        {
            InitializeComponent();
            currentUser = user;
            this.dbHelper = dbHelper;
            ConfigureUI();
        }

        private void ConfigureUI()
        {
            Text = $"Рейтинг книг | Пользователь: {currentUser.Username}";

            if (currentUser.RoleId != 1)
            {
                tabControl.TabPages.Remove(tabUsers);
                btnAddBook.Visible = false;
                btnEditBook.Visible = false;
                btnDeleteBook.Visible = false;
            }

            dgvBooks.AutoGenerateColumns = true;
            dgvMyReviews.AutoGenerateColumns = true;
            dgvUsers.AutoGenerateColumns = true;

            btnSearchBooks.Click += new System.EventHandler(this.btnSearchBooks_Click);
            txtSearchBooks.TextChanged += new System.EventHandler(this.txtSearchBooks_TextChanged);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                booksData = await dbHelper.GetBooksAsync();
                dgvBooks.DataSource = booksData;
                dgvBooks.Columns["author_id"].Visible = false;

                reviewsData = await dbHelper.GetAllReviewsAsync();
                dgvMyReviews.DataSource = reviewsData;

                if (currentUser.RoleId == 1)
                {
                    dgvUsers.DataSource = await dbHelper.GetAllUsersAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private async void btnAddBook_Click(object sender, EventArgs e)
        {
            using (var form = new BookForm(dbHelper))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadDataAsync();
                }
            }
        }

        private async void btnEditBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null) return;

            int bookId = (int)dgvBooks.CurrentRow.Cells["id"].Value;
            string title = dgvBooks.CurrentRow.Cells["title"].Value.ToString();
            int authorId = (int)dgvBooks.CurrentRow.Cells["author_id"].Value;
            int? publicationYear = null;
            if (dgvBooks.CurrentRow.Cells["publication_year"].Value != DBNull.Value)
            {
                publicationYear = Convert.ToInt32(dgvBooks.CurrentRow.Cells["publication_year"].Value);
            }
            string description = dgvBooks.CurrentRow.Cells["description"].Value?.ToString();

            using (var form = new BookForm(bookId, title, authorId, publicationYear, description, dbHelper))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadDataAsync();
                }
            }
        }

        private async void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null) return;

            int bookId = (int)dgvBooks.CurrentRow.Cells["id"].Value;
            if (MessageBox.Show("Удалить эту книгу?", "Подтверждение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await dbHelper.DeleteBookAsync(bookId);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}");
                }
            }
        }

        private async void btnSearchBooks_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchBooks.Text.Trim();
            try
            {
                using (var conn = await dbHelper.OpenConnectionAsync())
                using (var cmd = new NpgsqlCommand("SELECT * FROM book_rating.find_books_by_title(@searchText)", conn))
                {
                    cmd.Parameters.AddWithValue("searchText", searchText);
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        booksData = dt;
                        dgvBooks.DataSource = booksData;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}");
            }
        }

        private void txtSearchBooks_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchBooks.Text.Trim()))
            {
                LoadDataAsync();
            }
        }

        private void btnExportBooks_Click(object sender, EventArgs e)
        {
            if (booksData == null || booksData.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV файлы (*.csv)|*.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dbHelper.ExportToCsv(booksData, sfd.FileName);
                    MessageBox.Show("Данные успешно экспортированы");
                }
            }
        }

        private async void btnAddReview_Click(object sender, EventArgs e)
        {
            using (var form = new ReviewForm(currentUser.Id, dbHelper))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadDataAsync();
                }
            }
        }

        private async void btnEditReview_Click(object sender, EventArgs e)
        {
            if (dgvMyReviews.CurrentRow == null) return;

            int userId = (int)dgvMyReviews.CurrentRow.Cells["user_id"].Value;
            if (userId != currentUser.Id && currentUser.RoleId != 1)
            {
                MessageBox.Show("Вы можете редактировать только свои отзывы");
                return;
            }

            int reviewId = (int)dgvMyReviews.CurrentRow.Cells["id"].Value;
            int rating = Convert.ToInt32(dgvMyReviews.CurrentRow.Cells["rating"].Value);
            string comment = dgvMyReviews.CurrentRow.Cells["comment"].Value?.ToString();

            using (var form = new ReviewForm(reviewId, rating, comment, dbHelper))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await LoadDataAsync();
                }
            }
        }

        private async void btnDeleteReview_Click(object sender, EventArgs e)
        {
            if (dgvMyReviews.CurrentRow == null) return;

            int userId = (int)dgvMyReviews.CurrentRow.Cells["user_id"].Value;
            if (userId != currentUser.Id && currentUser.RoleId != 1)
            {
                MessageBox.Show("Вы можете удалять только свои отзывы");
                return;
            }

            int reviewId = (int)dgvMyReviews.CurrentRow.Cells["id"].Value;
            if (MessageBox.Show("Удалить этот отзыв?", "Подтверждение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await dbHelper.DeleteReviewAsync(reviewId);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}");
                }
            }
        }

        private void btnExportReviews_Click(object sender, EventArgs e)
        {
            if (reviewsData == null || reviewsData.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV файлы (*.csv)|*.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dbHelper.ExportToCsv(reviewsData, sfd.FileName);
                    MessageBox.Show("Данные успешно экспортированы");
                }
            }
        }

        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            string current = txtCurrentPassword.Text;
            string newPass = txtNewPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (newPass != confirm)
            {
                MessageBox.Show("Новый пароль и подтверждение не совпадают");
                return;
            }

            try
            {
                if (await dbHelper.ChangePasswordAsync(currentUser.Id, current, newPass))
                {
                    MessageBox.Show("Пароль успешно изменен");
                    txtCurrentPassword.Text = "";
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
                else
                {
                    MessageBox.Show("Не удалось изменить пароль. Проверьте текущий пароль.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выйти из аккаунта?", "Подтверждение",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnExportUsers_Click(object sender, EventArgs e)
        {
            if (!(dgvUsers.DataSource is DataTable dt) || dt.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV файлы (*.csv)|*.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dbHelper.ExportToCsv(dt, sfd.FileName);
                    MessageBox.Show("Данные успешно экспортированы");
                }
            }
        }
    }
}