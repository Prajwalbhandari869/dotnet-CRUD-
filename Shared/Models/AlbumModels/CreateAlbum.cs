using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Shared.Models.AlbumModels
{
    public class CreateAlbum
    {
       
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Please select from dropdown.")]
        public int ArtistId { get; set; }
    }
}
