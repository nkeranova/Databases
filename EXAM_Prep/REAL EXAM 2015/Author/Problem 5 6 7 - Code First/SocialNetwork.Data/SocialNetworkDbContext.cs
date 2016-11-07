namespace SocialNetwork.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using SocialNetwork.Models;

    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext()
            : base("SocialNetwork")
        {
        }

        public virtual IDbSet<UserProfile> UserProfiles { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
