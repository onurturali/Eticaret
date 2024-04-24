using Eticaret.Magaza.DatabaseContexts;
using Eticaret.Model;

namespace Eticaret.Magaza.Services
{
    public class SatisDetayService : ISatisDetayService
    {
        private readonly MainDatabaseContext _context;

        public SatisDetayService(MainDatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(List<SatisDetay> satisDetay)
        {
            await _context.SatisDetay.AddRangeAsync(satisDetay);
            await _context.SaveChangesAsync();
        }
    }
}
