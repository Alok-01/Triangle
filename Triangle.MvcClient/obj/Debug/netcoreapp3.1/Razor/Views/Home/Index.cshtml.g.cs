#pragma checksum "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "55f42f864c3d0663615d15892ef382de02c2266d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55f42f864c3d0663615d15892ef382de02c2266d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"914be5328c9b96a8e1ec398667ad781d586c6619", @"/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Index.cshtml"
 if (this.User.Identity.IsAuthenticated)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Welcome to Triangle</h1>\r\n");
#nullable restore
#line 7 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 9 "D:\Github\Alok-01\Triangle\Triangle.MvcClient\Views\Home\Index.cshtml"
Write(Context.User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<hr />");
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