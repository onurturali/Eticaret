using Eticaret.Model;
using Eticaret.Panel.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Panel.Services
{
    public class KullaniciService : IKullaniciService
    {
        private readonly MainDatabaseContext _context;

        public KullaniciService(MainDatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<Kullanici?> GirisAsync(string kullaniciAdi, string parola)
        {
            Kullanici? kullanici = await _context.Kullanici
                .Where(m => m.KullaniciAdi == kullaniciAdi && m.Parola == parola)
                .FirstOrDefaultAsync();
            return kullanici;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Kullanici>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Kullanici> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(Kullanici model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Kullanici model)
        {
            throw new NotImplementedException();
        }
    }
}
