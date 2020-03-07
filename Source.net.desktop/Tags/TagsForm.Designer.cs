namespace Source.net.desktop.Tags
{
    partial class TagsForm
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
            this.tagsGrid = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.textName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.filterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tagsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tagsGrid
            // 
            this.tagsGrid.AllowUserToAddRows = false;
            this.tagsGrid.AllowUserToDeleteRows = false;
            this.tagsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tagsGrid.Location = new System.Drawing.Point(13, 96);
            this.tagsGrid.Name = "tagsGrid";
            this.tagsGrid.ReadOnly = true;
            this.tagsGrid.RowHeadersWidth = 51;
            this.tagsGrid.RowTemplate.Height = 24;
            this.tagsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tagsGrid.Size = new System.Drawing.Size(775, 342);
            this.tagsGrid.TabIndex = 0;
            this.tagsGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tagsGrid_MouseDoubleClick);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(712, 61);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(13, 61);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(163, 22);
            this.textName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(183, 61);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(75, 23);
            this.filterButton.TabIndex = 4;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // TagsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.tagsGrid);
            this.Name = "TagsForm";
            this.Text = "Tags";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TagsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tagsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tagsGrid;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button filterButton;
    }
}