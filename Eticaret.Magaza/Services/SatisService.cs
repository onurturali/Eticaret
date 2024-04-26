using Eticaret.Magaza.DatabaseContexts;
using Eticaret.Model;
using Microsoft.EntityFrameworkCore;

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

        public async Task<string> GetLastFaturaNoAsync()
        {
            // SELECT * FROM Satis ORDER BY Tarih DESC OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY
            Satis? satis = await _context.Satis
                .OrderByDescending(m => m.Tarih)
                .Take(1)
                .FirstOrDefaultAsync();

            if (satis == null) return "ONR0000000000001";

            string sonFaturaNo = satis.FaturaNo;
            string sonFaturaNoSerisiz = satis.FaturaNo.Replace("ONR", "");
            int sonFaturaNoSayi = Convert.ToInt32(sonFaturaNoSerisiz);
            int yeniFaturaNoSayi = ++sonFaturaNoSayi;
            int yeniFaturaNoBasamak = yeniFaturaNoSayi.ToString().Length;
            string yeniFaturaNo = "ONR";

            for (int i = 0; i < 13 - yeniFaturaNoBasamak; i++)
                yeniFaturaNo += "0";

            yeniFaturaNo += yeniFaturaNoSayi.ToString();
            return yeniFaturaNo;
        }

        public async Task<Satis> GetByFaturaNoAsync(string faturaNo)
        {
            Satis satis = await _context.Satis.Where(m => m.FaturaNo == faturaNo).FirstAsync();
            return satis;
        }

        public async Task<string> GetFaturaNoAsync(Guid id)
        {
            Satis satis = await _context.Satis.Where(m => m.Id == id).FirstAsync();
            return satis.FaturaNo;
        }
    }
}
