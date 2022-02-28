using SongsTrack.Shared.Models.TrackModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Shared.Models.AlbumModels
{
    public class ViewAlbum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public ICollection<ViewAllTrack> Tracks { get; set; }
    }
}
