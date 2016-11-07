namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using SocialNetwork.ConsoleClient.Models;
    using SocialNetwork.Data;
    using SocialNetwork.Models;

    public class Importer
    {
        private readonly TextWriter textWrite;

        private Importer(TextWriter textWrite)
        {
            this.textWrite = textWrite;
        }

        public static Importer Create(TextWriter textWrite)
        {
            return new Importer(textWrite);
        }

        public void Import()
        {
            var friendships = this.Deserialize<FriendshipXmlModel>("XmlFiles/Friendships.xml", "Friendships");
            this.ProcessFrienships(friendships);
            this.textWrite.WriteLine();

            var posts = this.Deserialize<PostXmlModel>("XmlFiles/Posts.xml", "Posts");
            this.ProcessPosts(posts);
            this.textWrite.WriteLine();
        }

        private IEnumerable<TModel> Deserialize<TModel>(string fileName, string rootElement)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found!", fileName);
            }

            var serializer = new XmlSerializer(typeof(List<TModel>), new XmlRootAttribute(rootElement));
            IEnumerable<TModel> result;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                result = (IEnumerable<TModel>)serializer.Deserialize(fs);
            }

            return result;
        }

        private void ProcessFrienships(IEnumerable<FriendshipXmlModel> friendships)
        {
            this.textWrite.Write("Importing friendships");

            var addedFriendships = 0;
            var db = new SocialNetworkDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            var savedUsers = new HashSet<string>();

            foreach (var friendship in friendships)
            {
                var firstUser = this.GetUser(db, friendship.FirstUser, savedUsers);
                var secondUser = this.GetUser(db, friendship.SecondUser, savedUsers);

                var newFriendship = new Friendship
                {
                    Approved = friendship.Approved,
                    FriendsSince = friendship.FriendsSince,
                    FirstUser = firstUser,
                    SecondUser = secondUser,
                };

                foreach (var message in friendship.Messages)
                {
                    db.Messages.Add(new Message
                    {
                        Author = message.Author == firstUser.Username ? firstUser : secondUser,
                        Content = message.Content,
                        Friendship = newFriendship,
                        SeenOn = message.SeenOn,
                        SentOn = message.SentOn
                    });
                }

                addedFriendships++;

                if (addedFriendships % 10 == 0)
                {
                    this.textWrite.Write(".");
                }

                db.SaveChanges();

                if (addedFriendships % 100 == 0)
                {
                    db = new SocialNetworkDbContext();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            db.Configuration.AutoDetectChangesEnabled = true;
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        private UserProfile GetUser(SocialNetworkDbContext db, UserXmlModel model, HashSet<string> addedUsersSoFar)
        {
            if (addedUsersSoFar.Contains(model.Username))
            {
                return db.UserProfiles.FirstOrDefault(u => u.Username == model.Username);
            }
            else
            {
                addedUsersSoFar.Add(model.Username);

                var user = new UserProfile
                {
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RegisteredOn = model.RegisteredOn
                };

                foreach (var image in model.Images)
                {
                    user.Images.Add(new Image
                    {
                        ImageUrl = image.ImageUrl,
                        FileExtension = image.FileExtension
                    });
                }

                db.UserProfiles.Add(user);
                db.SaveChanges();

                return user;
            }
        }

        private void ProcessPosts(IEnumerable<PostXmlModel> posts)
        {
            this.textWrite.Write("Importing posts");
            
            var addedPosts = 0;
            var db = new SocialNetworkDbContext();
            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            foreach (var post in posts)
            {
                var usernames = post.Users.Split(',');
                var users = db.UserProfiles
                    .Where(u => usernames.Contains(u.Username))
                    .ToList();

                var newPost = new Post
                {
                    PostedOn = post.PostedOn,
                    Content = post.Content
                };

                foreach (var user in users)
                {
                    newPost.TaggedUsers.Add(user);
                }

                db.Posts.Add(newPost);

                addedPosts++;

                if (addedPosts % 10 == 0)
                {
                    this.textWrite.Write(".");
                }

                if (addedPosts % 100 == 0)
                {
                    db.SaveChanges();
                    db = new SocialNetworkDbContext();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                }
            }

            db.SaveChanges();
            db.Configuration.AutoDetectChangesEnabled = true;
            db.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
