using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Model
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Kategori Adı")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kategori adı giriniz.")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Ad { get; set; } = string.Empty;

        [DisplayName("Kategori URL Adresi")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kategori URL giriniz.")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Url { get; set; } = string.Empty;

        public int Durum { get; set; }
    }
}