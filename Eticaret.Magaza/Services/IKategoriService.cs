using Eticaret.Model;

namespace Eticaret.Magaza.Services
{
    public interface IKategoriService
    {
        Task<List<Kategori>> GetAllAsync();

        Task<Kategori?> GetAsync(string url);
    }
}
