using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.ViewModels
{
    public class MakaleViewModel
    {
        public int Id { get; set; }

        [Required]
        public int SayiId { get; set; }

        [Required]
        public string? Baslik { get; set; }

        [Required]
        public string? Ozet { get; set; }

        [Required]
        public string? Icerigi { get; set; }
    }
}
