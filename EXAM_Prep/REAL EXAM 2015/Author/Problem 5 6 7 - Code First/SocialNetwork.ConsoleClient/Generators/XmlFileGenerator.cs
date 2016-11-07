namespace SocialNetwork.ConsoleClient.Generator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using SocialNetwork.ConsoleClient.Models;

    /// <summary>
    /// This class is only used for generating the test files. It is not part of the solution to the task.
    /// </summary>
    public class XmlFileGenerator
    {
        private const int NumberOfFriendships = 1000;
        private const int NumberOfUsers = 250;
        private const int NumberOfPosts = 10000;

        public void Generate()
        {
            var users = new List<UserXmlModel>();
            var usernames = new HashSet<string>();

            for (int i = 0; i < NumberOfUsers; i++)
            {
                string username;
                do
                {
                    username = RandomGenerator.RandomString(4, 20);
                }
                while (usernames.Contains(username.ToLower()));

                usernames.Add(username.ToLower());

                var user = new UserXmlModel
                {
                    Username = username,
                    FirstName = RandomGenerator.RandomBool() ? null : RandomGenerator.RandomString(2, 50),
                    LastName = RandomGenerator.RandomBool() ? null : RandomGenerator.RandomString(2, 50),
                    RegisteredOn = RandomGenerator.RandomDateTime(),
                    Images = new List<ImageXmlModel>()
                };

                var numberOfImages = RandomGenerator.RandomNumber(1, 8);
                for (int j = 0; j < numberOfImages; j++)
                {
                    user.Images.Add(new ImageXmlModel
                    {
                        ImageUrl = RandomGenerator.RandomString(4, 20),
                        FileExtension = RandomGenerator.RandomString(1, 4)
                    });
                }

                users.Add(user);
            }

            var friendShips = new Dictionary<string, HashSet<string>>();

            var friendShipsToSerialize = new List<FriendshipXmlModel>();

            for (int i = 0; i < NumberOfFriendships; i++)
            {
                do
                {
                    var firstUser = users[RandomGenerator.RandomNumber(0, users.Count - 1)];
                    var secondUser = users[RandomGenerator.RandomNumber(0, users.Count - 1)];

                    if (!friendShips.ContainsKey(firstUser.Username))
                    {
                        friendShips.Add(firstUser.Username, new HashSet<string>());
                    }

                    if (!friendShips.ContainsKey(secondUser.Username))
                    {
                        friendShips.Add(secondUser.Username, new HashSet<string>());
                    }

                    if (friendShips[firstUser.Username].Contains(secondUser.Username)
                        || friendShips[secondUser.Username].Contains(firstUser.Username)
                        || firstUser.Username == secondUser.Username)
                    {
                        continue;
                    }

                    var approved = RandomGenerator.RandomBool();
                    var newFriendship = new FriendshipXmlModel
                    {
                        Approved = approved,
                        FriendsSince = approved ? (DateTime?)RandomGenerator.RandomDateTime() : null,
                        FirstUser = firstUser,
                        SecondUser = secondUser,
                        Messages = new List<MessageXmlModel>()
                    };

                    friendShips[firstUser.Username].Add(secondUser.Username);
                    friendShips[secondUser.Username].Add(firstUser.Username);

                    var numberOfMessages = RandomGenerator.RandomNumber(0, 10);
                    for (int j = 0; j < numberOfMessages; j++)
                    {
                        newFriendship.Messages.Add(new MessageXmlModel
                        {
                            Author = RandomGenerator.RandomBool() ? firstUser.Username : secondUser.Username,
                            Content = RandomGenerator.RandomString(10, 100),
                            SentOn = RandomGenerator.RandomDateTime(),
                            SeenOn = RandomGenerator.RandomBool() ? (DateTime?)RandomGenerator.RandomDateTime() : null
                        });
                    }

                    friendShipsToSerialize.Add(newFriendship);

                    break;
                }
                while (true);
            }

            var xmlSerializer = new XmlSerializer(typeof(List<FriendshipXmlModel>), new XmlRootAttribute("Friendships"));
            using (var fs = new FileStream("RandomFriendships.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, friendShipsToSerialize);
            }

            var postsToSerialize = new List<PostXmlModel>();
            for (int i = 0; i < NumberOfPosts; i++)
            {
                var numberOfTags = RandomGenerator.RandomNumber(1, 10);
                var taggedUsers = new List<string>();
                for (int j = 0; j < numberOfTags; j++)
                {
                    taggedUsers.Add(users[RandomGenerator.RandomNumber(0, users.Count - 1)].Username);
                }

                postsToSerialize.Add(new PostXmlModel
                {
                    Content = RandomGenerator.RandomString(20, 100),
                    PostedOn = RandomGenerator.RandomDateTime(),
                    Users = string.Join(",", taggedUsers)
                });
            }

            xmlSerializer = new XmlSerializer(typeof(List<PostXmlModel>), new XmlRootAttribute("Posts"));
            using (var fs = new FileStream("RandomPosts.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, postsToSerialize);
            }
        }
    }
}
