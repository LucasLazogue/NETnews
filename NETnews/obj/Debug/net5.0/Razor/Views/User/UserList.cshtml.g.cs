#pragma checksum "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\User\UserList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b187c22d195905308ce84ccee261926a20922598"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_UserList), @"mvc.1.0.view", @"/Views/User/UserList.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\User\UserList.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\User\UserList.cshtml"
using NETnews.Data.ViewData;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b187c22d195905308ce84ccee261926a20922598", @"/Views/User/UserList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"548e23072c3d8d469a575a48f2b4ce1204711bbe", @"/Views/_ViewImports.cshtml")]
    public class Views_User_UserList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\User\UserList.cshtml"
  
    ViewData["Title"] = "List of Users";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\User\UserList.cshtml"
 if (User.Identity.IsAuthenticated && User.IsInRole("Admin")) {
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\User\UserList.cshtml"
     foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span>");
#nullable restore
#line 12 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\User\UserList.cshtml"
         Write(item.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        <br>\r\n");
#nullable restore
#line 14 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\User\UserList.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\User\UserList.cshtml"
     
}
else {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span>You don\'t have permisson to access here!</span>\r\n");
#nullable restore
#line 18 "C:\Users\Lucas\source\repos\NETnews\NETnews\Views\User\UserList.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591