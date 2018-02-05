using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [Required, Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required, Display(Name = "Number in Stock")]
        [MinNumberInStock1, Range(1, 20)]
        public int? InStock { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            InStock = movie.InStock;
            GenreId = movie.GenreId;
        }

        public MovieFormModel()
        {
            Id = 0;
        }
    }
}