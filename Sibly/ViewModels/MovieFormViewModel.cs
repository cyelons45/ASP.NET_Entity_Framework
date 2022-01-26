using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Sibly.Models;
namespace Sibly.ViewModels
{
    public class MovieFormViewModel
    {
        public int? MovieId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }


        [Required]
        [Display(Name = "Release Date (MM/DD/YYY)")]
        public DateTime? ReleaseDate { get; set; }



        [Display(Name = "Number In Stock")]
        [NumberOfStockRange] 
        public byte? NumberInStock { get; set; }


        public IEnumerable<Genre> Genres { get; set; }

        public String Title { get 
        {
            return MovieId != 0?"Edit Movie":"New Movie";
     
        } }

        public MovieFormViewModel()
        {
            MovieId = 0;
        }


        public MovieFormViewModel(Movie movie)
        {
            MovieId = movie.MovieId;
            Name=movie.Name;
            GenreId=movie.GenreId;
            ReleaseDate=movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
        }
    
    }
}