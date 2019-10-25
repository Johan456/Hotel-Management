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

namespace Hotel_5.Controllers
{
    public class AmenitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AmenitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Amenities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Amenities.ToListAsync());
        }

    }
}
