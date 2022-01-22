using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Data.Models
{
    public class Order
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string ExpMonat { get; set; }
        public string ExpJahr { get; set; }
        public bool SameAddr { get; set; }
        public string CVV { get; set; }
       
        
    }
}
