using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Shared.Models.ArtistModels
{
    public class CreateArtist
    {
        [Required]
        public string Name { get; set; }
    }
}
