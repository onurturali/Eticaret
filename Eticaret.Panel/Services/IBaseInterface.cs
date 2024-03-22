namespace Eticaret.Panel.Services
{
    public interface IBaseInterface<T> where T : class
    {
        Task<T> GetAsync(Guid id);

        Task<List<T>> GetAllAsync();

        Task<bool> InsertAsync(T model);

        Task<bool> UpdateAsync(T model);

        Task<bool> DeleteAsync(Guid id);
    }
}
