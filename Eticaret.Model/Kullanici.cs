using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Model
{
    [Table("Kullanici")]
    public class Kullanici
    {
        [Key]
        public Guid Id { get; set; }

        public string KullaniciAdi { get; set; } = string.Empty;

        public string Parola { get; set; } = string.Empty;
    }
}
