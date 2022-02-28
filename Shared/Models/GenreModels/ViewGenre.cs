using SongsTrack.Shared.Models.TrackModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Shared.Models.GenreModels
{
    public class ViewGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ViewAllTrack> Tracks { get; set; }
    }
}
