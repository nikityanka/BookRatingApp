using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRatingApp
{
    public partial class ReviewForm : Form
    {
        private readonly int userId;
        private readonly int? reviewId;
        private readonly DatabaseHelper dbHelper;
        private DataTable booksData;

        public ReviewForm(int userId, DatabaseHelper dbHelper)
        {
            InitializeComponent();
            this.userId = userId;
            this.dbHelper = dbHelper;
            reviewId = null;
        }

        public ReviewForm(int reviewId, int rating, string comment, DatabaseHelper dbHelper)
        {
            InitializeComponent();
            this.reviewId = reviewId;
            this.dbHelper = dbHelper;
            userId = -1;

            numRating.Value = rating;
            txtComment.Text = comment;
            btnSave.Text = "Обновить";
            Text = "Редактирование отзыва";
            cmbBooks.Enabled = false;
        }

        private async void ReviewForm_Load(object sender, EventArgs e)
        {
            try
            {
                booksData = await dbHelper.GetBooksAsync();
                cmbBooks.DisplayMember = "title";
                cmbBooks.ValueMember = "id";
                cmbBooks.DataSource = booksData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки книг: {ex.Message}");
                Close();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            int rating = (int)numRating.Value;
            string comment = txtComment.Text.Trim();
            int bookId = (int)cmbBooks.SelectedValue;

            try
            {
                if (reviewId.HasValue)
                {
                    await dbHelper.UpdateReviewAsync(reviewId.Value, rating, comment);
                }
                else
                {
                    await dbHelper.AddReviewAsync(bookId, userId, rating, comment);
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }
    }
}