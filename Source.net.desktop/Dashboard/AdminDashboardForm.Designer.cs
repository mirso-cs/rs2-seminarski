namespace Source.net.desktop.Dashboard
{
    partial class AdminDashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.userChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textPostCount = new System.Windows.Forms.TextBox();
            this.textCategoryCount = new System.Windows.Forms.TextBox();
            this.textTagCount = new System.Windows.Forms.TextBox();
            this.postChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postChart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Posts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Categories";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(585, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Tags";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(34, 74);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 22);
            this.textBox1.TabIndex = 3;
            // 
            // userChart
            // 
            chartArea1.Name = "ChartArea1";
            this.userChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.userChart.Legends.Add(legend1);
            this.userChart.Location = new System.Drawing.Point(617, 151);
            this.userChart.Name = "userChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.userChart.Series.Add(series1);
            this.userChart.Size = new System.Drawing.Size(352, 300);
            this.userChart.TabIndex = 6;
            this.userChart.Text = "chart1";
            // 
            // textPostCount
            // 
            this.textPostCount.Location = new System.Drawing.Point(34, 74);
            this.textPostCount.Name = "textPostCount";
            this.textPostCount.ReadOnly = true;
            this.textPostCount.Size = new System.Drawing.Size(194, 22);
            this.textPostCount.TabIndex = 3;
            // 
            // textCategoryCount
            // 
            this.textCategoryCount.Location = new System.Drawing.Point(317, 74);
            this.textCategoryCount.Name = "textCategoryCount";
            this.textCategoryCount.ReadOnly = true;
            this.textCategoryCount.Size = new System.Drawing.Size(194, 22);
            this.textCategoryCount.TabIndex = 4;
            // 
            // textTagCount
            // 
            this.textTagCount.Location = new System.Drawing.Point(588, 74);
            this.textTagCount.Name = "textTagCount";
            this.textTagCount.ReadOnly = true;
            this.textTagCount.Size = new System.Drawing.Size(194, 22);
            this.textTagCount.TabIndex = 5;
            // 
            // postChart
            // 
            chartArea2.Name = "ChartArea1";
            this.postChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.postChart.Legends.Add(legend2);
            this.postChart.Location = new System.Drawing.Point(34, 151);
            this.postChart.Name = "postChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Posts";
            this.postChart.Series.Add(series2);
            this.postChart.Size = new System.Drawing.Size(566, 365);
            this.postChart.TabIndex = 7;
            this.postChart.Text = "chart2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(614, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Users";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Daily Posts";
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 559);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.postChart);
            this.Controls.Add(this.userChart);
            this.Controls.Add(this.textTagCount);
            this.Controls.Add(this.textCategoryCount);
            this.Controls.Add(this.textPostCount);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdminDashboardForm";
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart userChart;
        private System.Windows.Forms.TextBox textPostCount;
        private System.Windows.Forms.TextBox textCategoryCount;
        private System.Windows.Forms.TextBox textTagCount;
        private System.Windows.Forms.DataVisualization.Charting.Chart postChart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}