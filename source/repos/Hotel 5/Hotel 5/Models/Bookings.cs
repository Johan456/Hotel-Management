using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_5.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        [ForeignKey("RoomRefId")]
        public int RoomId { get; set; }
        [ForeignKey("UserRefId")]
        public String UserId { get; set; }

    }
}
