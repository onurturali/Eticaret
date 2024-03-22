using Eticaret.Model;
using Eticaret.Panel.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Panel.Services
{
    public class KategoriService : IKategoriService
    {
        private readonly MainDatabaseContext _context;

        public KategoriService(MainDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Kategori> GetAsync(Guid id)
        {
            // SELECT * FROM Kategori WHERE Id = 'DSJH3JH3-FDG43USD-234F-45YGR'
            Kategori kategori = await _context.Kategori.Where(m => m.Id == id).FirstAsync();
            return kategori;
        }

        public async Task<List<Kategori>> GetAllAsync()
        {
            // SELECT * FROM Kategori
            List<Kategori> kategoriler = await _context.Kategori.ToListAsync();
            return kategoriler;
        }

        public async Task<bool> InsertAsync(Kategori model)
        {
            try
            {
                // INSERT INTO Kategori (Ad, Url) VALUES ('Erkek Giyim', 'erkek-giyim')
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Kategori model)
        {
            try
            {
                // UPDATE Kategori SET Ad = 'Ayakkabı', Url = 'ayakkabi' WHERE Id = 'DSJH3JH3-FDG43USD-234F-45YGR'
                _context.Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                // SELECT * FROM Kategori WHERE Id = 'DSJH3JH3-FDG43USD-234F-45YGR'
                Kategori kategori = await GetAsync(id);
                kategori.Durum = -1;
                // UPDATE Kategori SET Ad = 'Ayakkabı', Url = 'ayakkabi', Durum = -1 WHERE Id = 'DSJH3JH3-FDG43USD-234F-45YGR'
                bool sonuc = await UpdateAsync(kategori);
                return sonuc;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
