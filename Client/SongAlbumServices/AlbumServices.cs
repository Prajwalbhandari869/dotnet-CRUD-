using SongsTrack.Shared.Models.AlbumModels;
using System.Net.Http.Json;

namespace SongsTrack.Client.SongAlbumServices
{
    public class AlbumServices : IAlbumServices
    {
        private readonly HttpClient httpClient;

        public AlbumServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<int> CreateAlbumAsync(CreateAlbum createAlbum)
        {
            var response = await httpClient.PostAsJsonAsync<CreateAlbum>("api/album/create", createAlbum);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<int>();
            }
            return 0;
        }

        public async Task<bool> DeleteAlbumAsync(int id)
        {
            var responseJson = await httpClient.DeleteAsync($"api/album/{id}");
            return await responseJson.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<ViewAlbum> GetAlbumAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<ViewAlbum>($"api/album/{id}");
        }

        public async Task<IEnumerable<ViewAllAlbum>> GetAllAlbumAsync()
        {
            return await httpClient.GetFromJsonAsync<ViewAllAlbum[]>("api/album/allalbum");
        }

        public async Task<bool> UpdateAlbumAsync(UpdateAlbum updateAlbum)
        {
            var response = await httpClient.PutAsJsonAsync<UpdateAlbum>("api/album/update", @updateAlbum);
            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
