#pragma checksum "C:\Users\johan\source\repos\Hotel 5\Hotel 5\Views\Bookings\WrongDateError.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86e4ce0b14890212074fd2a3993ff00dc8402790"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bookings_WrongDateError), @"mvc.1.0.view", @"/Views/Bookings/WrongDateError.cshtml")]
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
#nullable restore
#line 1 "C:\Users\johan\source\repos\Hotel 5\Hotel 5\Views\_ViewImports.cshtml"
using Hotel_5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\johan\source\repos\Hotel 5\Hotel 5\Views\_ViewImports.cshtml"
using Hotel_5.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86e4ce0b14890212074fd2a3993ff00dc8402790", @"/Views/Bookings/WrongDateError.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fab1bb6d0d6a35706c85e685a4556ecf79aff5a", @"/Views/_ViewImports.cshtml")]
    public class Views_Bookings_WrongDateError : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\johan\source\repos\Hotel 5\Hotel 5\Views\Bookings\WrongDateError.cshtml"
  
    ViewData["Title"] = "Wrong Dates";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n    window.setTimeout(function(){\r\nwindow.location.href=\'Create\';\r\n}, 3500);\r\n</script>\r\n\r\n<h1>The check in date cannot be greater than the check out date</h1>\r\n<h3>You will be redirected to the Booking page.</h3>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
