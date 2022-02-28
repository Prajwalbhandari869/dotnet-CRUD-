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
    public class GenreRepo : IRepository<Genre>
    {
        private readonly DataContext _context;

        public GenreRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckAsync(string titleOrName)
        {
            return await _context.Genres.AnyAsync(x => x.Name == titleOrName.ToLower());
        }

        public async Task<Genre> CreateAsync(Genre entity)
        {
            await _context.Genres.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetAsync(int id)
        {
            return await _context.Genres
                .Include(t => t.Tracks).ThenInclude(a=>a.Album)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Genre entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
