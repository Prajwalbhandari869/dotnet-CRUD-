using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Repository.Entities
{
    public class Track
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        [Required]
        public DateTime Length { get; set; } 
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}
