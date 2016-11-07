namespace University.ConsoleClient
{
    using System.Linq;
    using Data;

    public class ConsoleClient
    {
        public static void Main()
        {
            var db = new UniversityDbContext();

            //var student = new Student()
            //{
            //    FirstName = "Pesho",
            //    LastName = "Peshev",
            //    ForumPoints = 0
            //};

            //db.Students.Add(student);
            //db.SaveChanges();

            var savedStudent = db.Students.First();
            db.Students.Remove(savedStudent);
            db.SaveChanges();
        }
    }
}