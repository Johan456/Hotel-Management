using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_5.Models
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }
        public double PricePerNight { get; set; }
        public RoomTypes RoomType { get; set; }
    }

    public enum RoomTypes
    {
        SINGLE,
        DOUBLE,
        SUITE
    }
}
