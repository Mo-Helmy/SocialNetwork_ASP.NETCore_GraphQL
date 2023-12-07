using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.GraphQL
{
    public class BaseQuery
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Profile> GetProfiles(AppDbContext dbContext)
        {
            return dbContext.Profiles;
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Profile> GetProfileById(string profileId, AppDbContext dbContext)
        {
            return dbContext.Profiles.Where(x => x.ProfileId == profileId);
        }

        [UseProjection]
        public IQueryable<Chat> GetChats(AppDbContext dbContext)
        {
            return dbContext.Chats;
        }

        [UseProjection]
        public IQueryable<Chat> GetChatsByProfileId(string profileId, AppDbContext dbContext)
        {
            return dbContext.Chats.Include(x => x.Participants).Where(x => x.Participants.Any(x => x.ProfileID == profileId));
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Message> GetMessagesByChatId(int chatId, AppDbContext dbContext)
        {
            return dbContext.Messages.Where(x => x.ChatID == chatId).OrderBy(x => x.SendDate);
            
        }
    }
}
