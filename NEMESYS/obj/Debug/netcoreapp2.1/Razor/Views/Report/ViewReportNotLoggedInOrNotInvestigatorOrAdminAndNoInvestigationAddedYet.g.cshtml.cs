#pragma checksum "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ecf71c30d0d5ed61674da80ff0b766102583c911"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet), @"mvc.1.0.view", @"/Views/Report/ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Report/ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml", typeof(AspNetCore.Views_Report_ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\_ViewImports.cshtml"
using NEMESYS;

#line default
#line hidden
#line 2 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\_ViewImports.cshtml"
using NEMESYS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecf71c30d0d5ed61674da80ff0b766102583c911", @"/Views/Report/ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16ab5a5949b63007e87413bab4c69896099f52b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NEMESYS.ViewModels.ReportAndUserUpvoteDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-lg editOrDeleteReportButton"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("deleteReportForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Are you sure you want to delete this report? Any existing investigation will be deleted as well!\');"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("AddOrRemoveUpvoteButton"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpvoteReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveUpvoteFromReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("styled-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetAllReports", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(63, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
  
    ViewData["Title"] = "Report Details";

#line default
#line hidden
            BeginContext(115, 322, true);
            WriteLiteral(@"
<div class=""topRow"">
    <h2 class=""pageTitle"">Report Details</h2>
    <!--Below is some logic that displays an 'Edit Report' and 'Delete Report' Button if the user is logged in and the email
        address of the user that is logged in matches the email address of the reporter who submitted the current report-->
");
            EndContext();
#line 11 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
     if (User.Identity.IsAuthenticated) {
        foreach (var claim in User.Claims) {
            if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress") {
                string userEmail = claim.Value;
                if (userEmail == Model.Report.Reporter.Email) {

#line default
#line hidden
            BeginContext(743, 97, true);
            WriteLiteral("                    <div class=\"containerOfEditAndDeleteReportButtons\">\r\n                        ");
            EndContext();
            BeginContext(840, 142, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "612bc37acc8c4919a346b6afcbb54ac5", async() => {
                BeginContext(967, 11, true);
                WriteLiteral("Edit Report");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-reportID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 17 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                                           WriteLiteral(Model.Report.ReportId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["reportID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-reportID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["reportID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(982, 26, true);
            WriteLiteral("\r\n                        ");
            EndContext();
            BeginContext(1008, 490, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "354a09fd4a6d43e5aeae67d4025367aa", async() => {
                BeginContext(1192, 66, true);
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"reportID\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1258, "\"", 1288, 1);
#line 19 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
WriteAttributeValue("", 1266, Model.Report.ReportId, 1266, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1289, 202, true);
                WriteLiteral(" /><!--IMP to know which report to delete!-->\r\n                            <input type=\"submit\" class=\"btn btn-primary btn-lg editOrDeleteReportButton\" value=\"Delete Report\" />\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1498, 30, true);
            WriteLiteral("\r\n                    </div>\r\n");
            EndContext();
#line 23 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                }
            }
        }
    }

#line default
#line hidden
            BeginContext(1580, 182, true);
            WriteLiteral("</div>\r\n\r\n<hr />\r\n\r\n\r\n<div class=\"row display-row\">\r\n    <div class=\"col-xs-4\">\r\n        <h4><strong>Type of Hazard:</strong></h4>\r\n        <p class=\"ReportAndInvestigationInfoText\">");
            EndContext();
            BeginContext(1763, 51, false);
#line 35 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                             Write(Html.DisplayFor(model => model.Report.TypeOfHazard));

#line default
#line hidden
            EndContext();
            BeginContext(1814, 237, true);
            WriteLiteral("</p>\r\n    </div>\r\n    <div class=\"col-xs-5\">\r\n        <div class=\"row\">\r\n            <div class=\"col-xs-10 col-xs-offset-2\">\r\n                <h4><strong>Location:</strong></h4>\r\n                <p class=\"ReportAndInvestigationInfoText\">");
            EndContext();
            BeginContext(2052, 47, false);
#line 41 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                                     Write(Html.DisplayFor(model => model.Report.Location));

#line default
#line hidden
            EndContext();
            BeginContext(2099, 190, true);
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"col-xs-3\">\r\n        <h4><strong>Date and Time Spotted:</strong></h4>\r\n        <p class=\"ReportAndInvestigationInfoText\">");
            EndContext();
            BeginContext(2290, 66, false);
#line 47 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                             Write(Model.Report.DateAndTimeOfSpotting.ToString("dd/MMM/yyyy h:mm tt"));

#line default
#line hidden
            EndContext();
            BeginContext(2356, 184, true);
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n\r\n\r\n<div class=\"row display-row\">\r\n    <div class=\"col-xs-4\">\r\n        <h4><strong>Priority:</strong></h4>\r\n        <p class=\"ReportAndInvestigationInfoText\">");
            EndContext();
            BeginContext(2541, 47, false);
#line 55 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                             Write(Html.DisplayFor(model => model.Report.Priority));

#line default
#line hidden
            EndContext();
            BeginContext(2588, 235, true);
            WriteLiteral("</p>\r\n    </div>\r\n    <div class=\"col-xs-5\">\r\n        <div class=\"row\">\r\n            <div class=\"col-xs-10 col-xs-offset-2\">\r\n                <h4><strong>Status:</strong></h4>\r\n                <p class=\"ReportAndInvestigationInfoText\">");
            EndContext();
            BeginContext(2824, 45, false);
#line 61 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                                     Write(Html.DisplayFor(model => model.Report.Status));

#line default
#line hidden
            EndContext();
            BeginContext(2869, 422, true);
            WriteLiteral(@"</p>
            </div>
        </div>
    </div>
</div>


<div class=""row display-row"">
    <div class=""col-xs-12"">
        <h4><strong>Location On Map</strong></h4>
        <div id=""Map""></div>
    </div>
</div>


<div class=""row display-row flexRow"">
    <div class=""col-xs-9 flexColumn"">
        <h4><strong>Description</strong></h4>
        <p class=""ReportAndInvestigationInfoText descriptionText"">");
            EndContext();
            BeginContext(3292, 50, false);
#line 79 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                                             Write(Html.DisplayFor(model => model.Report.Description));

#line default
#line hidden
            EndContext();
            BeginContext(3342, 123, true);
            WriteLiteral("</p>\r\n    </div>\r\n    <div class=\"col-xs-3\">\r\n        <h4><strong>Image:</strong></h4>\r\n        <img class=\"img-responsive\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 3465, "\"", 3493, 1);
#line 83 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
WriteAttributeValue("", 3471, Model.Report.PhotoUrl, 3471, 22, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3494, 213, true);
            WriteLiteral(" id=\"reportDetailsImage\">\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n<div class=\"row display-row2\">\r\n    <div class=\"col-xs-4\">\r\n        <h4><strong>Reporter Name:</strong></h4>\r\n        <p class=\"ReportAndInvestigationInfoText\">");
            EndContext();
            BeginContext(3708, 56, false);
#line 92 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                             Write(Html.DisplayFor(model => model.Report.Reporter.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(3764, 104, true);
            WriteLiteral("</p>\r\n    </div>\r\n    <div class=\"col-xs-4\">\r\n        <h4><strong>Reporter Phone Number:</strong></h4>\r\n");
            EndContext();
#line 96 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
         if (Model.Report.Reporter.Phone != null) {

#line default
#line hidden
            BeginContext(3921, 54, true);
            WriteLiteral("            <p class=\"ReportAndInvestigationInfoText\">");
            EndContext();
            BeginContext(3976, 27, false);
#line 97 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                                 Write(Model.Report.Reporter.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(4003, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 98 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
        }
        else {

#line default
#line hidden
            BeginContext(4036, 73, true);
            WriteLiteral("            <p class=\"ReportAndInvestigationInfoText\">Not Specified</p>\r\n");
            EndContext();
#line 101 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
        }

#line default
#line hidden
            BeginContext(4120, 165, true);
            WriteLiteral("    </div>\r\n    <div class=\"col-xs-3 col-xs-offset-1\">\r\n        <h4><strong>Reporter Email Address:</strong></h4>\r\n        <p class=\"ReportAndInvestigationInfoText\">");
            EndContext();
            BeginContext(4286, 53, false);
#line 105 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                             Write(Html.DisplayFor(model => model.Report.Reporter.Email));

#line default
#line hidden
            EndContext();
            BeginContext(4339, 257, true);
            WriteLiteral(@"</p>
    </div>
</div>


<div class=""row bottom-row"">
    <div class=""col-xs-4"">
        <h4><strong>Assigned Investigator:</strong></h4>
        <!--If no investigator (which can be a user with role investigator or admin) has been assigned yet-->
");
            EndContext();
#line 114 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
         if (Model.Report.InvestigatorID == null) {

#line default
#line hidden
            BeginContext(4649, 76, true);
            WriteLiteral("            <p class=\"ReportAndInvestigationInfoText\">Not Assigned Yet</p>\r\n");
            EndContext();
#line 116 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
        }
        //Otherwise, if an investigator (which can be a user with role investigator or admin) has been assigned, display their details
        else {

#line default
#line hidden
            BeginContext(4888, 82, true);
            WriteLiteral("            <p class=\"ReportAndInvestigationInfoText\"><strong>Full Name: </strong>");
            EndContext();
            BeginContext(4971, 34, false);
#line 119 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                                                             Write(Model.Report.Investigator.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(5005, 84, true);
            WriteLiteral("</p>\r\n            <p class=\"ReportAndInvestigationInfoText\"><strong>Email: </strong>");
            EndContext();
            BeginContext(5090, 31, false);
#line 120 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                                                         Write(Model.Report.Investigator.Email);

#line default
#line hidden
            EndContext();
            BeginContext(5121, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 121 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
            //If the assigned investigator has added their phone, then display it
            if (Model.Report.Investigator.Phone != null) {

#line default
#line hidden
            BeginContext(5270, 82, true);
            WriteLiteral("                <p class=\"ReportAndInvestigationInfoText\"><strong>Phone: </strong>");
            EndContext();
            BeginContext(5353, 31, false);
#line 123 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                                                             Write(Model.Report.Investigator.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(5384, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 124 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(5416, 272, true);
            WriteLiteral(@"    </div>
    <div class=""col-xs-4"">
        <h4><strong>Investigation:</strong></h4>
        <p class=""ReportAndInvestigationInfoText"">No Investigation has been added yet!</p>
    </div>
</div>


<div class=""footerInfo"">
    <span><strong>Date Posted: </strong>");
            EndContext();
            BeginContext(5689, 53, false);
#line 135 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                                   Write(Model.Report.DateOfSubmission.ToString("dd/MMM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(5742, 67, true);
            WriteLiteral("</span> &nbsp&nbsp|&nbsp&nbsp\r\n    <span><strong>Upvotes: </strong>");
            EndContext();
            BeginContext(5810, 50, false);
#line 136 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                               Write(Html.DisplayFor(model => model.Report.UpVoteCount));

#line default
#line hidden
            EndContext();
            BeginContext(5860, 176, true);
            WriteLiteral("</span>  &nbsp&nbsp|&nbsp&nbsp\r\n\r\n    <!--Depending on whether a user has upvoted the current report or not, display the appropriate form(just clickable text in this case)-->\r\n");
            EndContext();
#line 139 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
     if (Model.HasUpvoted == false) {

#line default
#line hidden
            BeginContext(6075, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(6083, 300, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7c8e8e878f444443a485f95a536221e0", async() => {
                BeginContext(6147, 50, true);
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"reportID\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 6197, "\"", 6227, 1);
#line 141 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
WriteAttributeValue("", 6205, Model.Report.ReportId, 6205, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(6228, 148, true);
                WriteLiteral(" /><!--IMP to know which report to upvote!-->\r\n            <input type=\"submit\" class=\"styled-submit-button\" value=\"Upvote this Report\" />\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6383, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 144 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
    }
    else {

#line default
#line hidden
            BeginContext(6404, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(6412, 317, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42f82de2ba4d45309a4c6da0dd57ff21", async() => {
                BeginContext(6486, 50, true);
                WriteLiteral("\r\n            <input type=\"hidden\" name=\"reportID\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 6536, "\"", 6566, 1);
#line 147 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
WriteAttributeValue("", 6544, Model.Report.ReportId, 6544, 22, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(6567, 155, true);
                WriteLiteral(" /><!--IMP to know which report to remove upvote from!-->\r\n            <input type=\"submit\" class=\"styled-submit-button\" value=\"Remove Upvote\" />\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6729, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 150 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
    }

#line default
#line hidden
            BeginContext(6738, 33, true);
            WriteLiteral("\r\n    &nbsp&nbsp|&nbsp&nbsp\r\n    ");
            EndContext();
            BeginContext(6771, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0547383ceef84573842a083cfccae1d8", async() => {
                BeginContext(6821, 24, true);
                WriteLiteral("Back to All Reports List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6849, 156, true);
            WriteLiteral("\r\n</div>\r\n\r\n<script>\r\n    function initMap() {\r\n\r\n        //Getting the latitude and longitude and storing them in variables\r\n        var latitude = Number(");
            EndContext();
            BeginContext(7006, 21, false);
#line 160 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                         Write(Model.Report.Latitude);

#line default
#line hidden
            EndContext();
            BeginContext(7027, 35, true);
            WriteLiteral(");\r\n        var longitude = Number(");
            EndContext();
            BeginContext(7063, 22, false);
#line 161 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\ViewReportNotLoggedInOrNotInvestigatorOrAdminAndNoInvestigationAddedYet.cshtml"
                          Write(Model.Report.Longitude);

#line default
#line hidden
            EndContext();
            BeginContext(7085, 758, true);
            WriteLiteral(@");

        //Map options object
        var options = {
            zoom: 16,
            center: { lat: latitude, lng: longitude }
        }

        //Creating new map
        var map = new google.maps.Map(document.getElementById('Map'), options);

        //This will place a marker where the user has dropped it when creating the report
        var marker = new google.maps.Marker({
            position: { lat: latitude, lng: longitude },
            map: map
        });

    }//end of initMap() function
</script>


<!--Here I include my API key for the Google Maps API Service-->
<script async defer
        src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyARRHH45Hg1tafN2ZyMQaSVRR5tk3lleA8&callback=initMap"">
</script>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NEMESYS.ViewModels.ReportAndUserUpvoteDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
