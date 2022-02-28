using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Shared.Models.GenreModels
{
    public class CreateGenre
    {
       
        [Required]
        public string Name { get; set; }
    }
}
