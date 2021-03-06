using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace EBusiness.Data.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [StringLength(20)]
        public int UserID { get; set; }
        [StringLength(20)]
        public string FirstName { get; set; }
        [StringLength(300)]
        public string Email { get; set; }
        [StringLength(300)]
        public string Address { get; set; }
        [StringLength(300)]
        public string City { get; set; }
        [StringLength(300)]
        public string State { get; set; }
        [StringLength(300)]
        public string ZipCode { get; set; }
        [StringLength(300)]
        public string CardName { get; set; }
        [StringLength(300)]
        public string CardNumber { get; set; }
        [StringLength(300)]
        public string ExpMonat { get; set; }
        [StringLength(300)]
        public string ExpJahr { get; set; }
        [StringLength(300)]
        public bool SameAddr { get; set; }
        [StringLength(20)]
        public string CVV { get; set; }
        public bool Status { get; set; }
        


    }
}
