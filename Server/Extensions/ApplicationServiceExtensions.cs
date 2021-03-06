using SongsTrack.Repository.Entities;
using SongsTrack.Repository.Repositories;
using SongsTrack.Server.SongAlbum;
using SongsTrack.Server.SongArtist;
using SongsTrack.Server.SongGenre;
using SongsTrack.Server.SongTrack;

namespace SongsTrack.Server.Extensions
{
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// This is extension method of IServiceCollection which add required configuration and also help to make Program.cs clean.
        /// </summary>
        /// <param name="services"></param>
        /// <returns services></returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Album>, AlbumRepo>();
            services.AddTransient<IRepository<Artist>, ArtistRepo>();
            services.AddTransient<IRepository<Genre>, GenreRepo>();
            services.AddTransient<IRepository<Track>, TrackRepo>();
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IArtistService, ArtistService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<ITrackService, TrackService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
