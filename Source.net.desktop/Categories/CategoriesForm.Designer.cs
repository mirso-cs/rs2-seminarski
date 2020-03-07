namespace Source.net.desktop.Categories
{
    partial class CategoriesForm
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
            this.categoriesGrid = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // categoriesGrid
            // 
            this.categoriesGrid.AllowUserToAddRows = false;
            this.categoriesGrid.AllowUserToDeleteRows = false;
            this.categoriesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoriesGrid.Location = new System.Drawing.Point(12, 77);
            this.categoriesGrid.Name = "categoriesGrid";
            this.categoriesGrid.ReadOnly = true;
            this.categoriesGrid.RowHeadersWidth = 51;
            this.categoriesGrid.RowTemplate.Height = 24;
            this.categoriesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categoriesGrid.Size = new System.Drawing.Size(776, 361);
            this.categoriesGrid.TabIndex = 0;
            this.categoriesGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.categoriesGrid_MouseDoubleClick);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(713, 34);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(13, 34);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(157, 22);
            this.textName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(198, 32);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 4;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // CategoriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.categoriesGrid);
            this.Name = "CategoriesForm";
            this.Text = "Categories";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CategoriesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoriesGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView categoriesGrid;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button filterButton;
    }
}