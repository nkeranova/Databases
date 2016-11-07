using EFCodeFirst.Models.Enumeration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirst.Models
{
    public class Album
    {
        private ICollection<Song> songs;
        private ICollection<Artist> artists;
        private ICollection<Image> images;

        //another way to create primary key with Guid, but we need Guid.NewGuid(); in Constructor
        public Album()
        {
            this.Id = Guid.NewGuid();

            //когато правим връзки между таблици, трябва да се инициализира колекцията в
            //конструктура. Ползваме HashSet<Т>();
            this.songs = new HashSet<Song>();

            this.artists = new HashSet<Artist>();
            this.images = new HashSet<Image>();
        }

        public Guid Id { get; set; }

        [Required]
        //[Index(IsUnique = true)]
        public string Title { get; set; }

        public decimal? Price { get; set; }
        public DateTime? ReleasedOn { get; set; }

        public AlbumStatus Status { get; set; }

        /// <summary>
        /// We use virtual collection to make the relations between two Tables in DB
        /// </summary>
        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        
        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
