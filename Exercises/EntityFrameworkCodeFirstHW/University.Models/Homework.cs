namespace University.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        public Homework()
        {
            this.CourseId = Guid.NewGuid();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public DateTime Deadline { get; set; }

        public AllowedFormat Format { get; set; }

        [Range(0.1, 16)]
        public double Size { get; set; }

        public Guid CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}