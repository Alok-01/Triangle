#pragma checksum "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b8861a871817b5dc0645a33a4b8e36e56d3ec9c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Error), @"mvc.1.0.view", @"/Views/Home/Error.cshtml")]
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
#line 1 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\_ViewImports.cshtml"
using Triangle.MvcClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\_ViewImports.cshtml"
using Triangle.MvcClient.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\_ViewImports.cshtml"
using Triangle.MvcClient.Controllers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\_ViewImports.cshtml"
using Triangle.StudentViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\_ViewImports.cshtml"
using Triangle.Common.CommonModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b8861a871817b5dc0645a33a4b8e36e56d3ec9c", @"/Views/Home/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"914be5328c9b96a8e1ec398667ad781d586c6619", @"/_ViewImports.cshtml")]
    public class Views_Home_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Triangle.MvcClient.Models.ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
 if (this.User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Error in Triangle Page</h1>\r\n");
#nullable restore
#line 8 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-danger\">Error.</h1>\r\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\r\n\r\n");
#nullable restore
#line 13 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
 if (Model.ShowRequestId)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        <strong>Request ID:</strong> <code>");
#nullable restore
#line 16 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
                                      Write(Model.RequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\r\n    </p>\r\n");
#nullable restore
#line 18 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
 if (!string.IsNullOrEmpty(Model.ApiRoute))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        <strong>API Route:</strong> <code>");
#nullable restore
#line 22 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
                                     Write(Model.ApiRoute);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\r\n        <br />\r\n        <strong>API Status:</strong> <code>");
#nullable restore
#line 24 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
                                      Write(Model.ApiStatus);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\r\n        <br />\r\n        <strong>API ErrorID:</strong> <code>");
#nullable restore
#line 26 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
                                       Write(Model.ApiErrorId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\r\n        <br />\r\n        <strong>API Title:</strong> <code>");
#nullable restore
#line 28 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
                                     Write(Model.ApiTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\r\n        <br />\r\n        <strong>API Detail:</strong> <code>");
#nullable restore
#line 30 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
                                      Write(Model.ApiDetail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\r\n    </p>\r\n");
#nullable restore
#line 32 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Error.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Triangle.MvcClient.Models.ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591