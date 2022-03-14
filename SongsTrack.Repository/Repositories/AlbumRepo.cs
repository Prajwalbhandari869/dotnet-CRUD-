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
    public class AlbumRepo : IRepository<Album>
    {
        private readonly DataContext _context;

        public AlbumRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckAsync(string titleOrName)
        {
            return await _context.Albums.AnyAsync(x => x.Title == titleOrName.ToLower());
        }

        public async Task<bool> CheckAsync(int id, string titleOrName)
        {
            return await _context.Albums.AnyAsync(x => x.Title == titleOrName.ToLower() && x.Id == id);
        }

        public async Task<Album> CreateAsync(Album entity)
        {
            await _context.Albums.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var album = await _context.Albums.FirstOrDefaultAsync(x => x.Id == id);
            if (album != null)
            {
                _context.Albums.Remove(album);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _context.Albums
                .Include(a=>a.Artist)
                .ToListAsync();
        }

        public async Task<Album> GetAsync(int id)
        {
            return await _context.Albums
                .Include(t=>t.Artist)
                .Include(a=>a.Tracks)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Album> GetCurrentAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Album entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
