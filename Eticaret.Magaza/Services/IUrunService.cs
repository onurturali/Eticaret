using Eticaret.Model;

namespace Eticaret.Magaza.Services
{
    public interface IUrunService
    {
        Task<List<Urun>> GetAllByKategori(Guid id);
    }
}
