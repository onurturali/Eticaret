using Eticaret.Model;

namespace Eticaret.Panel.Services
{
    public interface IKullaniciService : IBaseInterface<Kullanici>
    {
        public Task<Kullanici?> GirisAsync(string kullaniciAdi, string parola);
    }
}
