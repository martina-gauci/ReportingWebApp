#pragma checksum "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6cc0c98d786a690631c3f0d48ccfe084bfe38f74"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_GetYourReports), @"mvc.1.0.view", @"/Views/Report/GetYourReports.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Report/GetYourReports.cshtml", typeof(AspNetCore.Views_Report_GetYourReports))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6cc0c98d786a690631c3f0d48ccfe084bfe38f74", @"/Views/Report/GetYourReports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16ab5a5949b63007e87413bab4c69896099f52b9", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_GetYourReports : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NEMESYS.Models.Report>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("createNewReportButton"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "GET", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Report", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetYourReports", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Open", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "BeingInvestigated", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Closed", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "NoActionRequired", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("styled-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
  
    ViewData["Title"] = "Your Reports";

#line default
#line hidden
            BeginContext(93, 127, true);
            WriteLiteral("\r\n<div class=\"HeadingRow\">\r\n    <h2 class=\"heading-left\">Your Submitted Reports</h2>\r\n\r\n    <p class=\"heading-right\">\r\n        ");
            EndContext();
            BeginContext(220, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02aa4fcee5c0477bb0f5cb1395282f03", async() => {
                BeginContext(279, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(293, 43, true);
            WriteLiteral("\r\n    </p>\r\n</div>\r\n\r\n<hr />\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(336, 491, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c66d6da6ff3e4c23b9408d2d5b9ffdb6", async() => {
                BeginContext(407, 413, true);
                WriteLiteral(@"
        <p>
            <div class=""FilterBy"">
                Hazard Type:
            </div>
            <div class=""FilterInputFieldContainer"">
                <input class=""FilterInputField1"" type=""text"" name=""searchString"">
            </div>
            <div class=""FilterButton"">
                <input class=""styled-btn-sm"" type=""submit"" value=""Filter"" />
            </div>
        </p>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(827, 23, true);
            WriteLiteral("\r\n</div>\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(850, 857, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "679de42b2d044c7798558afc4b29f3b8", async() => {
                BeginContext(921, 262, true);
                WriteLiteral(@"
        <p>
            <div class=""FilterBy"">
                Report Status:
            </div>
            <div class=""FilterInputFieldContainer"">
                <select type=""submit"" name=""statusString"" class=""FilterInputField2"">
                    ");
                EndContext();
                BeginContext(1183, 31, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7404fd80cf1b494a91d60c7d685550fe", async() => {
                    BeginContext(1200, 5, true);
                    WriteLiteral(" All ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1214, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(1236, 34, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2158bf13fbe64a85a6412eb574b8cf57", async() => {
                    BeginContext(1257, 4, true);
                    WriteLiteral("Open");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1270, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(1292, 61, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63bc9194b93f4f82a446af3ff21cf8b1", async() => {
                    BeginContext(1326, 18, true);
                    WriteLiteral("Being Investigated");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1353, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(1375, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa5a5a0193394964830769ddec76e0c5", async() => {
                    BeginContext(1398, 6, true);
                    WriteLiteral("Closed");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1413, 22, true);
                WriteLiteral("\r\n                    ");
                EndContext();
                BeginContext(1435, 60, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fe8191be04142cf94171b1b82e7b5fa", async() => {
                    BeginContext(1468, 18, true);
                    WriteLiteral("No Action Required");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1495, 205, true);
                WriteLiteral("\r\n                </select>\r\n            </div>\r\n            <div class=\"FilterButton\">\r\n                <input class=\"styled-btn-sm\" type=\"submit\" value=\"Filter\" />\r\n            </div>\r\n        </p>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1707, 110, true);
            WriteLiteral("\r\n</div>\r\n\r\n<br />\r\n\r\n<!--If the IEnumerable does not contain any reports, display an appropriate message-->\r\n");
            EndContext();
#line 58 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
 if (Model == null || !Model.Any()) {

#line default
#line hidden
            BeginContext(1856, 69, true);
            WriteLiteral("    <hr />\r\n    <h2 class=\"NoReportsMessage\">No Reports Found!</h2>\r\n");
            EndContext();
#line 61 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
}
//Otherwise(i.e. if the IEnumerable does contain reports), display their details
else {

#line default
#line hidden
            BeginContext(2018, 104, true);
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(2123, 44, false);
#line 68 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
               Write(Html.DisplayNameFor(model => model.Reporter));

#line default
#line hidden
            EndContext();
            BeginContext(2167, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(2235, 48, false);
#line 71 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
               Write(Html.DisplayNameFor(model => model.Investigator));

#line default
#line hidden
            EndContext();
            BeginContext(2283, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(2351, 42, false);
#line 74 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
               Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(2393, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(2461, 47, false);
#line 77 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
               Write(Html.DisplayNameFor(model => model.UpVoteCount));

#line default
#line hidden
            EndContext();
            BeginContext(2508, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(2576, 48, false);
#line 80 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
               Write(Html.DisplayNameFor(model => model.TypeOfHazard));

#line default
#line hidden
            EndContext();
            BeginContext(2624, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(2692, 52, false);
#line 83 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
               Write(Html.DisplayNameFor(model => model.DateOfSubmission));

#line default
#line hidden
            EndContext();
            BeginContext(2744, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(2812, 44, false);
#line 86 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
               Write(Html.DisplayNameFor(model => model.Priority));

#line default
#line hidden
            EndContext();
            BeginContext(2856, 106, true);
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 92 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
             foreach (var item in Model) {

#line default
#line hidden
            BeginContext(3006, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3079, 52, false);
#line 95 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Reporter.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(3131, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 98 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
                         if (item.InvestigatorID == null) {

#line default
#line hidden
            BeginContext(3247, 59, true);
            WriteLiteral("                            <span>Not Assigned Yet</span>\r\n");
            EndContext();
#line 100 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
                        }
                        else {

#line default
#line hidden
            BeginContext(3365, 34, true);
            WriteLiteral("                            <span>");
            EndContext();
            BeginContext(3400, 26, false);
#line 102 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
                             Write(item.Investigator.FullName);

#line default
#line hidden
            EndContext();
            BeginContext(3426, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 103 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
                        }

#line default
#line hidden
            BeginContext(3462, 77, true);
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3540, 41, false);
#line 106 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
            EndContext();
            BeginContext(3581, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3661, 46, false);
#line 109 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
                   Write(Html.DisplayFor(modelItem => item.UpVoteCount));

#line default
#line hidden
            EndContext();
            BeginContext(3707, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3787, 47, false);
#line 112 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TypeOfHazard));

#line default
#line hidden
            EndContext();
            BeginContext(3834, 91, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td type=\"Date\">\r\n                        ");
            EndContext();
            BeginContext(3926, 45, false);
#line 115 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
                   Write(item.DateOfSubmission.ToString("dd/MMM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(3971, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4051, 43, false);
#line 118 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Priority));

#line default
#line hidden
            EndContext();
            BeginContext(4094, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4173, 85, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca6b718167184721a74d3655f5ba5eaa", async() => {
                BeginContext(4247, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 121 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
                                                                      WriteLiteral(item.ReportId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4258, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 124 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
            }

#line default
#line hidden
            BeginContext(4325, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 127 "C:\Users\user\Desktop\Assignments - Semester 4\Web Assignment\FINAL ACTUAL IMPLEMENTATION\NEMESYS\NEMESYS\Views\Report\GetYourReports.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NEMESYS.Models.Report>> Html { get; private set; }
    }
}
#pragma warning restore 1591
