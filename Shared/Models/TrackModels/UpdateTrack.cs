using SongsTrack.Shared.Models.GenreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Shared.Models.TrackModels
{
    public class UpdateTrack
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Range(1, 5, ErrorMessage = "Rating Cannot be less then 1")]
        public int Rating { get; set; }
        //[Range(typeof(DateTime), , 1000, ErrorMessage = "Length Cannot be less then 1")]
        public DateTime Length { get; set; } 
        [Range(1, int.MaxValue, ErrorMessage = "Please Select From DropDown")]
        public int AlbumId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please Select From DropDown")]
        public int GenreId { get; set; }
    }
}
