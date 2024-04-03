using Eticaret.Magaza.DatabaseContexts;
using Eticaret.Model;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Magaza.Services
{
    public class UrunService : IUrunService
    {
        private readonly MainDatabaseContext _context;

        public UrunService(MainDatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Urun>> GetAllByKategori(Guid id)
        {
            List<Urun> urunler = await _context.Urun
                .Where(m => m.KategoriId == id && m.Durum == 1)
                .ToListAsync();
            return urunler;
        }
    }
}
