using SongsTrack.Shared.Models.ArtistModels;
using System.Net.Http.Json;

namespace SongsTrack.Client.SongArtistServices
{
    public class ArtistServices:IArtistServices
    {
        private readonly HttpClient httpClient;

        public ArtistServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> CreateArtistAsync(CreateArtist createArtist)
        {
            var response = await httpClient.PostAsJsonAsync<CreateArtist>("api/artist/create", @createArtist);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();
            }
            return 0;
        }

        public async Task<bool> DeleteArtistAsync(int id)
        {
            var responseJson = await httpClient.DeleteAsync($"api/artist/{id}");
            return await responseJson.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<IEnumerable<ViewAllArtist>> GetAllArtistAsync()
        {
            return await httpClient.GetFromJsonAsync<ViewAllArtist[]>("api/artist/allartist");
        }

        public async Task<ViewArtist> GetArtistAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<ViewArtist>($"api/artist/{id}");
        }

        public async Task<bool> UpdateArtistAsync(UpdateArtist artist)
        {
            var response = await httpClient.PutAsJsonAsync<UpdateArtist>("api/artist/update", @artist);
            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
