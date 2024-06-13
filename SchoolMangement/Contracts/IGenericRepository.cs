namespace SchoolMangement.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> Exsits(int id);
    }
}
