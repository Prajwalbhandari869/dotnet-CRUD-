using SongsTrack.Shared.Models.AlbumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Shared.Models.ArtistModels
{
    public class ViewArtist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ViewAllAlbum> Albums { get; set; }
    }
}
