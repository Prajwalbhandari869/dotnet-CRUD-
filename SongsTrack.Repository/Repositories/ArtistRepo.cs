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
    public class ArtistRepo : IRepository<Artist>
    {
        private readonly DataContext _context;

        public ArtistRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckAsync(string titleOrName)
        {
            return await _context.Artists.AnyAsync(x => x.Name == titleOrName.ToLower());
        }

        public async Task<bool> CheckAsync(int id, string titleOrName)
        {
            return await _context.Artists.AnyAsync(x => x.Name == titleOrName.ToLower() && x.Id == id);
        }

        public async Task<Artist> CreateAsync(Artist entity)
        {
            await _context.Artists.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var artist = await _context.Artists.FirstOrDefaultAsync(x => x.Id == id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist> GetAsync(int id)
        {
            return await _context.Artists
               .Include(a=> a.Albums)
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Artist> GetCurrentAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Artist entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
