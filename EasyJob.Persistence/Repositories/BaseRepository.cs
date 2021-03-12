using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyJob.Application.Contracts.Persistence;
using EasyJob.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyJob.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly EasyJobIdentityContext _context;

        public BaseRepository(EasyJobIdentityContext context)
        {
            _context = context;
        }
        
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
        {
            return await _context.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }
    }
}