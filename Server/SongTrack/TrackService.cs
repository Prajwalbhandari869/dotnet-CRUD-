using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SongsTrack.Repository.Entities;
using SongsTrack.Repository.Repositories;
using SongsTrack.Shared.Models;
using SongsTrack.Shared.Models.TrackModels;

namespace SongsTrack.Server.SongTrack
{
    public class TrackService : ITrackService
    {
        private readonly IRepository<Track> _repository;
        private readonly IMapper _mapper;

        public TrackService(IRepository<Track> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> CreateTrackAsync(CreateTrack trackCreate)
        {
            var track = _mapper.Map<Track>(trackCreate);
            if (!(await _repository.CheckAsync(track.Title)))
            {
                track = await _repository.CreateAsync(track);
                return track.Id;
            }
            return -1;
        }

        public async Task DeleteTrackAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ViewAllTrack>> GetAllTrackAsync()
        {
            var tracks = await _repository.GetAllAsync();
            return _mapper.Map<ICollection<ViewAllTrack>>(tracks);
        }

        public async Task<ViewTrack> GetTrackAsync(int id)
        {
            var track = await _repository.GetAsync(id);
            return _mapper.Map<ViewTrack>(track);
        }

        public Task<Data<ViewAllTrack>> GetTrackAsync(PageDetails pageDetails)
        {
            Data<ViewAllTrack> data = new Data<ViewAllTrack>();
            var tracks = _repository.GetCurrentAsync().ToList();            
            tracks = tracks.Where(s => string.IsNullOrEmpty(pageDetails.Search) || s.Title.Contains(pageDetails.Search)).ToList();
            data.TotalItemCount = tracks.Count();
            if (!string.IsNullOrEmpty(pageDetails.SortBy))
            {
                switch (pageDetails.SortBy)
                {
                    case "Rating":
                        tracks = pageDetails.SortingDirection == 0 ?
                            tracks.OrderBy(x => x.Rating).ToList() :
                            tracks.OrderByDescending(x => x.Rating).ToList();
                        break;
                    case "Length":
                        tracks = pageDetails.SortingDirection == 0 ?
                            tracks.OrderBy(l => l.Length).ToList() :
                            tracks.OrderByDescending(l => l.Length).ToList();
                        break;
                    case "Album":
                        tracks = pageDetails.SortingDirection == 0 ?
                            tracks.OrderBy(a => a.Album.Title).ToList() :
                            tracks.OrderByDescending(a => a.Album.Title).ToList();
                        break;
                    case "Genre":
                        tracks = pageDetails.SortingDirection == 0 ?
                            tracks.OrderBy(g => g.Genre.Name).ToList() :
                            tracks.OrderByDescending(g => g.Genre.Name).ToList();
                        break;
                    default:
                        tracks = pageDetails.SortingDirection == 0 ?
                            tracks.OrderBy(x => x.Title).ToList() :
                            tracks.OrderByDescending(x => x.Title).ToList();
                        break;
                }
            }
            var tracksData = tracks.Skip((pageDetails.PageNumber - 1) * pageDetails.PageSize).Take(pageDetails.PageSize);
            data.CurrentPageData = _mapper.Map<ViewAllTrack[]>(tracksData);
            return Task.FromResult(data);
        }

        public async Task<bool> UpdateTrackAsync(UpdateTrack updateTrack)
        {
            var track = _mapper.Map<Track>(updateTrack);
            if (!(await _repository.CheckAsync(track.Title)) || await _repository.CheckAsync(track.Id, track.Title))
            {
                await _repository.UpdateAsync(track);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
