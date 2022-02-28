using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SongsTrack.Client;
using SongsTrack.Client.SongAlbumServices;
using SongsTrack.Client.SongArtistServices;
using SongsTrack.Client.SongGenreServices;
using SongsTrack.Client.SongTrackServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<ITrackServices, TrackServices>();
builder.Services.AddScoped<IGenreServices, GenreServices>();
builder.Services.AddScoped<IAlbumServices, AlbumServices>();
builder.Services.AddScoped<IArtistServices, ArtistServices>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
