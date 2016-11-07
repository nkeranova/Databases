namespace University.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext() : base("UniversityDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniversityDbContext, Configuration>());
        }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Student> Students { get; set; }
    }
}