using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NEMESYS.Models;

namespace NEMESYS.Controllers {
    public class HomeController : Controller {
        private readonly NemesysContext _context;

        //Constructor; The value passed into this parameter is passed from the IServicesCollection through dependency injection.
        //Like this we have access to an instance of the NemesysContext class (which contains the DB provider and connection string) inside this controller
        public HomeController(NemesysContext context) {
            _context = context;
        }


        //This action method returns the Home Screen
        public IActionResult Index() {
            //Here I am getting the object of the person who is currently logged in (if they are logged in)
            User user = null;
            if (User.Identity.IsAuthenticated) {
                foreach (var claim in User.Claims) {
                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                        var userEmail = claim.Value;
                        user = _context.Users.Where(u => u.Email == userEmail).SingleOrDefault();
                    }
                }
            }
            return View(user);
        }


        //This is for the Error Screen
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,});
        }

    }
}
