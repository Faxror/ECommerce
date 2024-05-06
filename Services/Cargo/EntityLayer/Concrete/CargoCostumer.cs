using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Cargo.EntityLayer.Concrete
{
    public class CargoCostumer
    {
        [Key]
        public int CargoCustomerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Disctrict { get; set; }


        public string City { get; set; }

        public string Address { get; set; }
    }
}
