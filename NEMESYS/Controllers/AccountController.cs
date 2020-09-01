using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NEMESYS.Models;
using NEMESYS.ViewModels;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace NEMESYS.Controllers
{
    public class AccountController : Controller {
        private readonly NemesysContext _context;

        //Constructor; The value passed into this parameter is passed from the IServicesCollection through dependency injection.
        //Like this we have access to an instance of the NemesysContext class (which contains the DB provider and connection string) inside this controller
        public AccountController(NemesysContext context) {
            _context = context;
        }


        //This action method will invoke the Google authentication handler, and if login is successful,
        //it will redirect the user to the InitUser Action Method of the AccountController class.
        public async Task Login() {
            string returnUrl = "/Account/InitUser";
            await HttpContext.ChallengeAsync("Google", new AuthenticationProperties() { RedirectUri = returnUrl });
        }


        //This method checks if a record for the user already exists in the DB, and if not, adds one
        public async Task<IActionResult> InitUser() {
            var userEmail = "";
            var userName = "";
            //Here we are getting the full name and email info of the user from Google
            foreach (var claim in User.Claims) {
                if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                    userEmail = claim.Value;
                }
                else if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name") {
                    userName = claim.Value;
                }
            }
            //Here we are checking if the a record for the user already exists
            var allUsersInDb = from u in _context.Users select u.Email;
            //if the email is not already in the database, add a new user record to the DB
            if (!allUsersInDb.Contains(userEmail)) {
                User newUser = new User(userName, userEmail); //Using the constructor specified in the User.cs class
                _context.Add(newUser);
                await _context.SaveChangesAsync(); //Very important to save the changes
            }
            return RedirectToAction("Index", "Home"); //When ready, go to the home page
        }


        //The Logout action method will simply sign the user out of the system by clearing their cookie. 
        //After logout it will redirect the user to the home page.
        [Authorize]
        public async Task Logout() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties {
                RedirectUri = Url.Action("Index", "Home")
            });
        }


        //This action method returns the profile of the user
        public IActionResult Profile() {
            //The user should not be able to access this page if they are not logged in
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Home");
            }
            else { //i.e. if the users are logged in
                var userEmail = "";
                var userContext = from u in _context.Users select u;
                //Getting the email of the user that is currently logged in
                foreach (var claim in User.Claims) {
                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                        userEmail = claim.Value;
                    }
                }
                //Storing the current user's object in userContext
                userContext = userContext.Where(u => u.Email.Equals(userEmail));
                var user = userContext.First();
                return View(user);
            }
        }


        //This is the get action to edit the user's phone number; it returns the update page
        public IActionResult EditUserPhone() {
            var userEmail = "";
            //Getting the email of the user that is currently logged in
            foreach (var claim in User.Claims) {
                if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                    userEmail = claim.Value;
                }
            }
            //Retreiving the UserId of the person that is currently loggedin
            int id = _context.Users.Where(u => u.Email == userEmail).Select(u => u.UserId).SingleOrDefault();

            return View(_context.Users.Find(id));//Returning the form with populated phone of the user (if he has already entered it)
        }

        //This is the post action to edit the user's phone number; it updates the db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserPhone([Bind("UserId, FullName, Email, Phone, Role, NoOfReportsSubmitted")] User user) {//The Bind maps the fields from the form into the properties of the User object
            if (ModelState.IsValid) {//If the posted form data is valid             
                _context.Users.Update(user);         
                await _context.SaveChangesAsync(); //Saving the changes - V.IMP
                return RedirectToAction(nameof(Profile)); //Redirecting to the Profile action method, where we list all the User's Details
            }
            else {
                //If posted form data is invalid, stay on the edit phone number page
                return RedirectToAction(nameof(EditUserPhone));
            }
        }


        //This is the action to get the hall of fame view
        public IActionResult HallOfFame() {

            //Here I am selecting those users who have submitted a report/s this year in descending order of 
            //reports submitted this year. If a user has not submitted any reports, he will not be displayed
            var users = (from u in _context.Users
                        join r in _context.Reports on u.UserId equals r.ReporterId
                        where r.DateOfSubmission.Year == DateTime.Now.Year
                        group r by new { u.FullName, u.Phone, u.Email } into matchedTables
                        select new { matchedTables.Key.FullName, matchedTables.Key.Phone, matchedTables.Key.Email, Count = matchedTables.Select(x => x.ReporterId).Count()}).Where(u => u.Count != 0).OrderByDescending(u => u.Count);

            //I created a ViewModel that will store the resultset's data
            //Since we may have more than one row returned, we need a list of this ViewModel type
            List<HallOfFameViewModel> vmList = new List<HallOfFameViewModel>();

            //Storing each row's data in a ViewModel object, which in turn is stored in the list
            foreach (var u in users) {
                vmList.Add(new HallOfFameViewModel(u.FullName, u.Email, u.Phone, u.Count));
            }

            return View(vmList);
        }


        //This action returns the view which allows the admin to change user's roles
        public IActionResult EditUserRoles(string roleString = null) {
            //if the user is not logged in, they should not be able to access this page
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Home");
            }
            else { //i.e. if user is logged in
                //Here I am getting the object of the person who is currently logged in
                User user = null;
                foreach (var claim in User.Claims) {
                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                        var userEmail = claim.Value;
                        user = _context.Users.Where(u => u.Email == userEmail).SingleOrDefault();
                    }
                }
                //If the logged in user is not an admin and tries to access this page through 
                //the address bar then redirect them to the home page
                if (user.Role != roles.Admin) {
                    return RedirectToAction("Index", "Home");
                }
                else {//i.e if the logged in user is an admin

                    //Getting all users
                    var userContext = from u in _context.Users select u;

                    //If the user has used the filter functionality
                    if (!String.IsNullOrEmpty(roleString)) {
                        Enum.TryParse(roleString, out roles rl);
                        //Query to get just those users with the particular role
                        userContext = userContext.Where(u => u.Role == rl);
                    }

                    return View(userContext.ToList());
                }
            }
        }
    

        //This is the post action to edit a user's role; it updates the db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserRoles(int userID, int setRole) {
            //Getting the object of the user we want to update
            User user = _context.Users.Where(u => u.UserId == userID).SingleOrDefault();
            user.Role = (roles)setRole;

            //Updating the user object in the db
            _context.Users.Update(user);
            await _context.SaveChangesAsync(); //Saving the changes - V.IMP

            //We want to send an email to the user when their role has been changed
            //Here I am storing the link to the profile page of the user
            string link = "https://localhost:44366/Account/Profile";

            //Instantiate a new MimeMessage
            var message = new MimeMessage();
            //From address (including name and email of sender). This will always be the same
            message.From.Add(new MailboxAddress("NEMESYS", "nemesysapp@gmail.com"));
            //To address (including name and email of receipient)
            message.To.Add(new MailboxAddress(user.FullName, user.Email));
            //Subject
            message.Subject = "Your Role has been changed to " + user.Role.ToString();
            //Body - I want to send HTML rather than just plain text, so I have to user a BodyBuilder object
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1 style='text-align:center; font-family: Arial;'>Your Role has been changed to <span style='font-size:32px;font-weight:300;font-family: Courier New;'>" + user.Role.ToString() + "</span></h1>" +
                                   "<br/><span style='display:block;text-align:center;margin-bottom:15px;'><a href='" + link + "' style='font-size:22px;color:white;background-color:#BA0C2F;text-decoration:none;padding:15px;'>See Change</a></span>";
            message.Body = bodyBuilder.ToMessageBody();

            //Configure and send email
            using (var client = new SmtpClient()) {
                //Without this line of code, the SSL certificate handshake fails and an exception is thrown.
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                //Connecting to gmail's smtp server
                client.Connect("smtp.gmail.com", 587, false);
                //This is the username and the password of the sender
                client.Authenticate("nemesysapp@gmail.com", "NEMESYSAPP123");
                //Sending the message
                client.Send(message);
                client.Disconnect(true);
            }

            return RedirectToAction("EditUserRoles", "Account");
        }

    }//end of class
}//end of namespace