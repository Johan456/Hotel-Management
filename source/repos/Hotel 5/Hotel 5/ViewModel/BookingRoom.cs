using Hotel_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_5.ViewModel
{
    public class BookingRoom
    {
        public Bookings bookings { get; set; }
        public Rooms rooms { get; set; }
    }
}
