namespace BookRatingApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.txtSearchBooks = new System.Windows.Forms.TextBox();
            this.btnSearchBooks = new System.Windows.Forms.Button();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.btnEditBook = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.btnExportBooks = new System.Windows.Forms.Button();
            this.tabMyReviews = new System.Windows.Forms.TabPage();
            this.btnExportReviews = new System.Windows.Forms.Button();
            this.dgvMyReviews = new System.Windows.Forms.DataGridView();
            this.btnDeleteReview = new System.Windows.Forms.Button();
            this.btnEditReview = new System.Windows.Forms.Button();
            this.btnAddReview = new System.Windows.Forms.Button();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnExportUsers = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.tabMyReviews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyReviews)).BeginInit();
            this.tabAccount.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBooks);
            this.tabControl.Controls.Add(this.tabMyReviews);
            this.tabControl.Controls.Add(this.tabAccount);
            this.tabControl.Controls.Add(this.tabUsers);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.txtSearchBooks);
            this.tabBooks.Controls.Add(this.btnSearchBooks);
            this.tabBooks.Controls.Add(this.btnDeleteBook);
            this.tabBooks.Controls.Add(this.btnEditBook);
            this.tabBooks.Controls.Add(this.btnAddBook);
            this.tabBooks.Controls.Add(this.dgvBooks);
            this.tabBooks.Controls.Add(this.btnExportBooks);
            this.tabBooks.Location = new System.Drawing.Point(4, 22);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabBooks.Size = new System.Drawing.Size(792, 424);
            this.tabBooks.TabIndex = 0;
            this.tabBooks.Text = "Книги";
            this.tabBooks.UseVisualStyleBackColor = true;
            // 
            // txtSearchBooks
            // 
            this.txtSearchBooks.Location = new System.Drawing.Point(6, 35);
            this.txtSearchBooks.Name = "txtSearchBooks";
            this.txtSearchBooks.Size = new System.Drawing.Size(200, 20);
            this.txtSearchBooks.TabIndex = 5;
            this.txtSearchBooks.Text = "Введите название книги";
            // 
            // btnSearchBooks
            // 
            this.btnSearchBooks.Location = new System.Drawing.Point(212, 35);
            this.btnSearchBooks.Name = "btnSearchBooks";
            this.btnSearchBooks.Size = new System.Drawing.Size(75, 23);
            this.btnSearchBooks.TabIndex = 6;
            this.btnSearchBooks.Text = "Поиск";
            this.btnSearchBooks.UseVisualStyleBackColor = true;
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Location = new System.Drawing.Point(270, 6);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteBook.TabIndex = 4;
            this.btnDeleteBook.Text = "Удалить";
            this.btnDeleteBook.UseVisualStyleBackColor = true;
            this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
            // 
            // btnEditBook
            // 
            this.btnEditBook.Location = new System.Drawing.Point(189, 6);
            this.btnEditBook.Name = "btnEditBook";
            this.btnEditBook.Size = new System.Drawing.Size(75, 23);
            this.btnEditBook.TabIndex = 3;
            this.btnEditBook.Text = "Изменить";
            this.btnEditBook.UseVisualStyleBackColor = true;
            this.btnEditBook.Click += new System.EventHandler(this.btnEditBook_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(108, 6);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(75, 23);
            this.btnAddBook.TabIndex = 2;
            this.btnAddBook.Text = "Добавить";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // dgvBooks
            // 
            this.dgvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(6, 64);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.Size = new System.Drawing.Size(780, 354);
            this.dgvBooks.TabIndex = 1;
            // 
            // btnExportBooks
            // 
            this.btnExportBooks.Location = new System.Drawing.Point(6, 6);
            this.btnExportBooks.Name = "btnExportBooks";
            this.btnExportBooks.Size = new System.Drawing.Size(96, 23);
            this.btnExportBooks.TabIndex = 0;
            this.btnExportBooks.Text = "Экспорт в CSV";
            this.btnExportBooks.UseVisualStyleBackColor = true;
            this.btnExportBooks.Click += new System.EventHandler(this.btnExportBooks_Click);
            // 
            // tabMyReviews
            // 
            this.tabMyReviews.Controls.Add(this.btnExportReviews);
            this.tabMyReviews.Controls.Add(this.dgvMyReviews);
            this.tabMyReviews.Controls.Add(this.btnDeleteReview);
            this.tabMyReviews.Controls.Add(this.btnEditReview);
            this.tabMyReviews.Controls.Add(this.btnAddReview);
            this.tabMyReviews.Location = new System.Drawing.Point(4, 22);
            this.tabMyReviews.Name = "tabMyReviews";
            this.tabMyReviews.Padding = new System.Windows.Forms.Padding(3);
            this.tabMyReviews.Size = new System.Drawing.Size(792, 424);
            this.tabMyReviews.TabIndex = 1;
            this.tabMyReviews.Text = "Отзывы";
            this.tabMyReviews.UseVisualStyleBackColor = true;
            // 
            // btnExportReviews
            // 
            this.btnExportReviews.Location = new System.Drawing.Point(255, 6);
            this.btnExportReviews.Name = "btnExportReviews";
            this.btnExportReviews.Size = new System.Drawing.Size(96, 23);
            this.btnExportReviews.TabIndex = 5;
            this.btnExportReviews.Text = "Экспорт в CSV";
            this.btnExportReviews.UseVisualStyleBackColor = true;
            this.btnExportReviews.Click += new System.EventHandler(this.btnExportReviews_Click);
            // 
            // dgvMyReviews
            // 
            this.dgvMyReviews.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMyReviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyReviews.Location = new System.Drawing.Point(6, 35);
            this.dgvMyReviews.Name = "dgvMyReviews";
            this.dgvMyReviews.Size = new System.Drawing.Size(780, 383);
            this.dgvMyReviews.TabIndex = 4;
            // 
            // btnDeleteReview
            // 
            this.btnDeleteReview.Location = new System.Drawing.Point(174, 6);
            this.btnDeleteReview.Name = "btnDeleteReview";
            this.btnDeleteReview.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteReview.TabIndex = 3;
            this.btnDeleteReview.Text = "Удалить";
            this.btnDeleteReview.UseVisualStyleBackColor = true;
            this.btnDeleteReview.Click += new System.EventHandler(this.btnDeleteReview_Click);
            // 
            // btnEditReview
            // 
            this.btnEditReview.Location = new System.Drawing.Point(93, 6);
            this.btnEditReview.Name = "btnEditReview";
            this.btnEditReview.Size = new System.Drawing.Size(75, 23);
            this.btnEditReview.TabIndex = 2;
            this.btnEditReview.Text = "Изменить";
            this.btnEditReview.UseVisualStyleBackColor = true;
            this.btnEditReview.Click += new System.EventHandler(this.btnEditReview_Click);
            // 
            // btnAddReview
            // 
            this.btnAddReview.Location = new System.Drawing.Point(6, 6);
            this.btnAddReview.Name = "btnAddReview";
            this.btnAddReview.Size = new System.Drawing.Size(81, 23);
            this.btnAddReview.TabIndex = 1;
            this.btnAddReview.Text = "Добавить";
            this.btnAddReview.UseVisualStyleBackColor = true;
            this.btnAddReview.Click += new System.EventHandler(this.btnAddReview_Click);
            // 
            // tabAccount
            // 
            this.tabAccount.Controls.Add(this.btnLogout);
            this.tabAccount.Controls.Add(this.btnChangePassword);
            this.tabAccount.Controls.Add(this.txtConfirmPassword);
            this.tabAccount.Controls.Add(this.txtNewPassword);
            this.tabAccount.Controls.Add(this.txtCurrentPassword);
            this.tabAccount.Controls.Add(this.label3);
            this.tabAccount.Controls.Add(this.label2);
            this.tabAccount.Controls.Add(this.label1);
            this.tabAccount.Location = new System.Drawing.Point(4, 22);
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Size = new System.Drawing.Size(792, 424);
            this.tabAccount.TabIndex = 2;
            this.tabAccount.Text = "Аккаунт";
            this.tabAccount.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(276, 90);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 23);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Выйти из аккаунта";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(150, 90);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(120, 23);
            this.btnChangePassword.TabIndex = 6;
            this.btnChangePassword.Text = "Изменить пароль";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(150, 64);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 20);
            this.txtConfirmPassword.TabIndex = 5;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(150, 38);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(200, 20);
            this.txtNewPassword.TabIndex = 4;
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(150, 12);
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.PasswordChar = '*';
            this.txtCurrentPassword.Size = new System.Drawing.Size(200, 20);
            this.txtCurrentPassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Подтвердите пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Новый пароль:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текущий пароль:";
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.dgvUsers);
            this.tabUsers.Controls.Add(this.btnExportUsers);
            this.tabUsers.Location = new System.Drawing.Point(4, 22);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Size = new System.Drawing.Size(792, 424);
            this.tabUsers.TabIndex = 3;
            this.tabUsers.Text = "Пользователи";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // dgvUsers
            // 
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(3, 32);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(786, 389);
            this.dgvUsers.TabIndex = 1;
            // 
            // btnExportUsers
            // 
            this.btnExportUsers.Location = new System.Drawing.Point(3, 3);
            this.btnExportUsers.Name = "btnExportUsers";
            this.btnExportUsers.Size = new System.Drawing.Size(120, 23);
            this.btnExportUsers.TabIndex = 0;
            this.btnExportUsers.Text = "Экспорт в CSV";
            this.btnExportUsers.UseVisualStyleBackColor = true;
            this.btnExportUsers.Click += new System.EventHandler(this.btnExportUsers_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Рейтинг книг";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabBooks.ResumeLayout(false);
            this.tabBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.tabMyReviews.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyReviews)).EndInit();
            this.tabAccount.ResumeLayout(false);
            this.tabAccount.PerformLayout();
            this.tabUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.TextBox txtSearchBooks;
        private System.Windows.Forms.Button btnSearchBooks;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.Button btnEditBook;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button btnExportBooks;
        private System.Windows.Forms.TabPage tabMyReviews;
        private System.Windows.Forms.Button btnExportReviews;
        private System.Windows.Forms.DataGridView dgvMyReviews;
        private System.Windows.Forms.Button btnDeleteReview;
        private System.Windows.Forms.Button btnEditReview;
        private System.Windows.Forms.Button btnAddReview;
        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnExportUsers;
    }
}