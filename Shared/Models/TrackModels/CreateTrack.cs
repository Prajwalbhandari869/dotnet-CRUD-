using SongsTrack.Shared.Models.GenreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Shared.Models.TrackModels
{
    public class CreateTrack
    {
        [Required]
        public string Title { get; set; }
        [Range(1, 5, ErrorMessage = "Rating Cannot be less then 1")]
        public int Rating { get; set; }
        [Range(typeof(DateTime), "1900/1/1, 00:00:01", "1900/1/1, 00:30:00", ErrorMessage = "Value for {0} must be between 00:01 and 30:00")]
        [Required]
        public DateTime Length { get; set; } 
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select From DropDown")]
        public int AlbumId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please Select From DropDown")]
        public int GenreId { get; set; }
    }
}
