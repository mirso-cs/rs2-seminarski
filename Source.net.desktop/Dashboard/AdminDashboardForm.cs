using Source.net.desktop.Shared;
using Source.net.infrastructure.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Source.net.desktop.Dashboard
{
    public partial class AdminDashboardForm : Form
    {
        private readonly StatisticsHttpClient http = new StatisticsHttpClient("statistics");
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private async void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            var totalPosts = await http.GetTotalCountForType("post");
            var totalCategories = await http.GetTotalCountForType("category");
            var totalTags = await http.GetTotalCountForType("tag");

            textPostCount.Text = totalPosts.Count.ToString();
            textCategoryCount.Text = totalCategories.Count.ToString();
            textTagCount.Text = totalTags.Count.ToString();

            var postChartData = await http.GetChartForType("post");
            var userChartData = await http.GetChartForType("user");

            initChart("post", postChartData);
            initChart("user", userChartData);
        }

        private void initChart(string chart, IEnumerable<ChartItem> items)
        {
            List<string> series = new List<string>();
            List<int> values = new List<int>();

            foreach (var item in items)
            {
                series.Add(item.Label);
                values.Add(item.Count);
            }

            switch (chart)
            {
                case "user":
                    userChart.Series[0].Points.DataBindXY(series, values);
                    break;

                case "post":
                    postChart.Series[0].Points.DataBindXY(series, values);
                    break;
            }
        }
    }
}
