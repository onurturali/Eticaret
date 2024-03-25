using Eticaret.Model;
using Eticaret.Panel.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Panel.Services
{
    public class UrunService : IUrunService
    {
        private readonly MainDatabaseContext _context;

        public UrunService(MainDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Urun> GetAsync(Guid id)
        {
            Urun urun = await _context.Urun.Where(m => m.Id == id).FirstAsync();
            return urun;
        }
    }
}
