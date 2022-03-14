using SongsTrack.Shared.Models;
using SongsTrack.Shared.Models.TrackModels;

namespace SongsTrack.Server.SongTrack
{
    public interface ITrackService
    {
        Task<int> CreateTrackAsync(CreateTrack trackCreate);
        Task<IEnumerable<ViewAllTrack>> GetAllTrackAsync();
        Task<Data<ViewAllTrack>> GetTrackAsync(PageDetails pageDetails);
        Task<ViewTrack> GetTrackAsync(int id);
        Task<bool> UpdateTrackAsync(UpdateTrack updateTrack);
        Task DeleteTrackAsync(int id);
    }
}
