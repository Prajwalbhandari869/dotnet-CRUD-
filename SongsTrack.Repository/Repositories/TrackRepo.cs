using Microsoft.EntityFrameworkCore;
using SongsTrack.Repository.Data;
using SongsTrack.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongsTrack.Repository.Repositories
{
    public class TrackRepo : IRepository<Track>
    {
        private readonly DataContext _context;

        public TrackRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckAsync(string titleOrName)
        {
            return await _context.Tracks.AnyAsync(x => x.Title == titleOrName.ToLower());
        }

        public async Task<Track> CreateAsync(Track entity)
        {
            await _context.Tracks.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var track = await _context.Tracks.FirstOrDefaultAsync(x => x.Id == id);
            if (track != null)
            {
                _context.Tracks.Remove(track);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Track>> GetAllAsync()
        {
            return await _context.Tracks
                .Include(a => a.Album)
                .Include(g => g.Genre)
                .ToListAsync();
        }

        public async Task<Track> GetAsync(int id)
        {
            return await _context.Tracks
               .Include(a => a.Album)
               .Include(g => g.Genre)
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Track entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
