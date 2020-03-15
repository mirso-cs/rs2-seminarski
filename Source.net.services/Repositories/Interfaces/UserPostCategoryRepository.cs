using Microsoft.EntityFrameworkCore.Query.Internal;
using Source.net.infrastructure.Entities;
using Source.net.infrastructure.SearchFilters;
using Source.net.infrastructure.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Source.net.services.Repositories.Interfaces
{
    public interface UserPostCategoryRepository: Repository<UserPostCategory, UserPostFilters>
    {
        IEnumerable<UserPostCategoryAggregate> GetAggregate(UserPostFilters filter);
    }
}
