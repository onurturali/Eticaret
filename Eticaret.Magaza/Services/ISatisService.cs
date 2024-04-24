using Eticaret.Model;

namespace Eticaret.Magaza.Services
{
    public interface ISatisService
    {
        Task<Guid> CreateAsync(Satis satis);
    }
}
