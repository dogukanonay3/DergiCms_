using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.ViewModels
{
    public class SayiViewModel
    {
        public int Id { get; set; }
        [Required]
        public int? DergiId { get; set; }
        public string? DergiAdi { get; set; }
        [Required]
        public int No { get; set; }
        [Required]
        public DateTime YayinTarihi { get; set; }
    }
}
