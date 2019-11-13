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
using Hotel_5.ViewModel;
using Microsoft.AspNet.Identity;

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
        public IActionResult Create()
        {

            Bookings myBooking = new Bookings {
                AmenitiesList = new List<Amenities> { 
                    new Amenities { AmenityId = 0, AmenityName="TV", IsSelected = false, AmenityPrice = 20.0 },
                    new Amenities { AmenityId = 1, AmenityName="Shower", IsSelected = false, AmenityPrice = 10.0 },
                    new Amenities { AmenityId = 2, AmenityName="HairDryer", IsSelected = false, AmenityPrice = 15.0 },
                    new Amenities { AmenityId = 2, AmenityName="DrinkCabinet", IsSelected = false, AmenityPrice = 25.0 }
                },
            };

            BookingRoom bookingRoom = new BookingRoom { booking = myBooking };

            return View(bookingRoom);
        }

        private List<int> roomsAvailable(DateTime CheckInDate, DateTime CheckOutDate, RoomTypes roomTypes)
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
                            where r.RoomType == roomTypes
                            select r.RoomId).ToHashSet();
            var availableRooms = allRooms.Except(bookedRooms);
            return availableRooms.ToList();

        }

        // POST: Bookings/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckInDate, CheckOutDate, AmenitiesList, RoomType")] Bookings booking, Rooms room, BookingRoom bookingRoom, ApplicationUser appUser)
        {

            if (ModelState.IsValid)
            {

         

                //Check if the CheckInDate is smaller than the checkOutDate, otherwise return WrongDateError.cshtml
                if (booking.CheckInDate < booking.CheckOutDate && booking.CheckInDate >= DateTime.Now)
                {
                    //assign all the available rooms to this variable
                    var avaRooms = roomsAvailable(booking.CheckInDate, booking.CheckOutDate, room.RoomType);
                    //check if there are any available rooms for the dates provided
                    if (avaRooms.Count > 0)
                    {
                        booking.RoomId = avaRooms[0];
                        //get current user
                        booking.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        booking.ReservationPrice = getReservationPrice(booking.CheckInDate, booking.CheckOutDate, room.RoomType)
                            + getAmenitiesPrice(booking.AmenitiesList);
                        appUser.TimesBooked = getTimesBooked(booking.UserId);

                        //dbContext.Update(appUser);
                        dbContext.Add(booking);
                        await dbContext.SaveChangesAsync();

                        return View("Views/Bookings/BookingSuccessful.cshtml");
                    }
                    else
                        return View("Views/Bookings/BookingError.cshtml");
                }
                else
                    return View("Views/Bookings/WrongDateError.cshtml");
                
            }
            return View(bookingRoom);
        }

        public double getReservationPrice(DateTime CheckInDate, DateTime CheckOutDate, RoomTypes roomTypes)
        {
            var priceNight = (from pr in dbContext.Rooms
                              where pr.RoomType == roomTypes
                              select pr.PricePerNight).ToList();
            double daysOfStay = (CheckOutDate - CheckInDate).TotalDays;
            double reservationPrice = daysOfStay * priceNight[0];
            return reservationPrice;
        }

     

        public double getAmenitiesPrice(List<Amenities> amenities)
        {
            double totalAmenitiesPrice = 0;
            for (int i = 0; i < amenities.Count; i++)
            {
                if(amenities[i].IsSelected)
                {
                    totalAmenitiesPrice += amenities[i].AmenityPrice;
                }
            }

            return totalAmenitiesPrice;
        }

        public int getTimesBooked(string userId)
        {
            var timesBook = (from tm in dbContext.ApplicationUsers
                             where tm.Id == userId
                             select tm.TimesBooked).ToList();
            timesBook[0]++;
            return timesBook[0];
        }

        public class UserBooking
        {
            public string userId { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public int bookingId { get; set; }
            public int roomId { get; set; }
            public DateTime checkInDate { get; set; }
            public DateTime checkOutDate { get; set; }
            public UserBooking() { }

        }

        public class UserAmenities
        {
            public string userId { get; set; }
            public string FirstName { get; set; }
            public List<Amenities> amenitiesSel { get; set; }
            public double Cost { get; set; }
        }

        public ActionResult getAllUserAmenities()
        {
            List<UserAmenities> userAmenities;
            userAmenities = (from b in dbContext.Bookings
                             join u in dbContext.ApplicationUsers
                             on b.UserId equals u.Id
                             //where (b.CheckInDate <= DateTime.Now
                             //&& b.CheckOutDate >= DateTime.Now)
                             select new UserAmenities
                             {
                                 userId = u.Id,
                                 FirstName = u.FirstName,
                                 amenitiesSel = b.AmenitiesList,
                                 Cost = b.ReservationPrice}).ToList();
            return View(userAmenities);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult getAllBookings()
        {
            List<UserBooking> userbooking;
            userbooking  = (from b in dbContext.Bookings
                               join u in dbContext.ApplicationUsers
                               on b.UserId equals u.Id
                               //where(b.CheckInDate <= DateTime.Now
                               //&& b.CheckOutDate >= DateTime.Now)
                               select new UserBooking{ 
                               userId = u.Id,
                               UserName = u.UserName,
                               FirstName = u.FirstName,
                               bookingId = b.BookingId,
                               roomId = b.RoomId,
                               checkInDate = b.CheckInDate,
                               checkOutDate = b.CheckOutDate}).ToList();

            return View(userbooking);
        }
    }
}
