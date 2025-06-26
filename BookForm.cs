using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRatingApp
{
    public partial class BookForm : Form
    {
        private readonly int? bookId;
        private readonly DatabaseHelper dbHelper;
        private DataTable authorsData;

        public BookForm(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            this.dbHelper = dbHelper;
            bookId = null;
        }

        public BookForm(int bookId, string title, int authorId, int? publicationYear, string description, DatabaseHelper dbHelper)
        {
            InitializeComponent();
            this.bookId = bookId;
            this.dbHelper = dbHelper;
            txtTitle.Text = title;
            numPublicationYear.Value = publicationYear ?? 2023;
            txtDescription.Text = description;
            btnSave.Text = "Обновить";
            Text = "Редактирование книги";
        }

        private async void BookForm_Load(object sender, EventArgs e)
        {
            try
            {
                authorsData = await dbHelper.GetAuthorsAsync();
                cmbAuthors.DisplayMember = "full_name";
                cmbAuthors.ValueMember = "id";
                cmbAuthors.DataSource = authorsData;

                if (bookId.HasValue)
                {
                    cmbAuthors.SelectedValue = authorsData.AsEnumerable()
                        .FirstOrDefault(row => row.Field<int>("id") == (int)cmbAuthors.SelectedValue)?["id"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки авторов: {ex.Message}");
                Close();
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            int authorId = (int)cmbAuthors.SelectedValue;
            int? publicationYear = numPublicationYear.Value > 0 ? (int?)numPublicationYear.Value : null;
            string description = txtDescription.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Название книги не может быть пустым");
                return;
            }

            try
            {
                if (bookId.HasValue)
                {
                    await dbHelper.UpdateBookAsync(bookId.Value, title, authorId, publicationYear, description);
                }
                else
                {
                    await dbHelper.AddBookAsync(title, authorId, publicationYear, description);
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }
    }
}