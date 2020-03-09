namespace Source.net.desktop.Dashboard
{
    partial class UserDashboardForm
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
            this.textAccType = new System.Windows.Forms.TextBox();
            this.textAvgRating = new System.Windows.Forms.TextBox();
            this.textPostCount = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.postsGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.postsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // textAccType
            // 
            this.textAccType.Location = new System.Drawing.Point(580, 66);
            this.textAccType.Name = "textAccType";
            this.textAccType.ReadOnly = true;
            this.textAccType.Size = new System.Drawing.Size(194, 22);
            this.textAccType.TabIndex = 12;
            // 
            // textAvgRating
            // 
            this.textAvgRating.Location = new System.Drawing.Point(309, 66);
            this.textAvgRating.Name = "textAvgRating";
            this.textAvgRating.ReadOnly = true;
            this.textAvgRating.Size = new System.Drawing.Size(194, 22);
            this.textAvgRating.TabIndex = 11;
            // 
            // textPostCount
            // 
            this.textPostCount.Location = new System.Drawing.Point(26, 66);
            this.textPostCount.Name = "textPostCount";
            this.textPostCount.ReadOnly = true;
            this.textPostCount.Size = new System.Drawing.Size(194, 22);
            this.textPostCount.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 22);
            this.textBox1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(577, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Account Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Average Rating";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Total Posts";
            // 
            // postsGrid
            // 
            this.postsGrid.AllowUserToAddRows = false;
            this.postsGrid.AllowUserToDeleteRows = false;
            this.postsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.postsGrid.Location = new System.Drawing.Point(26, 146);
            this.postsGrid.Name = "postsGrid";
            this.postsGrid.ReadOnly = true;
            this.postsGrid.RowHeadersWidth = 51;
            this.postsGrid.RowTemplate.Height = 24;
            this.postsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.postsGrid.Size = new System.Drawing.Size(748, 292);
            this.postsGrid.TabIndex = 13;
            this.postsGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.postsGrid_MouseDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "MOST POPULAR POSTS";
            // 
            // UserDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.postsGrid);
            this.Controls.Add(this.textAccType);
            this.Controls.Add(this.textAvgRating);
            this.Controls.Add(this.textPostCount);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserDashboardForm";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.postsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textAccType;
        private System.Windows.Forms.TextBox textAvgRating;
        private System.Windows.Forms.TextBox textPostCount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView postsGrid;
        private System.Windows.Forms.Label label4;
    }
}