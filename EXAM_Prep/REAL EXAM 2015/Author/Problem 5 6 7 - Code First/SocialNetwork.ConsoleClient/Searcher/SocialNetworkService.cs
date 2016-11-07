namespace SocialNetwork.ConsoleClient.Searcher
{
    using System;
    using System.Collections;
    using System.Linq;
    using SocialNetwork.Data;

    public class SocialNetworkService : ISocialNetworkService
    {
        private SocialNetworkDbContext db;

        public SocialNetworkService()
        {
            this.db = new SocialNetworkDbContext();
        }

        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            return this.db.UserProfiles
                .Where(u => u.RegisteredOn.Year >= year)
                .Select(u => new
                {
                    u.Username,
                    u.FirstName,
                    u.LastName,
                    Images = u.Images.Count()
                })
                .ToList();
        }

        public IEnumerable GetPostsByUser(string username)
        {
            return this.db.Posts
                .Where(p => p.TaggedUsers.Any(u => u.Username == username))
                .Select(p => new
                {
                    p.PostedOn,
                    p.Content,
                    Users = p.TaggedUsers.Select(u => u.Username)
                })
                .ToList();
        }

        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            var skip = (page - 1) * pageSize;
            var take = pageSize;

            return this.db.Friendships
                .Where(f => f.Approved)
                .OrderBy(f => f.FriendsSince)
                .Skip(skip)
                .Take(take)
                .Select(f => new
                {
                    FirstUserUsername = f.FirstUser.Username,
                    FirstUserImage = f.FirstUser.Images.Select(i => i.ImageUrl).FirstOrDefault(),
                    SecondUserUsername = f.SecondUser.Username,
                    SecondUserImage = f.SecondUser.Images.Select(i => i.ImageUrl).FirstOrDefault()
                })
                .ToList();
        }

        public IEnumerable GetChatUsers(string username)
        {
            return this.db.Messages
                .Where(m => m.Friendship.FirstUser.Username == username)
                .Select(m => m.Friendship.SecondUser.Username)
                .Union(
                    this.db.Messages
                    .Where(m => m.Friendship.SecondUser.Username == username)
                    .Select(m => m.Friendship.FirstUser.Username))
                .Where(u => u != username)
                .Distinct()
                .OrderBy(u => u)
                .ToList();
        }
    }
}
