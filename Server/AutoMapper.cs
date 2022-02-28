using AutoMapper;
using SongsTrack.Repository.Entities;
using SongsTrack.Shared.Models.AlbumModels;
using SongsTrack.Shared.Models.ArtistModels;
using SongsTrack.Shared.Models.GenreModels;
using SongsTrack.Shared.Models.TrackModels;

namespace SongsTrack.Server
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Artist, ViewArtist>().ReverseMap();
            CreateMap<Artist, CreateArtist>().ReverseMap();
            CreateMap<Artist, UpdateArtist>().ReverseMap();
            CreateMap<Artist, ViewAllArtist>().ReverseMap();
            CreateMap<Album, ViewAlbum>().ReverseMap();
            CreateMap<Album, CreateAlbum>().ReverseMap();
            CreateMap<Album, UpdateAlbum>().ReverseMap();
            CreateMap<Album, ViewAllAlbum>().ReverseMap();
            CreateMap<Track, ViewTrack>().ReverseMap();
            CreateMap<Track, CreateTrack>().ReverseMap();
            CreateMap<Track, UpdateTrack>().ReverseMap();
            CreateMap<Track, ViewAllTrack>().ReverseMap();
            CreateMap<Genre, ViewGenre>().ReverseMap();
            CreateMap<Genre, CreateGenre>().ReverseMap();
            CreateMap<Genre, UpdateGenre>().ReverseMap();
            CreateMap<Genre, ViewAllGenre>().ReverseMap();
        }
    }
}
