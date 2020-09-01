using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEMESYS.Models;
using NEMESYS.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace NEMESYS.Controllers {
    public class ReportController : Controller {

        private readonly NemesysContext _context;
        private readonly IHostingEnvironment hostenv;

        //Constructor; The value passed into this parameter is passed from the IServicesCollection through dependency injection.
        //Like this we have access to an instance of the NemesysContext class (which contains the DB provider and connection string) inside this controller
        public ReportController(NemesysContext context, IHostingEnvironment env) {
            _context = context;
            hostenv = env; //This is important to get the root directory (of wwwroot) for uploading the image
        }


        //This action returns all reports and allows users to filter through them
        public IActionResult GetAllReports(string searchString, string statusString = null) {

            //Getting all reports
            var reportContext = from rep in _context.Reports select rep;

            if (!String.IsNullOrEmpty(searchString)) {
                //Query to get just those reports that contain the particular string entered
                reportContext = reportContext.Where(r => r.TypeOfHazard.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(statusString)) {
                Enum.TryParse(statusString, out status st);
                //Query to get just those reports with the particular status
                reportContext = reportContext.Where(r => r.Status == st);
            }

            //Including the related reporter and investigator objects (both of type user)
            //Note that we want the most recent reports to appear at the top, which is why we order by desecending order of report id
            reportContext = reportContext.Include(r => r.Reporter).Include(i => i.Investigator).OrderByDescending(r => r.ReportId);
            return View(reportContext.ToList());
        }


        //This action returns the reports submitted by the user that is logged in, and allows them to filter through them as well
        public IActionResult GetYourReports(string searchString, string statusString = null) {

            //First we have to ensure that the user is logged in!
            if (!User.Identity.IsAuthenticated) {
                //if the user is not logged in, redirect him to the login page
                return RedirectToAction("LogIn", "Account");
            }

            else { //i.e. if the user is logged in
                //Here I am getting the object of the person who is currently logged in
                User user = null;
                foreach (var claim in User.Claims) {
                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                        var userEmail = claim.Value;
                        user = _context.Users.Where(u => u.Email == userEmail).SingleOrDefault();
                    }
                }

                //Getting all reports
                var reportContext = from rep in _context.Reports select rep;

                if (!String.IsNullOrEmpty(searchString)) {
                    //Query to get just those reports that contain the particular string entered
                    reportContext = reportContext.Where(r => r.TypeOfHazard.Contains(searchString));
                }

                if (!String.IsNullOrEmpty(statusString)) {
                    Enum.TryParse(statusString, out status st);
                    //Query to get just those reports with the particular status
                    reportContext = reportContext.Where(r => r.Status == st);
                }

                //Filtering only those reports made by the user that is currently logged in,
                //and including the related reporter and investigator objects (both of type user)
                //Note that we want the most recent reports to appear at the top, which is why we order by desecending order of report id
                reportContext = reportContext.Where(r => r.ReporterId == user.UserId).Include(r => r.Reporter).Include(i => i.Investigator).OrderByDescending(r => r.ReportId);
                return View(reportContext.ToList());
            }
        }


        //This controller action returns those reports which the currently logged in user is assigned to
        public IActionResult GetYourAssignedReports(string searchString, string statusString = null) {

            //First we have to ensure that the user is logged in! (If the user is not logged in, 
            //the link to this page will not be shown, but they can always enter the url in the address bar)
            if (!User.Identity.IsAuthenticated) {
                //if the user is not logged in, redirect him to the login page
                return RedirectToAction("LogIn", "Account");
            }

            else { //i.e. if the user is logged in
                //Here I am getting the object of the person who is currently logged in
                User user = null;
                foreach (var claim in User.Claims) {
                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                        var userEmail = claim.Value;
                        user = _context.Users.Where(u => u.Email == userEmail).SingleOrDefault();
                    }
                }

                //Getting all reports
                var reportContext = from rep in _context.Reports select rep;

                if (!String.IsNullOrEmpty(searchString)) {
                    //Query to get just those reports that contain the particular string entered
                    reportContext = reportContext.Where(r => r.TypeOfHazard.Contains(searchString));
                }

                if (!String.IsNullOrEmpty(statusString)) {
                    Enum.TryParse(statusString, out status st);
                    //Query to get just those reports with the particular status
                    reportContext = reportContext.Where(r => r.Status == st);
                }

                //Filtering only those reports assigned to the user that is currently logged in,
                //and including the related reporter and investigator objects (both of type user)
                //Note that we want the most recent reports to appear at the top, which is why we order by desecending order of report id
                reportContext = reportContext.Where(r => r.InvestigatorID == user.UserId).Include(r => r.Reporter).Include(i => i.Investigator).OrderByDescending(r => r.ReportId);

                //In addition to the list of reports, I also want to pass the user object to the View 
                AllReportsAndLoggedInUserViewModel vm = new AllReportsAndLoggedInUserViewModel {
                    reportList = reportContext.ToList(),
                    userObj = user
                };

                return View(vm);
            }
        }
  

        //This method returns the form to add a new report
        public IActionResult CreateReport() {
            //First we have to ensure that the user is logged in!
            if (!User.Identity.IsAuthenticated) {
                //if the user is not logged in, redirect him to the login page
                return RedirectToAction("LogIn", "Account");
            }
            else {
                return View();
            }         
        }


        //This post action method adds a new report to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReport(IFormFile img, [Bind("TypeOfHazard, Location, DateAndTimeOfSpotting, Priority, Longitude, Latitude, Description")] Report report) { //The Bind maps the fields from the form into the properties of the Report object
            if (ModelState.IsValid) {//If the posted form data is valid      
                Report repToAdd = new Report(); //Creating a new report object
                //Assigning form details to the new object
                repToAdd.TypeOfHazard = report.TypeOfHazard;
                repToAdd.Location = report.Location;
                repToAdd.DateAndTimeOfSpotting = report.DateAndTimeOfSpotting;
                repToAdd.Priority = report.Priority;
                repToAdd.Longitude = report.Longitude;
                repToAdd.Latitude = report.Latitude;
                repToAdd.Description = report.Description;

                //Here I am getting the id of the person who submitted the report
                int reporterID = -1;
                foreach (var claim in User.Claims) {
                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                        var userEmail = claim.Value;
                        reporterID = _context.Users.Where(u => u.Email == userEmail).Select(u => u.UserId).SingleOrDefault();
                        repToAdd.ReporterId = reporterID;
                    }
                }

                //Here I am setting the image path
                string imgPathForDB;
                if (img != null) { //i.e. if an image was uploaded

                    //There is validation on the client side for the file type that is uploaded, however this is not enough. Here I
                    //check the type of file uploaded, and if it is not an image, we return an UnsupportedMediaTypeResult Action Result
                    string extension = Path.GetExtension(img.FileName);
                    if(!(extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif")) {
                        return new UnsupportedMediaTypeResult();
                    }

                    //Here I generate a GUID, so that if two users upload an image with the same filename, 
                    //they will still have unique names on our server. Note that I will combine this GUID
                    //with the actual image filename so as to not lose any naming conventions the user might have.
                    var globallyUniqueIdentifier = Guid.NewGuid();

                    //This is where the image uploaded will be saved (wwwroot/images/GUID+<imgFileName>)
                    var filename = Path.Combine(hostenv.WebRootPath, "images", globallyUniqueIdentifier + Path.GetFileName(img.FileName));

                    //Here I am copying the image to the specified directory on the server (which is localhost in our case)
                    img.CopyTo(new FileStream(filename, FileMode.Create));
                    
                    //This is the path that will be saved to the database if an image is uploaded
                    imgPathForDB = "/images/" + globallyUniqueIdentifier + Path.GetFileName(img.FileName);
                }
                else { //i.e. if no image was uploaded
                    //This is the path that will be saved to the database if an image is not uploaded
                    imgPathForDB = "/images/NoImageUploaded.png";
                }
                repToAdd.PhotoUrl = imgPathForDB;

                //Here I am getting the database row (as an object) of the user who submitted the report
                User userToUpdate = _context.Users.Where(u => u.UserId == reporterID).SingleOrDefault();
                //Here I am incrementing the number of reports submitted of the person who submitted this report
                userToUpdate.NoOfReportsSubmitted++;

                _context.Users.Update(userToUpdate); //Update the users table
                _context.Reports.Add(repToAdd); //Add the new report to the reports table
                await _context.SaveChangesAsync();//V.IMP to save changes!
           

                //We want to send an email to each of the investigators and admins when a new report is added 
                //Here I am getting a list of those users who are Investigators or Admins
                List<User> investigatorsAndAdminsList = _context.Users.Where(u => u.Role != roles.Reporter).ToList();
                //Here I am storing the link to the view report page of the new report that has been added
                string link = "https://localhost:44366/Report/GetAllReports";

                //The loop is beacuse we want to send the email to all investigators and admins
                foreach (User user in investigatorsAndAdminsList) {

                    //Instantiate a new MimeMessage
                    var message = new MimeMessage();
                    //From address (including name and email of sender). This will always be the same
                    message.From.Add(new MailboxAddress("NEMESYS", "nemesysapp@gmail.com"));
                    //To address (including name and email of receipient)
                    message.To.Add(new MailboxAddress(user.FullName, user.Email));
                    //Subject
                    message.Subject = "A New Report \"" + repToAdd.TypeOfHazard + "\" has been Added";
                    //Body - I want to send HTML rather than just plain text, so I have to user a BodyBuilder object
                    BodyBuilder bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = "<h1 style='text-align:center; font-family:Arial;'>A New Report <br/> <span style='font-size:32px;font-weight:300;font-family: Courier New;'>\"" + repToAdd.TypeOfHazard + "\"</span><br/>has been Added</h1><br/>" +
                                           "<h3 style='text-align:center;font-family:Arial;font-weight:300;'>This Near Miss was Spotted on <strong>" + repToAdd.DateAndTimeOfSpotting.ToString("dd/MMM/yyyy h:mm tt") + "</strong>. The Location of the Near Miss is <strong>" + repToAdd.Location + "</strong>. The Priority of the Report is <strong>" + repToAdd.Priority + "</strong>.</h3>" +
                                           "<br/><span style='display:block;text-align:center;margin-bottom:15px;'><a href='" + link + "' style='font-size:22px;color:white;background-color:#BA0C2F;text-decoration:none;padding:15px;'>View Report</a></span>";
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

                }

                return RedirectToAction(nameof(GetAllReports));
            }
            else {
                //If posted form data is invalid, stay on the create report page
                return RedirectToAction(nameof(CreateReport));
            }
        }


        //This action method will just redirect to other action methods, depending on various factors. It does not return views itself.
        public IActionResult Details(int? id) {

            //If the user tries to enter the url without a report id, give him a 404
            if (id == null) {
                return NotFound();
            }

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

            //Here I am getting the investigation object (if any) related to the report in question
            //If no investigation exists for the report in question, null is return
            Investigation investigation = _context.Investigations.Where(i => i.ReportId == id).SingleOrDefault();


            //If the user is not logged in AND no investigation has been added yet
            if (!User.Identity.IsAuthenticated && investigation == null) {
                return RedirectToAction("ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet", "Report", new { reportID = id });
            }

            //If the user is not logged in AND an investigation has been added
            if (!User.Identity.IsAuthenticated && investigation != null) {
                return RedirectToAction("ViewReportNotLoggedInOrNotInvestigatorOrAdminAndInvestigationAdded", "Report", new { reportID = id });
            }

            //If the user is logged in BUT is not an investigator or admin AND no investigation has been added yet
            if (User.Identity.IsAuthenticated) {
                if (user.Role == roles.Reporter && investigation == null) {
                    return RedirectToAction("ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet", "Report", new { reportID = id });
                }
            }

            //If the user is logged in BUT is not an investigator or admin AND an investigation has been added
            if (User.Identity.IsAuthenticated) {
                if (user.Role == roles.Reporter && investigation != null) {
                    return RedirectToAction("ViewReportNotLoggedInOrNotInvestigatorOrAdminAndInvestigationAdded", "Report", new { reportID = id });
                }
            }

            //If the user is logged in AND is an investigator or admin AND no investigation has been added yet
            if (User.Identity.IsAuthenticated) {
                if (user.Role != roles.Reporter && investigation == null) {
                    return RedirectToAction("ViewReportIsInvestigatorOrAdminAndNoInvestigationAddedYet", "Report", new { reportID = id });
                }
            }

            //If the user is logged in AND is an investigator or admin AND an investigation has been added
            if (User.Identity.IsAuthenticated) {
                if (user.Role != roles.Reporter && investigation != null) {
                    return RedirectToAction("ViewReportIsInvestigatorOrAdminAndInvestigationAdded", "Report", new { reportID = id });
                }
            }

            return RedirectToAction("Index", "Home"); //This will never be executed, but it is needed so that all code paths return a value
        }


        public async Task<IActionResult> ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet(int? reportID) {

            //If the user tries to enter the url without a report id, give him a 404
            if (reportID == null) {
                return NotFound();
            }

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

            //Here I am getting the investigation object (if any) related to the report in question
            Investigation investigation = _context.Investigations.Where(i => i.ReportId == reportID).SingleOrDefault();

            //If the user is not logged in, and an investigation exists, redirect them to the appropriate details view 
            if (!User.Identity.IsAuthenticated && !(investigation == null)) {
                return RedirectToAction("Details", "Report", new { id = reportID });
            }

            //If the user is logged in, but the other conditions are not satisfied, then redirect them to the appropriate details view
            if (User.Identity.IsAuthenticated) {
                if (!(user.Role == roles.Reporter && investigation == null)) {
                    return RedirectToAction("Details", "Report", new { id = reportID });
                }
            }

            //The code above does not let users who meet the conditions specified above to view 
            //the page returned by this controller action by typing in the corresponding URL

            //Here I am getting the Report object of the report in question, including with it the Reporter and Investigator object (of type User)
            Report report = await _context.Reports.Include(r => r.Reporter).Include(i => i.Investigator).FirstOrDefaultAsync(rep => rep.ReportId == reportID);

            //If the user is logged in, I get the record from the upvote table(if any) which contains the current
            //user's id and the current report's id. If the user is not logged in, the upvote object will be null
            Upvote upvote = null;
            if (User.Identity.IsAuthenticated) { 
                //if no such record exists, null will be stored in upvote
                upvote = _context.Upvotes.Where(u => u.UserId == user.UserId).Where(u => u.ReportId == report.ReportId).SingleOrDefault();
            }

            //I want to pass more data than just the report to the view, so I will use a ViewModel
            ReportAndUserUpvoteDetailsViewModel vm = new ReportAndUserUpvoteDetailsViewModel();
            //If upvote is null, then either the user is not logged in, or the
            //currently logged in user has not upvoted the report in question
            if (upvote == null) { 
                vm.HasUpvoted = false;
            }
            else {
                vm.HasUpvoted = true;
            }
            vm.Report = report;

            //if the returned object is null (because the user would have entered a report id of a report that does not exist in the url),
            //then redirect them to the GetAllReports Action Method, otherwise return the view associated with this controller action
            if (report == null) {
                return RedirectToAction("GetAllReports", "Report");
            }
            else {
                return View(vm);
            }
        }


        public async Task<IActionResult> ViewReportNotLoggedInOrNotInvestigatorOrAdminAndInvestigationAdded(int? reportID) {

            //If the user tries to enter the url without a report id, give him a 404
            if (reportID == null) {
                return NotFound();
            }

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

            //Here I am getting the investigation object (if any) related to the report in question
            Investigation investigation = _context.Investigations.Where(i => i.ReportId == reportID).SingleOrDefault();

            //If the user is not logged in, and an investigation does not exist, redirect them to the appropriate details view
            if (!User.Identity.IsAuthenticated && investigation == null) {
                return RedirectToAction("Details", "Report", new { id = reportID });
            }

            //If the user is logged in, but the other conditions are not satisfied, then redirect them to the appropriate details view
            if (User.Identity.IsAuthenticated) {
                if (!(user.Role == roles.Reporter && investigation != null)) {
                    return RedirectToAction("Details", "Report", new { id = reportID });
                }
            }

            //The code above does not let users who meet the conditions specified above to view 
            //the page returned by this controller method by typing in the corresponding URL

            //Here I am getting the Report object of the report in question, including with it the Reporter and Investigator object (of type User)
            Report report = await _context.Reports.Include(r => r.Reporter).Include(i => i.Investigator).FirstOrDefaultAsync(rep => rep.ReportId == reportID);

            //If the user is logged in, I get the record from the upvote table(if any) which contains the current
            //user's id and the current report's id. If the user is not logged in, the upvote object will be null
            Upvote upvote = null;
            if (User.Identity.IsAuthenticated) {
                //if no such record exists, null will be stored in upvote
                upvote = _context.Upvotes.Where(u => u.UserId == user.UserId).Where(u => u.ReportId == report.ReportId).SingleOrDefault();
            }

            //I want to pass more data than just the report to the view, so I will use a ViewModel
            ReportAndUserUpvoteDetailsViewModel vm = new ReportAndUserUpvoteDetailsViewModel();
            //If upvote is null, then either the user is not logged in, or the
            //currently logged in user has not upvoted the report in question
            if (upvote == null) {
                vm.HasUpvoted = false;
            }
            else {
                vm.HasUpvoted = true;
            }
            vm.Report = report;

            //if the returned object is null (because the user would have entered a report id of a report that does not exist in the url),
            //then redirect them to the GetAllReports Action Method, otherwise return the view associated with this controller action
            if (report == null) {
                return RedirectToAction("GetAllReports", "Report");
            }
            else {
                return View(vm);
            }
        }


        public async Task<IActionResult> ViewReportIsInvestigatorOrAdminAndNoInvestigationAddedYet(int? reportID) {

            //If the user tries to enter the url without a report id, give him a 404
            if (reportID == null) {
                return NotFound();
            }

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

            //Here I am getting the investigation object (if any) related to the report in question
            Investigation investigation = _context.Investigations.Where(i => i.ReportId == reportID).SingleOrDefault();

            //If the user is not logged in, they should not be able to access this page, so redirect them to the appropriate details view
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("Details", "Report", new { id = reportID });
            }

            //If the user is logged in, but the other conditions are not satisfied, then redirect them to the appropriate details view
            if (User.Identity.IsAuthenticated) {
                if (!(user.Role != roles.Reporter && investigation == null)) {
                    return RedirectToAction("Details", "Report", new { id = reportID });
                }
            }

            //The code above does not let users who meet the conditions specified above to view 
            //the page returned by this controller method by typing in the corresponding URL

            //Here I am getting a list of all investigators (which can be users with role  
            //investigator or admin), which I will pass to the view. This is so we can 
            //populate the select input field with the emails of all the investigators
            List<User> investigators = _context.Users.Where(u => u.Role != roles.Reporter).ToList();


            //Here I am getting the Report object of the report in question, including with it the Reporter and Investigator object (of type User)
            Report report = await _context.Reports.Include(r => r.Reporter).Include(i => i.Investigator).FirstOrDefaultAsync(rep => rep.ReportId == reportID);

            //In this case the user will surely be logged in
            //Here I am getting the record from the upvote table(if any) which
            //contains the current user's id and the current report's id. 
            //if no such record exists, null will be stored in upvote
            Upvote upvote = _context.Upvotes.Where(u => u.UserId == user.UserId).Where(u => u.ReportId == report.ReportId).SingleOrDefault();
            

            //I want to pass more than just the report object to the view, so I will use a ViewModel
            ReportAndAllInvestigatorsAndUserUpvoteDetailsViewModel vm = new ReportAndAllInvestigatorsAndUserUpvoteDetailsViewModel();
            //If upvote is null, then that means that the currently
            //logged in user has not upvoted the report in question
            if (upvote == null) {
                vm.HasUpvoted = false;
            }
            else {
                vm.HasUpvoted = true;
            }
            vm.InvestigatorsList = investigators;
            vm.Report = report;

            //if the returned object is null (because the user would have entered a report id of a report that does not exist in the url),
            //then redirect them to the GetAllReports Action Method, otherwise return the view associated with this controller action
            if (report == null) {
                return RedirectToAction("GetAllReports", "Report");
            }
            else {
                return View(vm);
            }
        }


        public async Task<IActionResult> ViewReportIsInvestigatorOrAdminAndInvestigationAdded(int? reportID) {

            //If the user tries to enter the url without a report id, give him a 404
            if (reportID == null) {
                return NotFound();
            }

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

            //Here I am getting the investigation object (if any) related to the report in question
            Investigation investigation = _context.Investigations.Where(i => i.ReportId == reportID).SingleOrDefault();

            //If the user is not logged in, they should not be able to access this page, so redirect them to the appropriate details view 
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("Details", "Report", new { id = reportID });
            }

            //If the user is logged in, but the other conditions are not satisfied, then redirect them to the appropriate details view 
            if (User.Identity.IsAuthenticated) {
                if (!(user.Role != roles.Reporter && investigation != null)) {
                    return RedirectToAction("Details", "Report", new { id = reportID });
                }
            }

            //The code above does not let users who meet the conditions specified above to view 
            //the page returned by this controller method by typing in the corresponding URL

            //Here I am getting a list of all investigators (which can be users with role  
            //investigator or admin), which I will pass to the view. This is so we can 
            //populate the select input field with the emails of all the investigators
            List<User> investigators = _context.Users.Where(u => u.Role != roles.Reporter).ToList();

            //Here I am getting the Report object of the report in question, including with it the Reporter and Investigator object (of type User)
            Report report = await _context.Reports.Include(r => r.Reporter).Include(i => i.Investigator).FirstOrDefaultAsync(rep => rep.ReportId == reportID);

            //In this case the user will surely be logged in
            //Here I am getting the record from the upvote table(if any) which
            //contains the current user's id and the current report's id. 
            //if no such record exists, null will be stored in upvote
            Upvote upvote = _context.Upvotes.Where(u => u.UserId == user.UserId).Where(u => u.ReportId == report.ReportId).SingleOrDefault();

            //I want to pass more than just the report object to the view, so I will use a ViewModel
            ReportAndAllInvestigatorsAndUserUpvoteDetailsViewModel vm = new ReportAndAllInvestigatorsAndUserUpvoteDetailsViewModel();
            //If upvote is null, then that means that the currently
            //logged in user has not upvoted the report in question
            if (upvote == null) {
                vm.HasUpvoted = false;
            }
            else {
                vm.HasUpvoted = true;
            }
            vm.InvestigatorsList = investigators;
            vm.Report = report;


            //if the returned object is null (because the user would have entered a report id of a report that does not exist in the url),
            //then redirect them to the GetAllReports Action Method, otherwise return the view associated with this controller action
            if (report == null) {
                return RedirectToAction("GetAllReports", "Report");
            }
            else {
                return View(vm);
            }
        }


        //This is the get method to edit a report; it returns the edit report page
        public IActionResult EditReport(int? reportID) {

            //If the user tries to enter the url without a report id, give him a 404
            if (reportID == null) {
                return NotFound();
            }

            //if the user is not logged in, he should not be able to access this page!
            //Thus, redirect him to the details page of the report in question
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("Details", "Report", new { id = reportID });
            }

            var userEmail = "";
            //Getting the email of the user that is currently logged in
            foreach (var claim in User.Claims) {
                if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                    userEmail = claim.Value;
                }
            }

            //Retreiving the UserId of the person that is currently logged in
            int userID = _context.Users.Where(u => u.Email == userEmail).Select(u => u.UserId).SingleOrDefault();

            //Retreiving the id of the person who submitted the report in question
            //if the reportID of a report that does not exist has been entered through the url
            //then 0 will be stored in reporterID (checked through debugging)
            int reporterID = _context.Reports.Where(r => r.ReportId == reportID).Select(r => r.ReporterId).SingleOrDefault();

            //if the user is logged in but is trying to edit a report that he did not submit, then redirect him to the appropriate details view
            if (userID != reporterID) {
                return RedirectToAction("Details", "Report", new { id = reportID });
            }

            return View(_context.Reports.Find(reportID));//Returning the form to edit the report, with fields already populated
        }


        //This is the post action to edit the report; it updates the db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReport([Bind("ReportId, ReporterId, InvestigatorID, DateOfSubmission, Status, UpVoteCount, Priority, TypeOfHazard, DateAndTimeOfSpotting, Location, Longitude, Latitude, PhotoUrl, Description")] Report report) {//The Bind maps the fields from the form into the properties of the Report object
            if (ModelState.IsValid) {//If the posted form data is valid             
                _context.Reports.Update(report);
                await _context.SaveChangesAsync(); //Saving the changes - V.IMP
                return RedirectToAction("Details", "Report", new { id = report.ReportId });
            }
            else {
                //If posted form data is invalid, stay on the edit report details page
                return RedirectToAction("EditReport", "Report", new { reportID = report.ReportId });
            }
        }


        //This is the post action to delete a report; it deletes the report and any associated investigation from the db
        //and also reduces the number of reports submitted of the user who submitted this report by 1
        [HttpPost]//We searched online and using post to delete an item looks like an acceptable way to do so
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReport(int reportID) {          
            //Here I'm getting the associated investigation to the report in question (if any)
            Investigation inv = _context.Investigations.Where(i => i.ReportId == reportID).SingleOrDefault();
            //If an investigation does exist for the report in question, delete it
            if (inv != null) {
                _context.Investigations.Remove(inv);
            }

            //Here I'm getting the report in question
            Report rep = _context.Reports.Where(r => r.ReportId == reportID).SingleOrDefault();
            //Here I'm getting the object of the person who posted this report
            User user = _context.Users.Where(u => u.UserId == rep.ReporterId).SingleOrDefault();
            //Decrementing the number of reports submitted of the user who had posted this report
            user.NoOfReportsSubmitted--;

            //If we delete a report, we also want to delete any upvotes it has from the upvotes table
            List<Upvote> AllUpvotesList = _context.Upvotes.Where(u => u.ReportId == reportID).ToList();
            foreach (Upvote uv in AllUpvotesList) {
                _context.Upvotes.Remove(uv);
            }

            _context.Users.Update(user);
            _context.Reports.Remove(rep);
            await _context.SaveChangesAsync(); //Saving the changes - V.IMP
            return RedirectToAction("GetAllReports", "Report");     
        }


        //This method assigns a report to a particular investigator (which can be a user with role investigator or admin)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignInvestigatorToReport(int reportID, int assignedInvestigator) {
            //Getting the object of the report in question (using the reportID parameter passed in)
            Report report = _context.Reports.Where(r => r.ReportId == reportID).SingleOrDefault();

            //if the user selected none in the select field (value = 0), set the investigatorID to null
            if (assignedInvestigator == 0) {
                report.InvestigatorID = null;
            }
            //if the user selected some email address from the select field, set the investigatorID to the value of that select field
            else {
                report.InvestigatorID = assignedInvestigator;
            }

            //Updating the report object in the db
            _context.Reports.Update(report);
            await _context.SaveChangesAsync(); //Saving the changes - V.IMP

            //Only if 'None' was not selected from the select input field
            if(assignedInvestigator != 0) {
                //If the logged in investigator is not assigning himself but a third-person to investigate a report,
                //we want to send an email to that investigator telling him that a new report has been assigned to him.

                //Here I am getting the object of the user who has been assigned to the report
                User user = _context.Users.Where(u => u.UserId == assignedInvestigator).SingleOrDefault();

                //Here I am getting the email address of the user that is currently logged in
                string userEmail = null;
                foreach (var claim in User.Claims) {
                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                        userEmail = claim.Value;
                    }
                }

                //Here I am storing the link to the view report page of the report in question
                string link = "https://localhost:44366/Report/Details?id=" + report.ReportId.ToString();
               
                //If the logged in investigator did not assign a report to himself
                if (userEmail != user.Email) {

                    //Instantiate a new MimeMessage
                    var message = new MimeMessage();
                    //From address (including name and email of sender). This will always be the same
                    message.From.Add(new MailboxAddress("NEMESYS", "nemesysapp@gmail.com"));
                    //To address (including name and email of receipient)
                    message.To.Add(new MailboxAddress(user.FullName, user.Email));
                    //Subject
                    message.Subject = "A Report \"" + report.TypeOfHazard + "\" has been Assigned to you";
                    //Body - I want to send HTML rather than just plain text, so I have to user a BodyBuilder object
                    BodyBuilder bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = "<h1 style='text-align:center; font-family:Arial;'>A Report <br/> <span style='font-size:32px;font-weight:300;font-family: Courier New;'>\"" + report.TypeOfHazard + "\"</span><br/>has been Assigned to you</h1><br/>" +
                                           "<span style='display:block;text-align:center;margin-bottom:15px;'><a href='" + link + "' style='font-size:22px;color:white;background-color:#BA0C2F;text-decoration:none;padding:15px;'>Click Here To Review</a></span>";
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

                }
            }

            //redirecting to the details page of the report in question
            return RedirectToAction("Details", "Report", new { id = report.ReportId });
        }


        //This method updates the status of a given report
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatusOfReport(int reportID, int setStatus) {
            //Getting the object of the report in question (using the reportID parameter passed in)
            Report report = _context.Reports.Where(r => r.ReportId == reportID).SingleOrDefault();
            //Setting the new status in the retreived object
            report.Status = (status)setStatus;

            //Updating the report object in the db
            _context.Reports.Update(report);
            await _context.SaveChangesAsync(); //Saving the changes - V.IMP

            //We want to send an email to the user when the status of their report is changed
            //Here I am getting the object of the user who submitted the report in question
            User user = _context.Users.Where(u => u.UserId == report.ReporterId).SingleOrDefault();
            //Here I am storing the link to the report in question
            string link = "https://localhost:44366/Report/ViewReportIsInvestigatorAndInvestigationAdded?reportID=" + report.ReportId.ToString();

            //Instantiate a new MimeMessage
            var message = new MimeMessage();
            //From address (including name and email of sender). This will always be the same
            message.From.Add(new MailboxAddress("NEMESYS", "nemesysapp@gmail.com"));
            //To address (including name and email of receipient)
            message.To.Add(new MailboxAddress(user.FullName, user.Email));
            //Subject
            message.Subject = "Status of your Report \"" + report.TypeOfHazard + "\" has been Changed";
            //Body - I want to send HTML rather than just plain text, so I have to user a BodyBuilder object
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1 style='text-align:center; font-family: Arial;'>The Status of Your Report <br/> <span style='font-size:32px;font-weight:300;font-family: Courier New;'>\"" + report.TypeOfHazard + "\"</span><br/> has been Changed</h1>" +                   
                                   "<br/><span style='display:block;text-align:center;margin-bottom:15px;'><a href='"+link+ "' style='font-size:22px;color:white;background-color:#BA0C2F;text-decoration:none;padding:15px;'>See Change</a></span>";
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

            //redirecting to the details page of the report in question
            return RedirectToAction("Details", "Report", new { id = report.ReportId });
        }


        //This action adds an upvote to a report
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpvoteReport(int reportID) {

            //The user must obviously be logged in to add an upvote
            if (!User.Identity.IsAuthenticated) {
                //if the user is not logged in, redirect him to the login page
                return RedirectToAction("LogIn", "Account");
            }
            else {
                //Here I am getting the object of the person who is currently logged in
                User user = null;
                foreach (var claim in User.Claims) {
                    if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                        var userEmail = claim.Value;
                        user = _context.Users.Where(u => u.Email == userEmail).SingleOrDefault();
                    }
                }

                //Creating a new Upvote object with the id of the report in question and the id of the user who is currently logged in
                Upvote uv = new Upvote(reportID, user.UserId);

                //Getting the report object in question
                Report report = _context.Reports.Where(r => r.ReportId == reportID).SingleOrDefault();
                //incrementing the upvote count
                report.UpVoteCount++;

                //Updating the report object in the db
                _context.Reports.Update(report);
                //Adding the Upvote object to the db
                _context.Upvotes.Add(uv);
                await _context.SaveChangesAsync(); //Saving the changes - V.IMP

                //redirecting to the details page of the report in question
                return RedirectToAction("Details", "Report", new { id = report.ReportId });
            }
        }


        //This action removes an upvote from a report
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveUpvoteFromReport(int reportID) {
            //We don't need to check if the user is logged in; if the user is not 
            //logged in, the button that invokes this action is never displayed

            //Here I am getting the object of the person who is currently logged in
            User user = null;
            foreach (var claim in User.Claims) {
                if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                    var userEmail = claim.Value;
                    user = _context.Users.Where(u => u.Email == userEmail).SingleOrDefault();
                }
            }

            //Getting the relevant upvote row from the db
            Upvote uv = _context.Upvotes.Where(u => u.ReportId == reportID).Where(u => u.UserId == user.UserId).SingleOrDefault();

            //Getting the report object in question
            Report report = _context.Reports.Where(r => r.ReportId == reportID).SingleOrDefault();
            //decrementing the upvote count
            report.UpVoteCount--;

            //Updating the report object in the db
            _context.Reports.Update(report);
            //Deleting the Upvote object from the db
            _context.Upvotes.Remove(uv);
            await _context.SaveChangesAsync(); //Saving the changes - V.IMP

            //redirecting to the details page of the report in question
            return RedirectToAction("Details", "Report", new { id = report.ReportId });

        }

    }//end of ReportController class
}//end of namespace
