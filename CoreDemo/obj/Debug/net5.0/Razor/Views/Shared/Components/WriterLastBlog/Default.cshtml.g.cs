#pragma checksum "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterLastBlog\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8aa95a031369162904f2a3d7e273816e339c52e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_WriterLastBlog_Default), @"mvc.1.0.view", @"/Views/Shared/Components/WriterLastBlog/Default.cshtml")]
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
#line 1 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\_ViewImports.cshtml"
using CoreDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\_ViewImports.cshtml"
using CoreDemo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\_ViewImports.cshtml"
using CoreDemo.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterLastBlog\Default.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8aa95a031369162904f2a3d7e273816e339c52e", @"/Views/Shared/Components/WriterLastBlog/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3e273681fe023035aba1d643f355c88c8bae0c4", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_WriterLastBlog_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Blog>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"tech-btm\">\r\n    <h4>Yazarın Diğer Yazıları</h4>\r\n");
#nullable restore
#line 6 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterLastBlog\Default.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"blog-grids row mb-3\">\r\n            <div class=\"col-md-5 blog-grid-left\">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 264, "\"", 301, 2);
            WriteAttributeValue("", 271, "/Blog/BlogReadAll/", 271, 18, true);
#nullable restore
#line 10 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterLastBlog\Default.cshtml"
WriteAttributeValue("", 289, item.BlogID, 289, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 329, "\"", 350, 1);
#nullable restore
#line 11 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterLastBlog\Default.cshtml"
WriteAttributeValue("", 335, item.BlogImage, 335, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("alt", " alt=\"", 369, "\"", 375, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </a>\r\n            </div>\r\n            <div class=\"col-md-7 blog-grid-right\">\r\n\r\n                <h5>\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 519, "\"", 556, 2);
            WriteAttributeValue("", 526, "/Blog/BlogReadAll/", 526, 18, true);
#nullable restore
#line 17 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterLastBlog\Default.cshtml"
WriteAttributeValue("", 544, item.BlogID, 544, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 17 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterLastBlog\Default.cshtml"
                                                        Write(item.BlogTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a>\r\n                </h5>\r\n                <div class=\"sub-meta\">\r\n                    <span>\r\n                        <i class=\"far fa-clock\"></i> ");
#nullable restore
#line 21 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterLastBlog\Default.cshtml"
                                                Write(item.BlogCreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </span>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 26 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Shared\Components\WriterLastBlog\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Blog>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
