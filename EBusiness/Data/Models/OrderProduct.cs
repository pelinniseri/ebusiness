using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Data.Models
{
    public class OrderProduct
    {
        [Key]
        public int OrderProductID { get; set; }
        [StringLength(20)]
        public int OrderID { get; set; }
        [StringLength(20)]
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
