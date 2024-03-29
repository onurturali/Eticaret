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
            // SELECT * FROM Urun WHERE Id = 'DSJH3JH3-FDG43USD-234F-45YGR'
            Urun urun = await _context.Urun.Where(m => m.Id == id).FirstAsync();
            return urun;
        }

        public async Task<List<Urun>> GetAllAsync()
        {
            // SELECT * FROM Urun WHERE Durum != -1
            List<Urun> urunler = await _context.Urun.Where(m => m.Durum != -1).ToListAsync();
            return urunler;
        }

        public async Task<bool> InsertAsync(Urun model)
        {
            try
            {
                model.Kategori = null;
                // INSERT INTO Urun (Ad, Url) VALUES ('Erkek Giyim', 'erkek-giyim')
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Urun model)
        {
            try
            {
                model.Kategori = null;
                // UPDATE Urun SET Ad = 'Ayakkabı', Url = 'ayakkabi' WHERE Id = 'DSJH3JH3-FDG43USD-234F-45YGR'
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
                // SELECT * FROM Urun WHERE Id = 'DSJH3JH3-FDG43USD-234F-45YGR'
                Urun urun = await GetAsync(id);
                urun.Durum = -1;
                // UPDATE Urun SET Ad = 'Ayakkabı', Url = 'ayakkabi', Durum = -1 WHERE Id = 'DSJH3JH3-FDG43USD-234F-45YGR'
                bool sonuc = await UpdateAsync(urun);
                return sonuc;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AktiflestirAsync(Guid id)
        {
            try
            {
                Urun urun = await GetAsync(id);
                urun.Durum = 1;
                bool sonuc = await UpdateAsync(urun);
                return sonuc;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> PasiflestirAsync(Guid id)
        {
            try
            {
                Urun urun = await GetAsync(id);
                urun.Durum = 0;
                bool sonuc = await UpdateAsync(urun);
                return sonuc;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
