using Microsoft.EntityFrameworkCore.Query.Internal;
using Source.net.infrastructure.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Source.net.services.Repositories.Interfaces
{
    public interface Statistics
    {
        TotalCount GetCategoryCount();
        TotalCount GetTagCount();
        TotalCount GetPostCount();
        TotalCount GetPostCountForUser(int userId);
        AverageOf GetAverageUserRating(int userId);
        IEnumerable<PostView> GetUserBestPost(int userId);
        IEnumerable<ChartItem> GetUserChartData();
        IEnumerable<ChartItem> GetPostChartData();
    }
}
