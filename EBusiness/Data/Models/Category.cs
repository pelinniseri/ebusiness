using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Data.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Bitte geben Sie Kategorienamen ein!")]
        [StringLength(20, ErrorMessage = "Kategoriename darf nicht länger als 20 Zeichen sein, nicht weniger als 4 Zeichen!", MinimumLength =5)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
