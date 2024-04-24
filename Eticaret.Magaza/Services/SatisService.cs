using Eticaret.Magaza.DatabaseContexts;
using Eticaret.Model;

namespace Eticaret.Magaza.Services
{
    public class SatisService : ISatisService
    {
        private readonly MainDatabaseContext _context;

        public SatisService(MainDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Satis satis)
        {
            await _context.Satis.AddAsync(satis);
            await _context.SaveChangesAsync();
            return satis.Id;
        }
    }
}
