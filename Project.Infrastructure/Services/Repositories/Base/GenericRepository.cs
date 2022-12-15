using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Data;
using Project.Infrastructure.Services.Interfaces.Base;

namespace Project.Infrastructure.Services.Repositories.Base
{
    public class GenericRepository<T> : IRepository<T> where T : class, IBase
    {
        protected readonly DataContext _dataContext;

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<T> Add(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var dbData = await _dataContext.Set<T>().FirstOrDefaultAsync(d => d.Id == id);
            if (dbData != null)
            {
                _dataContext.Set<T>().Remove(dbData);
                await _dataContext.SaveChangesAsync();
                return dbData;
            }
            return null;
        }

        public async Task<T> Get(int id)
        {
            var dbData = await _dataContext.Set<T>().FirstOrDefaultAsync(d => d.Id == id);
            return dbData;
        }

        public async Task<IReadOnlyCollection<T>> GetAll()
        {
            var dbData = await _dataContext.Set<T>().ToListAsync();
            return dbData;
        }

        public async Task<T> Update(T entity)
        {
            var dbData = await _dataContext.Set<T>().FirstOrDefaultAsync(d => d.Id == entity.Id);
            if (dbData != null)
            {
                _dataContext.Entry(dbData).State = EntityState.Detached;
                dbData = entity;
                _dataContext.Update(dbData);
                _dataContext.Entry(dbData).State = EntityState.Modified;

                await _dataContext.SaveChangesAsync();

                return dbData;
            }
            return null;
        }
    }
}
