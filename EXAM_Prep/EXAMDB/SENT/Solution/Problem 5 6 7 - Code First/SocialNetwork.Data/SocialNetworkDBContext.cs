namespace SocialNetwork.Data
{
    using SocialNetwork.Models;
    using System.Data.Entity;

    class SocialNetworkDBContext : DbContext
    {
        public SocialNetworkDBContext()
            : base("SocialNetwork")
        {
        }

        public DbSet<UserProfils> UserProfils { get; set; }

        //public DbSet<Users> Users { get; set; }

        public DbSet<Posts> Posts { get; set; }

        public DbSet<Image> Image { get; set; }

        //public DbSet<Friendships> Friendships { get; set; }

        //public DbSet<ChatMessages> ChatMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfils>().Property(userProfils => userProfils.UserName).IsUnicode(true);
        }
    }
}
