using Eticaret.Model;

namespace Eticaret.Magaza.Services
{
    public interface ISatisDetayService
    {
        Task CreateAsync(List<SatisDetay> satisDetay);
    }
}
