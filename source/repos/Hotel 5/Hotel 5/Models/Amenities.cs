using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_5.Models
{
    public class Amenities
    {
        [Key]
        public int AmenityId { get; set; }
        public string AmenityName { get; set; }
        public double Price { get; set; }
    }
}
