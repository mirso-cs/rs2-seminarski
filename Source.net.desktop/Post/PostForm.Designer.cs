namespace Source.net.desktop.Post
{
    partial class PostForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.textSubtitle = new System.Windows.Forms.TextBox();
            this.textContent = new System.Windows.Forms.RichTextBox();
            this.thumbnail = new System.Windows.Forms.PictureBox();
            this.selectCategory = new System.Windows.Forms.ComboBox();
            this.textTags = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.cbxPublished = new System.Windows.Forms.CheckBox();
            this.uploadButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.BtnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // textTitle
            // 
            this.textTitle.Location = new System.Drawing.Point(9, 69);
            this.textTitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(340, 20);
            this.textTitle.TabIndex = 0;
            this.textTitle.Validating += new System.ComponentModel.CancelEventHandler(this.textTitle_Validating);
            // 
            // textSubtitle
            // 
            this.textSubtitle.Location = new System.Drawing.Point(9, 115);
            this.textSubtitle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textSubtitle.Name = "textSubtitle";
            this.textSubtitle.Size = new System.Drawing.Size(340, 20);
            this.textSubtitle.TabIndex = 1;
            this.textSubtitle.Validating += new System.ComponentModel.CancelEventHandler(this.textSubtitle_Validating);
            // 
            // textContent
            // 
            this.textContent.Location = new System.Drawing.Point(9, 243);
            this.textContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textContent.Name = "textContent";
            this.textContent.Size = new System.Drawing.Size(708, 377);
            this.textContent.TabIndex = 2;
            this.textContent.Text = "";
            this.textContent.Validating += new System.ComponentModel.CancelEventHandler(this.textContent_Validating);
            // 
            // thumbnail
            // 
            this.thumbnail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thumbnail.Location = new System.Drawing.Point(370, 70);
            this.thumbnail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.thumbnail.Name = "thumbnail";
            this.thumbnail.Size = new System.Drawing.Size(346, 146);
            this.thumbnail.TabIndex = 3;
            this.thumbnail.TabStop = false;
            // 
            // selectCategory
            // 
            this.selectCategory.FormattingEnabled = true;
            this.selectCategory.Location = new System.Drawing.Point(9, 158);
            this.selectCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.selectCategory.Name = "selectCategory";
            this.selectCategory.Size = new System.Drawing.Size(340, 21);
            this.selectCategory.TabIndex = 4;
            this.selectCategory.Validating += new System.ComponentModel.CancelEventHandler(this.selectCategory_Validating);
            // 
            // textTags
            // 
            this.textTags.Location = new System.Drawing.Point(9, 197);
            this.textTags.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textTags.Name = "textTags";
            this.textTags.Size = new System.Drawing.Size(340, 20);
            this.textTags.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Post";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 99);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Subtitle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Thumbnail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 141);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Category";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 180);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tag";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 227);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Content";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(571, 632);
            this.submitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(145, 31);
            this.submitButton.TabIndex = 13;
            this.submitButton.Text = "Save";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cbxPublished
            // 
            this.cbxPublished.AutoSize = true;
            this.cbxPublished.Location = new System.Drawing.Point(14, 632);
            this.cbxPublished.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxPublished.Name = "cbxPublished";
            this.cbxPublished.Size = new System.Drawing.Size(72, 17);
            this.cbxPublished.TabIndex = 14;
            this.cbxPublished.Text = "Published";
            this.cbxPublished.UseVisualStyleBackColor = true;
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(466, 41);
            this.uploadButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(76, 19);
            this.uploadButton.TabIndex = 15;
            this.uploadButton.Text = "Browse";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(397, 632);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(145, 31);
            this.BtnDelete.TabIndex = 16;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // PostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 742);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.cbxPublished);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textTags);
            this.Controls.Add(this.selectCategory);
            this.Controls.Add(this.thumbnail);
            this.Controls.Add(this.textContent);
            this.Controls.Add(this.textSubtitle);
            this.Controls.Add(this.textTitle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PostForm";
            this.Text = "Post";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PostForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.TextBox textSubtitle;
        private System.Windows.Forms.RichTextBox textContent;
        private System.Windows.Forms.PictureBox thumbnail;
        private System.Windows.Forms.ComboBox selectCategory;
        private System.Windows.Forms.TextBox textTags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.CheckBox cbxPublished;
        private System.Windows.Forms.Button uploadButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button BtnDelete;
    }
}