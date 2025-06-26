using Npgsql;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRatingApp
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<NpgsqlConnection> OpenConnectionAsync()
        {
            var conn = new NpgsqlConnection(connectionString);
            await conn.OpenAsync();
            return conn;
        }

        public async Task RegisterUserAsync(string username, string email, string password)
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT book_rating.register_user(@username, @email, @password)", conn))
            {
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("password", password);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<User> AuthenticateUserAsync(string identifier, string password)
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT * FROM book_rating.authenticate_user(@identifier, @password)", conn))
            {
                cmd.Parameters.AddWithValue("identifier", identifier);
                cmd.Parameters.AddWithValue("password", password);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new User(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetInt32(3)
                        );
                    }
                }
            }
            return null;
        }

        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT book_rating.change_password(@userId, @current, @new)", conn))
            {
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.Parameters.AddWithValue("current", currentPassword);
                cmd.Parameters.AddWithValue("new", newPassword);

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public async Task<DataTable> GetBooksAsync()
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT * FROM book_rating.book_ratings_summary", conn))
            using (var adapter = new NpgsqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public async Task<DataTable> GetAuthorsAsync()
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT id, full_name FROM book_rating.authors", conn))
            using (var adapter = new NpgsqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public async Task AddBookAsync(string title, int authorId, int? publicationYear, string description)
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT book_rating.add_book(@title, @authorId, @publicationYear, @description)", conn))
            {
                cmd.Parameters.AddWithValue("title", title);
                cmd.Parameters.AddWithValue("authorId", authorId);
                cmd.Parameters.AddWithValue("publicationYear", publicationYear ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("description", description ?? (object)DBNull.Value);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateBookAsync(int bookId, string title, int authorId, int? publicationYear, string description)
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT book_rating.update_book(@bookId, @title, @authorId, @publicationYear, @description)", conn))
            {
                cmd.Parameters.AddWithValue("bookId", bookId);
                cmd.Parameters.AddWithValue("title", title);
                cmd.Parameters.AddWithValue("authorId", authorId);
                cmd.Parameters.AddWithValue("publicationYear", publicationYear ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("description", description ?? (object)DBNull.Value);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT book_rating.delete_book(@bookId)", conn))
            {
                cmd.Parameters.AddWithValue("bookId", bookId);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task AddReviewAsync(int bookId, int userId, int rating, string comment)
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT book_rating.add_review(@bookId, @userId, @rating, @comment)", conn))
            {
                cmd.Parameters.AddWithValue("bookId", bookId);
                cmd.Parameters.AddWithValue("userId", userId);
                cmd.Parameters.AddWithValue("rating", rating);
                cmd.Parameters.AddWithValue("comment", comment ?? (object)DBNull.Value);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateReviewAsync(int reviewId, int rating, string comment)
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand(
                "UPDATE book_rating.ratings " +
                "SET rating = @rating, comment = @comment " +
                "WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("id", reviewId);
                cmd.Parameters.AddWithValue("rating", rating);
                cmd.Parameters.AddWithValue("comment", comment ?? (object)DBNull.Value);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("DELETE FROM book_rating.ratings WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("id", reviewId);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task<DataTable> GetAllReviewsAsync()
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT * FROM book_rating.all_reviews", conn))
            using (var adapter = new NpgsqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public async Task<DataTable> GetAllUsersAsync()
        {
            using (var conn = await OpenConnectionAsync())
            using (var cmd = new NpgsqlCommand("SELECT id, username, email, role_id, created_at FROM book_rating.users", conn))
            using (var adapter = new NpgsqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void ExportToCsv(DataTable dataTable, string filePath)
        {
            var sb = new StringBuilder();

            var columnNames = dataTable.Columns.Cast<DataColumn>()
                .Select(col => EscapeCsvValue(col.ColumnName));
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dataTable.Rows)
            {
                var fields = row.ItemArray.Select(field => EscapeCsvValue(field?.ToString()));
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        private string EscapeCsvValue(string value)
        {
            if (string.IsNullOrEmpty(value)) return "\"\"";
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                return $"\"{value.Replace("\"", "\"\"")}\"";
            }
            return value;
        }
    }
}