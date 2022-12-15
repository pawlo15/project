namespace Project.Infrastructure.Services.Interfaces.Base
{
    public interface IRepository<T> where T : class, IBase
    {
        Task<IReadOnlyCollection<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
