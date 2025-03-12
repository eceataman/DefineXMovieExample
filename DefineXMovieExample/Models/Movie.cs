using System.ComponentModel.DataAnnotations;

namespace DefineXMovieExample.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
    }
}
