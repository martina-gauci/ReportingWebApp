using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NEMESYS.Models;
using NEMESYS.ViewModels;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace NEMESYS.Controllers{
    public class InvestigationController : Controller{
        private readonly NemesysContext _context;

        //Constructor; The value passed into this parameter is passed from the IServicesCollection through dependency injection.
        //Like this we have access to an instance of the NemesysContext class (which contains the DB provider and connection string) inside this controller
        public InvestigationController(NemesysContext context){
            _context = context;
        }


        //This method returns the form to create a new investigation
        public IActionResult CreateInvestigation(int? forReportID) {

            //If the user tries to enter the url without a report id, give him a 404
            if (forReportID == null) {
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

            //Here I am getting the report object of the report in question
            Report report = _context.Reports.Where(r => r.ReportId == forReportID).SingleOrDefault();

            //Here I am getting the investigation object (if any) related to the report in question
            Investigation investigation = _context.Investigations.Where(i => i.ReportId == forReportID).SingleOrDefault();

            //If the user tries to access this page through the url, and enters a reportID of a report  
            //that does not exist in the query string, then redirect them to the GetAllReports page
            if (report == null) {
               return RedirectToAction("GetAllReports", "Report");
            }
       
            //If the user either is not logged in, or no investigator has been assigned to the report in question,
            //and the user tries to access this page, then redirect them to the details page
            if (!User.Identity.IsAuthenticated || report.InvestigatorID == null) {
                return RedirectToAction("Details", "Report", new { id = forReportID });
            }

            //If not all three of the following conditions are met, then redirect the user to the details page of the report:
            //1) The logged in user is an investigator (i.e. user with role investigator or admin)
            //2) The logged in user is the assigned investigator of the report in question
            //3) No investigation already exists for the report in question
            if (User.Identity.IsAuthenticated) {
                if (!(user.Role != roles.Reporter && user.UserId == report.InvestigatorID && investigation == null)) {
                    return RedirectToAction("Details", "Report", new { id = forReportID });
                }
            }

            //The code above does not let users who meet the conditions specified above to view 
            //the page returned by this controller method by typing in the corresponding URL

            //I want to pass more than just an investigation to the view, so I have to use a ViewModel
            InvestigationAndReportViewModel vm = new InvestigationAndReportViewModel {
                Investigation = null,
                Report = report
            };

            return View(vm);
        }


        //This post action method adds a new investigation to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateInvestigation(int reportID, int setStatus, [Bind("DateOfAction, Description")] Investigation investigation) { //The Bind maps the fields from the form into the properties of the Investigation object
            if (ModelState.IsValid) {//If the posted form data is valid   
                //Creating a new investigation object (using the predefined constructor in the investigation class)
                Investigation investigationToAdd = new Investigation(); 
                investigationToAdd.ReportId = reportID;
                investigationToAdd.DateOfAction = investigation.DateOfAction;
                investigationToAdd.Description = investigation.Description;

                //Here I am getting the report object to which the investigation in question is related
                Report repToUpdate = _context.Reports.Where(r => r.ReportId == reportID).SingleOrDefault();
                repToUpdate.Status = (status)setStatus;

                _context.Reports.Update(repToUpdate); //Update the reports table
                _context.Investigations.Add(investigationToAdd); //Add the new investigation to the investigations table
                await _context.SaveChangesAsync();//V.IMP to save changes!

                //We want to send an email to the user when an investigation is added to their report
                //Here I am getting the object of the user who submitted the report in question
                User user = _context.Users.Where(u => u.UserId == repToUpdate.ReporterId).SingleOrDefault();
                //Here I am storing the link to the investigation in question
                string link = "https://localhost:44366/Investigation/ViewInvestigation?forReportID=" + reportID.ToString();

                //Instantiate a new MimeMessage
                var message = new MimeMessage();
                //From address (including name and email of sender). This will always be the same
                message.From.Add(new MailboxAddress("NEMESYS", "nemesysapp@gmail.com"));
                //To address (including name and email of receipient)
                message.To.Add(new MailboxAddress(user.FullName, user.Email));
                //Subject
                message.Subject = "An Investigation has been Added to your Report \""+ repToUpdate.TypeOfHazard +"\"";
                //Body - I want to send HTML rather than just plain text, so I have to user a BodyBuilder object
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<h1 style='text-align:center; font-family: Arial;'>An Investigation has been added to Your Report <br/> <span style='font-size:32px;font-weight:300;font-family: Courier New;'>\"" + repToUpdate.TypeOfHazard + "\"</span></h1>" +
                                       "<br/><span style='display:block;text-align:center;margin-bottom:15px;'><a href='" + link + "' style='font-size:22px;color:white;background-color:#BA0C2F;text-decoration:none;padding:15px;'>View Investigation</a></span>";
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

                return RedirectToAction("Details", "Report", new { id = reportID });
            }
            else {
                //If posted form data is invalid, stay on the create report page
                return RedirectToAction("CreateInvestigation", "Investigation", new { forReportID = reportID });
            }
        }


        public async Task<IActionResult> ViewInvestigation(int? forReportID) {

            //If the user tries to enter the url without a report id, give him a 404
            if (forReportID == null) {
                return NotFound();
            }
   
            //Here I am getting the Investigation object of the investigation in question, including with it the Report object
            //it is associated to, as well as the object of the Reporter User and the object of the Investigator User
            var investigation = await _context.Investigations.Include(inv => inv.Report).ThenInclude(rep => rep.Reporter).Include(inv => inv.Report).ThenInclude(rep => rep.Investigator).FirstOrDefaultAsync(inv => inv.ReportId == forReportID);
            //if the returned object is null (because the user would have entered a report id for which an investigation does not exist in the url),
            //then redirect them to the GetAllReports Action Method, otherwise return the view associated with this controller action
            if (investigation == null) {
                return RedirectToAction("GetAllReports", "Report");
            }
            else {
                return View(investigation);
            }
        }


        //This is the get method to edit an investigation; it returns the edit investigation view
        public IActionResult EditInvestigation(int? forReportID) {

            //If the user tries to enter the url without a report id, give him a 404
            if (forReportID == null) {
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

            //Here I am getting the report object to which the investigation in question is related
            Report report = _context.Reports.Where(r => r.ReportId == forReportID).SingleOrDefault();

            //Here I am getting the investigation object in question(if any) 
            Investigation investigation = _context.Investigations.Where(i => i.ReportId == forReportID).SingleOrDefault();

            //If the user tries to access this page through the url, and enters a reportID of a report  
            //that does not exist in the query string, then redirect them to the GetAllReports page
            if (report == null) {
                return RedirectToAction("GetAllReports", "Report");
            }

            //If the user either is not logged in, or no investigator has been assigned to the report in question,
            //and the user tries to access this page, then redirect him to the details page
            if (!User.Identity.IsAuthenticated || report.InvestigatorID == null) {
                return RedirectToAction("Details", "Report", new { id = forReportID });
            }

            //To edit a report, all of the following three conditions must be met:
            //1) The logged in user is an investigator (i.e. a user with role investigator or admin)
            //2) The logged in user is the assigned investigator of the report in question
            //3) An investigation already exists for the report in question
            if (User.Identity.IsAuthenticated) {
                if (!(user.Role != roles.Reporter && user.UserId == report.InvestigatorID && investigation != null)) {
                    return RedirectToAction("Details", "Report", new { id = forReportID });
                }
            }
            //If not all three of the conditions above are met, then redirect the user to the details page of the report

            //The code above does not let users who meet the conditions specified above to view 
            //the page returned by this controller method by typing in the corresponding URL

            //Getting the investigation object in question, including with it the report object which it is related to
            var inv = _context.Investigations.Include(i => i.Report).FirstOrDefault(i => i.ReportId == forReportID);
            return View(inv);//Returning the form to edit the report, with fields already populated
        }


        //This is the post method to edit the investigation; it updates the db
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInvestigation([Bind("InvestigationId, ReportId, DateOfSubmission, DateOfAction, Description")] Investigation investigation) {//The Bind maps the fields from the form into the properties of the Investigation object
            if (ModelState.IsValid) {//If the posted form data is valid             
                _context.Investigations.Update(investigation);
                await _context.SaveChangesAsync(); //Saving the changes - V.IMP

                //We want to send an email to the user when an investigation relating to their report is updated
                //Here I am getting the report related to the investigation that is being updated
                Report report = _context.Reports.Where(r => r.ReportId == investigation.ReportId).SingleOrDefault();
                //Here I am getting the object of the user who submitted the report related to the investigation that is being updated
                User user = _context.Users.Where(u => u.UserId == report.ReporterId).SingleOrDefault();
                //Here I am storing the link to the view investigation page of the investigation that is being updated
                string link = "https://localhost:44366/Investigation/ViewInvestigation?forReportID=" + report.ReportId.ToString();

                //Instantiate a new MimeMessage
                var message = new MimeMessage();
                //From address (including name and email of sender). This will always be the same
                message.From.Add(new MailboxAddress("NEMESYS", "nemesysapp@gmail.com"));
                //To address (including name and email of receipient)
                message.To.Add(new MailboxAddress(user.FullName, user.Email));
                //Subject
                message.Subject = "The Investigation to your Report \"" + report.TypeOfHazard + "\" has been Updated";
                //Body - I want to send HTML rather than just plain text, so I have to user a BodyBuilder object
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<h1 style='text-align:center; font-family: Arial;'>The Investigation to Your Report <br/> <span style='font-size:32px;font-weight:300;font-family: Courier New;'>\"" + report.TypeOfHazard + "\"</span><br/>has been Updated</h1>" +
                                       "<br/><span style='display:block;text-align:center;margin-bottom:15px;'><a href='" + link + "' style='font-size:22px;color:white;background-color:#BA0C2F;text-decoration:none;padding:15px;'>View Investigation</a></span>";
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

                return RedirectToAction("ViewInvestigation", "Investigation", new { forReportID = investigation.ReportId });
            }
            else {
                //If posted form data is invalid, stay on the edit investigation details page
                return RedirectToAction("EditInvestigation", "Investigation", new { forReportID = investigation.ReportId });
            }
        }


    }//end of controller
}//end of namespace
