using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Hotel_5.Models
{
    public class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("abc@xyz.com").Result == null &&
                userManager.FindByEmailAsync("recep@xyz.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "abc@xyz.com",
                    Email = "abc@xyz.com"
                };

                ApplicationUser user1 = new ApplicationUser
                {
                    UserName = "recep@xyz.com",
                    Email = "recep@xyz.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "Test123@").Result;
                IdentityResult result1 = userManager.CreateAsync(user1, "Recep123@").Result;

                if (result.Succeeded && result1.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    userManager.AddToRoleAsync(user, "Receptionist").Wait();
                }
            }

        }
    }
}
