using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using TableAttribute = System.ComponentModel.DataAnnotations.Schema.TableAttribute;

namespace Eticaret.Model
{
    [Table("Satis")]
    public class Satis
    {
        [Key]
        public Guid Id { get; set; }

        public string FaturaNo { get; set; } = string.Empty;

        public DateTime Tarih { get; set; }

        [NotMapped, Write(false)]
        public int ToplamAdet { get; set; }

        [NotMapped, Write(false)]
        public double ToplamTutar { get; set; }
    }
}
