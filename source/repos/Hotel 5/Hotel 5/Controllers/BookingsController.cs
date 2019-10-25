using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_5.Data;
using Hotel_5.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Dynamic;

namespace Hotel_5.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public BookingsController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET: Bookings/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        private List<int> roomsAvailable(DateTime CheckInDate, DateTime CheckOutDate)
        {
            var bookedRooms = (from r in dbContext.Rooms
                               join b in dbContext.Bookings
                               on r.RoomId equals b.RoomId
                               where ((b.CheckInDate <= CheckInDate
                               && b.CheckOutDate >= CheckOutDate)
                               || (b.CheckOutDate >= CheckInDate
                               && b.CheckOutDate <= CheckOutDate)
                               || (b.CheckInDate >= CheckInDate
                               && b.CheckInDate <= CheckOutDate))
                               select r.RoomId).ToHashSet();
            var allRooms = (from r in dbContext.Rooms
                            select r.RoomId).ToHashSet();
            var availableRooms = allRooms.Except(bookedRooms);
            return availableRooms.ToList();

        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CheckInDate,CheckOutDate")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {   
                //Check if the CheckInDate is smaller than the checkOutDate, otherwise return WrongDateError.cshtml
                if (bookings.CheckInDate < bookings.CheckOutDate && bookings.CheckInDate >= DateTime.Now)
                {
                    //assign all the available rooms to this variable
                    var avaRooms = roomsAvailable(bookings.CheckInDate, bookings.CheckOutDate);
                    //check if there are any available rooms for the dates provided
                    if (avaRooms.Count > 0)
                    {
                        bookings.RoomId = avaRooms[0];
                        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        bookings.UserId = currentUserId;
                        dbContext.Add(bookings);
                        await dbContext.SaveChangesAsync();
                        return View("Views/Bookings/BookingSuccessful.cshtml");
                    }
                    else
                        return View("Views/Bookings/BookingError.cshtml");
                }
                else
                    return View("Views/Bookings/WrongDateError.cshtml");
                
            }
            return View(bookings);
        }

        public class UserBooking
        {
            public string userId { get; set; }
            public string UserName { get; set; }
            public int bookingId { get; set; }
            public int roomId { get; set; }
            public DateTime checkInDate { get; set; }
            public DateTime checkOutDate { get; set; }

            public UserBooking() { }

        }

        [Authorize(Roles = "Admin")]
        public ActionResult getAllBookings()
        {
            List<UserBooking> userbooking;
            userbooking  = (from b in dbContext.Bookings
                               join u in dbContext.Users
                               on b.UserId equals u.Id
                               where(b.CheckInDate <= DateTime.Now
                               && b.CheckOutDate >= DateTime.Now)
                               select new UserBooking{ 
                               userId = u.Id,
                               UserName = u.UserName,
                               bookingId = b.BookingId,
                               roomId = b.RoomId,
                               checkInDate = b.CheckInDate,
                               checkOutDate = b.CheckOutDate}).ToList();

            return View(userbooking);
        }
    }
}
