using SongsTrack.Shared.Models.TrackModels;

namespace SongsTrack.Client.SongTrackServices
{
    public interface ITrackServices
    {
        Task<IEnumerable<ViewAllTrack>> GetAllTrackAsync();
        Task<int> CreateTrackAsync(CreateTrack createTrack);
        Task<ViewTrack> GetTrackAsync(int id);
        Task<bool> UpdateTrackAsync(UpdateTrack updateTrack);
        Task<bool> DeleteTrackAsync(int id);
    }
}
