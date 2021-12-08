using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EBusiness.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the EBusinessUser class
    public class EBusinessUser : IdentityUser<int>
    {

        //Id is defined by default

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Bu alan boş geçilemez!")]
        public string LastName { get; set; }

        //Email is defined by default

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Password { get; set; }
    }
}
