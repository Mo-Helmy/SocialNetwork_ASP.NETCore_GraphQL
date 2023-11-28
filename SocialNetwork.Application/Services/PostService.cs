﻿using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Data;
using SocialNetwork.Infrastructure.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IGenericRepository<Post> _postRepo;

        public PostService(IGenericRepository<Post> postRepo)
        {
            this._postRepo = postRepo;
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Post> GetPosts(AppDbContext dbContext)
        {
            return dbContext.Set<Post>();
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers(AppDbContext dbContext)
        {
            return dbContext.Set<User>();

        }

    }
}
