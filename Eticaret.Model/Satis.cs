using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Model
{
    [Table("Satis")]
    public class Satis
    {
        [Key]
        public Guid Id { get; set; }

        public string FaturaNo { get; set; } = string.Empty;

        public DateTime Tarih { get; set; }


    }
}
