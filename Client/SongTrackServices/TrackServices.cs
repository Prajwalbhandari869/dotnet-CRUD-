using SongsTrack.Shared.Models.TrackModels;
using System.Net.Http.Json;

namespace SongsTrack.Client.SongTrackServices
{
    public class TrackServices:ITrackServices
    {
        private readonly HttpClient httpClient;

        public TrackServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<int> CreateTrackAsync(CreateTrack trackCreate)
        {
            var response = await httpClient.PostAsJsonAsync<CreateTrack>("api/track/create", @trackCreate);
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> DeleteTrackAsync(int id)
        {
            var responseJson = await httpClient.DeleteAsync($"api/track/{id}");
            return await responseJson.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<IEnumerable<ViewAllTrack>> GetAllTrackAsync()
        {
            return await httpClient.GetFromJsonAsync<ViewAllTrack[]>("api/track/alltrack");
        }

        public async Task<ViewTrack> GetTrackAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<ViewTrack>($"api/track/{id}");
        }


        public async Task<bool> UpdateTrackAsync(UpdateTrack trackUpdate)
        {
            var response = await httpClient.PutAsJsonAsync<UpdateTrack>("api/track/update", @trackUpdate);
            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
