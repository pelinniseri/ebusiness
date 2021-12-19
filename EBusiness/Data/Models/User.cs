using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Data.Models
{
    public class User
    {
        [Key]
        public int Userid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz")]
        public string UserAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string UserSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string UserSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string UserMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string UserSifre { get; set; }
        public bool Durum { get; set; }
        public string Role { get; set; }

    }
}
