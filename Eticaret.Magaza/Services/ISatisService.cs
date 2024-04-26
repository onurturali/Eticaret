using Eticaret.Model;

namespace Eticaret.Magaza.Services
{
    public interface ISatisService
    {
        Task<Guid> CreateAsync(Satis satis);

        Task<string> GetLastFaturaNoAsync();

        Task<Satis> GetByFaturaNoAsync(string faturaNo);

        Task<string> GetFaturaNoAsync(Guid id);
    }
}
