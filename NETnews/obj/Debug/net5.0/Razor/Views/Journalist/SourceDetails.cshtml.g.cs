#pragma checksum "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\Journalist\SourceDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "535ba83753b861b5f3136fbebd184c0d0760623e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Journalist_SourceDetails), @"mvc.1.0.view", @"/Views/Journalist/SourceDetails.cshtml")]
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
#line 1 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\_ViewImports.cshtml"
using NETnews;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\_ViewImports.cshtml"
using NETnews.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"535ba83753b861b5f3136fbebd184c0d0760623e", @"/Views/Journalist/SourceDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"548e23072c3d8d469a575a48f2b4ce1204711bbe", @"/Views/_ViewImports.cshtml")]
    public class Views_Journalist_SourceDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<News>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\Journalist\SourceDetails.cshtml"
  
    ViewData["Title"] = "List of News";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\Journalist\SourceDetails.cshtml"
 foreach(var item in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span>");
#nullable restore
#line 8 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\Journalist\SourceDetails.cshtml"
     Write(item.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    <br>\r\n");
#nullable restore
#line 10 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\Journalist\SourceDetails.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<News>> Html { get; private set; }
    }
}
#pragma warning restore 1591
