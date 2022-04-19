﻿using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        public string AuthorId { get; set; }

        public Author Author { get; set; }

        public string TranslatorId { get; set; }

        public Translator Translator { get; set; }

        public string WorkerId { get; set; }

        public Worker Worker { get; set; }

        public int Create { get; set; }

        public DateTime Uploaded { get; set; }

        public DateTime? Improved { get; set; }

        [MaxLength(1000)]
        public string Summary { get; set; }

        [MaxLength(250)]
        public string Series { get; set; }

        [Required]
        public string GenreId { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        public string MaxCoverPath { get; set; }

        [Required]
        public string MinCoverPath { get; set; }

        [Required]
        public string Address { get; set; }

        public int Downloads { get; set; }

        public ICollection<Comment> Comments { get; init; } = new List<Comment>();
        public ICollection<Rating> Ratings { get; init; } = new List<Rating>();
        public ICollection<ReaderBook> Readers { get; init; } = new List<ReaderBook>();
    }
}
