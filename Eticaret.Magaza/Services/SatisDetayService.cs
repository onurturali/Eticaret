using Eticaret.Magaza.DatabaseContexts;
using Eticaret.Model;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<SatisDetay>> GetBySatis(Guid satisId)
        {
            List<SatisDetay> detaylar = await _context.SatisDetay
                .Where(m => m.SatisId == satisId)
                .Include(m => m.Urun)
                .ToListAsync();
            return detaylar;
        }
    }
}
