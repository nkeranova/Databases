namespace SocialNetwork.ConsoleClient.Searcher
{
    using System.Collections;

    public interface ISocialNetworkService
    {
        /// <summary>
        /// Get Username, FirstName, LastName, and number of images for
        /// all users which registration year is greater than or equal to the provided year
        /// </summary>
        IEnumerable GetUsersAfterCertainDate(int year);
        
        /// <summary>
        /// Get all posts in which the user with the provided username is tagged.
        /// Select PostedOn, Content and all usernames of the tagged users in the post.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        IEnumerable GetPostsByUser(string username);

        /// <summary>
        /// Get all approved friendships, ordered ascending by the friendship date and
        /// paged by the provided numbers. Select FirstUserUsername, FirstUserImage,
        /// SecondUserUsername, SecondUserImage. Images are just the URLs of the first image for each user.
        /// </summary>
        IEnumerable GetFriendships(int page = 1, int pageSize = 25);

        /// <summary>
        /// Get all usernames of all the unique users with which the provided user by username
        /// has at least one chat message, ordered alphabetically.
        /// </summary>
        IEnumerable GetChatUsers(string username);
    }
}
