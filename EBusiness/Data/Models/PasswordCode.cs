using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Data.Models
{
    public class PasswordCode
    {
        public int Id { get; set; }
        public User userinsystem { get; set; }
        public int Userid { get; set; }
        [StringLength(6)]
        public string Code { get; set; }
    }
}
