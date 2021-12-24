#pragma checksum "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterMessageNotification\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99e18f89d47d3b2522b097cd4a0db2fdc893e115"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_WriterMessageNotification_Default), @"mvc.1.0.view", @"/Views/Shared/Components/WriterMessageNotification/Default.cshtml")]
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
#line 1 "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\_ViewImports.cshtml"
using CoreDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\_ViewImports.cshtml"
using CoreDemo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\_ViewImports.cshtml"
using CoreDemo.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterMessageNotification\Default.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99e18f89d47d3b2522b097cd4a0db2fdc893e115", @"/Views/Shared/Components/WriterMessageNotification/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3e273681fe023035aba1d643f355c88c8bae0c4", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_WriterMessageNotification_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Message2>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterMessageNotification\Default.cshtml"
  
    string sure = "";
    DateTime now = DateTime.Now;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"dropdown-menu dropdown-menu-right navbar-dropdown preview-list\" aria-labelledby=\"messageDropdown\">\r\n    <h6 class=\"p-3 mb-0\">Mesajlar</h6>\r\n");
#nullable restore
#line 9 "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterMessageNotification\Default.cshtml"
     foreach (var item in Model)
    {
        TimeSpan zaman = now.Subtract(item.MessageDate);

        if (zaman.Days == 0)
        {
            if (zaman.Minutes == 0 && zaman.Hours == 0)
            {
                sure = "Şimdi";
            }
            else if (zaman.Minutes > 0 && zaman.Hours == 0)
            {
                sure = zaman.Minutes + " dakika önce";
            }
            else
            {
                sure = zaman.Hours + " saat " + zaman.Minutes + " dakika önce";
            }
        }
        else
        {
            if (zaman.Hours == 0)
            {
                sure = zaman.Days + " gün önce";
            }
            else
            {
                sure = zaman.Days + " gün " + zaman.Hours + " saat önce";
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"dropdown-divider\"></div>\r\n        <a class=\"dropdown-item preview-item\">\r\n            <div class=\"preview-thumbnail\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 1250, "\"", 1284, 1);
#nullable restore
#line 42 "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterMessageNotification\Default.cshtml"
WriteAttributeValue("", 1256, item.SenderUser.WriterImage, 1256, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"image\" class=\"profile-pic\">\r\n            </div>\r\n            <div class=\"preview-item-content d-flex align-items-start flex-column justify-content-center\">\r\n                <h6 class=\"preview-subject ellipsis mb-1 font-weight-normal\">");
#nullable restore
#line 45 "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterMessageNotification\Default.cshtml"
                                                                        Write(item.SenderUser.WriterName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" sana mesaj gönderdi</h6>\r\n                <p class=\"text-gray mb-0\">\r\n                    ");
#nullable restore
#line 47 "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterMessageNotification\Default.cshtml"
               Write(sure);

#line default
#line hidden
#nullable disable
            WriteLiteral(" gönderildi\r\n                </p>\r\n            </div>\r\n        </a>\r\n");
#nullable restore
#line 51 "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterMessageNotification\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"dropdown-divider\"></div>\r\n    <h6 class=\"p-3 mb-0 text-center\">");
#nullable restore
#line 53 "C:\Users\Burak\Documents\GitHub\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterMessageNotification\Default.cshtml"
                                Write(ViewBag.NewMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral(" yeni mesaj</h6>\r\n    <div class=\"dropdown-divider\"></div>\r\n    <a href=\"/Message/Inbox\"><h6 class=\"p-3 mb-0 text-center\">Tüm Mesajları Gör</h6></a>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Message2>> Html { get; private set; }
    }
}
#pragma warning restore 1591
