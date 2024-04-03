using Eticaret.Magaza.DatabaseContexts;
using Eticaret.Model;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Magaza.Services
{
    public class KategoriService : IKategoriService
    {
        private readonly MainDatabaseContext _context;

        public KategoriService(MainDatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Kategori>> GetAllAsync()
        {
            // SELECT * FROM Kategori WHERE Durum = 1
            List<Kategori> kategoriler = await _context.Kategori
                .Where(m => m.Durum == 1)
                .ToListAsync();
            return kategoriler;
        }

        public async Task<Kategori?> GetAsync(string url)
        {
            // SELECT * FROM Kategori [Url] = 'mont' AND Durum = 1
            Kategori? kategori = await _context.Kategori
                .Where(m => m.Url == url && m.Durum == 1)
                .FirstOrDefaultAsync();
            return kategori;
        }
    }
}
