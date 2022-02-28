
using SongsTrack.Shared.Models.GenreModels;
using System.Net.Http.Json;

namespace SongsTrack.Client.SongGenreServices
{
    public class GenreServices:IGenreServices
    {
        private readonly HttpClient httpClient;

        public GenreServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<int> CreateGenreAsync(CreateGenre createGenre)
        {
            var response = await httpClient.PostAsJsonAsync<CreateGenre>("api/genre/create", @createGenre);
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> DeleteGenreAsync(int id)
        {
            var responseJson = await httpClient.DeleteAsync($"api/genre/{id}");
            return await responseJson.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<IEnumerable<ViewAllGenre>> GetAllGenreAsync()
        {
            return await httpClient.GetFromJsonAsync<ViewAllGenre[]>("api/genre/allgenre");
        }

        public async Task<ViewGenre> GetGenreAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<ViewGenre>($"api/genre/{id}");
        }

        public async Task<bool> UpdateGenreAsync(UpdateGenre updateGenre)
        {
            var response = await httpClient.PutAsJsonAsync<UpdateGenre>("api/genre/update", @updateGenre);
            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
