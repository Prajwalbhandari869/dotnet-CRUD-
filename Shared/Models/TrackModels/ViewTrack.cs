using SongsTrack.Shared.Models.GenreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Shared.Models.TrackModels
{
    public class ViewTrack
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public int Length { get; set; }
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public int AlbumArtistId { get; set; }
        public int GenreId { get; set; }
        public string GenreName{ get; set; }
    }
}
