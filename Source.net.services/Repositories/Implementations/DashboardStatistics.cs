using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Source.net.infrastructure.Views;
using Source.net.services.Database;
using Source.net.services.Mappers;
using Source.net.services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class DashboardStatistics : Statistics
    {
        protected readonly SourceNetContext _db;
        protected readonly RoleMapper roleMapper;
        protected readonly PostMapper postMapper;

        public DashboardStatistics(PostMapper postMapper, RoleMapper roleMapper, SourceNetContext db)
        {
            _db = db;
            this.roleMapper = roleMapper;
            this.postMapper = postMapper;
        }

        public TotalCount GetCategoryCount()
        {
            return new TotalCount()
            {
                Label = "Total categories",
                Count = _db.Categories.Count()
            };
        }

        public TotalCount GetPostCount()
        {
            return new TotalCount()
            {
                Label = "Total posts",
                Count = _db.Posts.Count()
            };
        }

        public TotalCount GetPostCountForUser(int userId)
        {
            return new TotalCount()
            {
                Label = "Total posts",
                Count = _db.Posts.Where(x => x.UserId == userId).Count()
            };

        }

        public TotalCount GetTagCount()
        {
            return new TotalCount()
            {
                Label = "Total tags",
                Count = _db.Tags.Count()
            };
        }

        public IEnumerable<ChartItem> GetUserChartData()
        {
            return _db.Users.GroupBy(x => x.Role)
                .Select(group => new ChartItem() {
                    Count = group.Count(),
                    Label = roleMapper.ToString(group.Key)
                });
        }

        public IEnumerable<ChartItem> GetPostChartData()
        {
            return _db.Posts
                .Where(x => x.CreatedAt > DateTime.Now.AddDays(-7))
                .GroupBy(x => x.CreatedAt.Date.ToShortDateString())
                .Select(group => new ChartItem()
                {
                    Count = group.Count(),
                    Label = group.Key
                });
        }

        public AverageOf GetAverageUserRating(int userId)
        {
            try
            {
                var rating = _db.Ratings
                    .Where(x => x.Post.UserId == userId)
                    .Average(x => x.rating);
                return new AverageOf() { Of = "Rating", Value = rating };
            }
            catch
            {
                return new AverageOf() { Of = "Rating", Value = 0 };
            }
        }

        public IEnumerable<PostView> GetUserBestPost(int userId)
        {
            var posts = _db.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                .Include(p => p.AssociatedTags)
                .ThenInclude(pt => pt.Tag)
                .Where(x => x.UserId == userId)
                    .OrderByDescending(x => _db.Ratings
                    .Where(r => r.PostId == x.id)
                    .Average(r => (int?)r.rating) ?? 0)
                .Take(5)
                .ToList();

            var items = new List<PostView>();
            foreach (var item in posts)
            {
                items.Add(postMapper.From(item));
            }

            return items;
        }
    }
}
