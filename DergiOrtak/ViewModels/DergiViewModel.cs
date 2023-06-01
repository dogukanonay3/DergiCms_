using System.ComponentModel.DataAnnotations;

namespace DergiOrtak.ViewModels
{
    public class DergiViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Adi { get; set; }
        [Required]
        public string? Aciklama { get; set; }
        [Required]
        public int? KategoriId { get; set; }
        public string? KategoriAdi { get; set; }
    }
}
