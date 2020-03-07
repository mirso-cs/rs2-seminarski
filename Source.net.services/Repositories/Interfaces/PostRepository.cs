﻿using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;

namespace Source.net.services.Repositories.Interfaces
{
    public interface PostRepository : Repository<Post, PostFilters>
    {
    }
}
