namespace BookRatingApp
{
    partial class ReviewForm
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
            this.cmbBooks = new System.Windows.Forms.ComboBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.numRating = new System.Windows.Forms.NumericUpDown();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbBooks
            // 
            this.cmbBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBooks.FormattingEnabled = true;
            this.cmbBooks.Location = new System.Drawing.Point(100, 10);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new System.Drawing.Size(300, 21);
            this.cmbBooks.TabIndex = 0;
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Location = new System.Drawing.Point(10, 13);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(40, 13);
            this.lblBook.TabIndex = 1;
            this.lblBook.Text = "Книга:";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Location = new System.Drawing.Point(10, 40);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(48, 13);
            this.lblRating.TabIndex = 2;
            this.lblRating.Text = "Оценка:";
            // 
            // numRating
            // 
            this.numRating.Location = new System.Drawing.Point(100, 38);
            this.numRating.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRating.Name = "numRating";
            this.numRating.Size = new System.Drawing.Size(50, 20);
            this.numRating.TabIndex = 3;
            this.numRating.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(10, 67);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(80, 13);
            this.lblComment.TabIndex = 4;
            this.lblComment.Text = "Комментарий:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(100, 64);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(300, 100);
            this.txtComment.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(325, 170);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 203);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.numRating);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.cmbBooks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReviewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить отзыв";
            this.Load += new System.EventHandler(this.ReviewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox cmbBooks;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.NumericUpDown numRating;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnSave;
    }
}