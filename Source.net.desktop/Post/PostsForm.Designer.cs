namespace Source.net.desktop.Post
{
    partial class PostsForm
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
            this.postsGrid = new System.Windows.Forms.DataGridView();
            this.dateTimeSince = new System.Windows.Forms.DateTimePicker();
            this.dateTimeUntil = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectCategory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxPublished = new System.Windows.Forms.CheckBox();
            this.cbxUnpublished = new System.Windows.Forms.CheckBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.selectTag = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.postsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // postsGrid
            // 
            this.postsGrid.AllowUserToAddRows = false;
            this.postsGrid.AllowUserToDeleteRows = false;
            this.postsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.postsGrid.Location = new System.Drawing.Point(22, 166);
            this.postsGrid.Margin = new System.Windows.Forms.Padding(4);
            this.postsGrid.Name = "postsGrid";
            this.postsGrid.ReadOnly = true;
            this.postsGrid.RowHeadersWidth = 51;
            this.postsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.postsGrid.Size = new System.Drawing.Size(1035, 375);
            this.postsGrid.TabIndex = 0;
            this.postsGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.postsGrid_MouseDoubleClick);
            // 
            // dateTimeSince
            // 
            this.dateTimeSince.Location = new System.Drawing.Point(19, 61);
            this.dateTimeSince.Name = "dateTimeSince";
            this.dateTimeSince.Size = new System.Drawing.Size(200, 22);
            this.dateTimeSince.TabIndex = 1;
            // 
            // dateTimeUntil
            // 
            this.dateTimeUntil.Location = new System.Drawing.Point(19, 124);
            this.dateTimeUntil.Name = "dateTimeUntil";
            this.dateTimeUntil.Size = new System.Drawing.Size(200, 22);
            this.dateTimeUntil.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Since";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Until";
            // 
            // textTitle
            // 
            this.textTitle.Location = new System.Drawing.Point(532, 63);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(270, 22);
            this.textTitle.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(529, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Title";
            // 
            // selectCategory
            // 
            this.selectCategory.FormattingEnabled = true;
            this.selectCategory.Location = new System.Drawing.Point(247, 126);
            this.selectCategory.Name = "selectCategory";
            this.selectCategory.Size = new System.Drawing.Size(252, 24);
            this.selectCategory.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Category";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tag";
            // 
            // cbxPublished
            // 
            this.cbxPublished.AutoSize = true;
            this.cbxPublished.Location = new System.Drawing.Point(532, 128);
            this.cbxPublished.Name = "cbxPublished";
            this.cbxPublished.Size = new System.Drawing.Size(124, 21);
            this.cbxPublished.TabIndex = 11;
            this.cbxPublished.Text = "Only published";
            this.cbxPublished.UseVisualStyleBackColor = true;
            // 
            // cbxUnpublished
            // 
            this.cbxUnpublished.AutoSize = true;
            this.cbxUnpublished.Location = new System.Drawing.Point(662, 128);
            this.cbxUnpublished.Name = "cbxUnpublished";
            this.cbxUnpublished.Size = new System.Drawing.Size(140, 21);
            this.cbxUnpublished.TabIndex = 12;
            this.cbxUnpublished.Text = "Only unpublished";
            this.cbxUnpublished.UseVisualStyleBackColor = true;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(835, 124);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(109, 25);
            this.filterButton.TabIndex = 13;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // selectTag
            // 
            this.selectTag.FormattingEnabled = true;
            this.selectTag.Location = new System.Drawing.Point(247, 63);
            this.selectTag.Name = "selectTag";
            this.selectTag.Size = new System.Drawing.Size(252, 24);
            this.selectTag.TabIndex = 14;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(968, 124);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(89, 25);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // PostsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.selectTag);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.cbxUnpublished);
            this.Controls.Add(this.cbxPublished);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimeUntil);
            this.Controls.Add(this.dateTimeSince);
            this.Controls.Add(this.postsGrid);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PostsForm";
            this.Text = "Posts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PostsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.postsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView postsGrid;
        private System.Windows.Forms.DateTimePicker dateTimeSince;
        private System.Windows.Forms.DateTimePicker dateTimeUntil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox selectCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxPublished;
        private System.Windows.Forms.CheckBox cbxUnpublished;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.ComboBox selectTag;
        private System.Windows.Forms.Button addButton;
    }
}