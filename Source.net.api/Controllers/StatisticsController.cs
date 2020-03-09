using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Source.net.infrastructure.Views;
using Source.net.services.Repositories.Interfaces;
using System.Collections.Generic;

namespace Source.net.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatisticsController : ControllerBase
    {
        private readonly Statistics statistics;

        public StatisticsController(Statistics statistics)
        {
            this.statistics = statistics;
        }

        [HttpGet("category")]
        public TotalCount GetCategoryCounts()
        {
            return statistics.GetCategoryCount();
        }

        [HttpGet("tag")]
        public TotalCount GetTagCount()
        {
            return statistics.GetTagCount();
        }

        [HttpGet("post")]
        public TotalCount GetPostCount()
        {
            return statistics.GetPostCount();
        }

        [HttpGet("post/{id}")]
        public TotalCount GetPostCountForUser(int id)
        {
            return statistics.GetPostCountForUser(id);
        }

        [HttpGet("user/{id}")]
        public AverageOf GetAverageUserRating(int id)
        {
            return statistics.GetAverageUserRating(id);
        }

        [HttpGet("user/{id}/posts")]
        public IEnumerable<PostView> GetUserBestPost(int id)
        {
            return statistics.GetUserBestPost(id);
        }

        [HttpGet("chart/post")]
        public IEnumerable<ChartItem> GetPostChart()
        {
            return statistics.GetPostChartData();
        }

        [HttpGet("chart/user")]
        public IEnumerable<ChartItem> GetUserChart()
        {
            return statistics.GetUserChartData();
        }
    }
}