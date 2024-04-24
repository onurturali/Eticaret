using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Model
{
    [Table("SatisDetay")]
    public class SatisDetay
    {
        [Key]
        public Guid Id { get; set; }

        public Guid SatisId { get; set; }

        public Guid UrunId { get; set; }

        public int Adet { get; set; }

        public double Fiyat { get; set; }
    }
}
