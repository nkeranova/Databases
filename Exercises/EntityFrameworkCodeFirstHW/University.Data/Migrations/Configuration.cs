namespace University.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(UniversityDbContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
        }

        private void SeedStudents(UniversityDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
                                 {
                                     FirstName = "Evlogi",
                                     LastName = "Hristov",
                                     ForumPoints = 2575
                                 });

            context.Students.Add(new Student
                                 {
                                     FirstName = "Ivaylo",
                                     LastName = "Kenov",
                                     ForumPoints = 27977
                                 });

            context.Students.Add(new Student
                                 {
                                     FirstName = "Doncho",
                                     LastName = "Minkov",
                                     ForumPoints = 10881
                                 });

            context.Students.Add(new Student
                                 {
                                     FirstName = "Nikolay",
                                     LastName = "Kostov",
                                     ForumPoints = 32407
                                 });
        }

        private void SeedCourses(UniversityDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course
                                {
                                    Name = "C# Part 1",
                                    Description = "Initial course for testing"
                                });

            context.Courses.Add(new Course
                                {
                                    Name = "C# Part 2",
                                    Description = "Initial course for testing"
                                });
        }
    }
}