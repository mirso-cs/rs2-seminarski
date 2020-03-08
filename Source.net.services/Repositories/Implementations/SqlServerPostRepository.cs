using Microsoft.EntityFrameworkCore;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.services.Database;
using Source.net.services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Source.net.services.Repositories.Implementations
{
    public class SqlServerPostRepository : MutatorRepository<Post>, PostRepository
    {
        public SqlServerPostRepository(SourceNetContext db) :
            base(db)
        {
        }

        public override Post Get(int id)
        {
            return _db.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                .Include(p => p.AssociatedTags)
                .ThenInclude(pt => pt.Tag)
                .Where(p => p.id == id)
                .FirstOrDefault();
        }

        public override IEnumerable<Post> GetAll()
        {
            return _db.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                .Include(p => p.AssociatedTags)
                .ThenInclude(pt => pt.Tag)
                .ToList();
        }

        public IEnumerable<Post> GetAll(PostFilters filter)
        {
            var query = _db.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                .Include(p => p.AssociatedTags)
                .ThenInclude(pt => pt.Tag)
                .AsQueryable();

            if (filter.OnlyPublished && !filter.OnlyUnpublished)
            {
                query = query.Where(x => x.Published);
            }

            if (filter.OnlyUnpublished && !filter.OnlyPublished)
            {
                query = query.Where(x => !x.Published);
            }

            if(!string.IsNullOrWhiteSpace(filter.Title))
            {
                query = query.Where(x => x.Title.Contains(filter.Title));
            }

            if (!string.IsNullOrWhiteSpace(filter.Tag))
            {
                query = query.Where(x => x.AssociatedTags.All(t => t.Tag.name == filter.Tag));
            }

            if (!string.IsNullOrWhiteSpace(filter.Category))
            {
                query = query.Where(x => x.Category.Name == filter.Tag);
            }

            query = query.Where(x => x.CreatedAt.Date >= filter.Since.Date);

            if (filter.Until > DateTime.MinValue && filter.Until.Date >= filter.Since.Date)
            {
                query = query.Where(x => x.CreatedAt.Date <= filter.Until.Date);
            }


            return query.ToList();
        }

    }
}
