using Eticaret.Model;

namespace Eticaret.Panel.Services
{
    public interface IUrunService : IBaseInterface<Urun>
    {
        public Task<bool> AktiflestirAsync(Guid id);

        public Task<bool> PasiflestirAsync(Guid id);
    }
}
