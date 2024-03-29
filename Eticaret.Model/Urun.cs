using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Model
{
    [Table("Urun")]
    public class Urun
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Ürün Adı")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ürün adı giriniz.")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        public string Ad { get; set; } = string.Empty;

        [DisplayName("Fiyat")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fiyat giriniz.")]
        public double Fiyat { get; set; }

        [DisplayName("Görsel")]
        public string? GorselAd { get; set; }

        [DisplayName("Kategori Adı")]
        public Guid KategoriId { get; set; }

        [ForeignKey("KategoriId")]
        public virtual Kategori Kategori { get; set; } = new();

        public int Durum { get; set; }
    }
}
