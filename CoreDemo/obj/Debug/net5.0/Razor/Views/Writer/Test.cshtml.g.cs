#pragma checksum "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Writer\Test.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9dda65ca6a8f2ddf514797e9adcb12c2db7ac36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Writer_Test), @"mvc.1.0.view", @"/Views/Writer/Test.cshtml")]
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
#line 4 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\_ViewImports.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\_ViewImports.cshtml"
using EntityLayer.DTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9dda65ca6a8f2ddf514797e9adcb12c2db7ac36", @"/Views/Writer/Test.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82429cdebbbf1c616feac6277cada6c5bb8457d7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Writer_Test : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\burak\source\repos\BurakTemelkaya\ASP.NET_Core_5.0-ProjeKampi\CoreDemo\Views\Writer\Test.cshtml"
  
    ViewData["Title"] = "Test";
    Layout = "~/Views/Shared/WriterLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""content-wrapper"">
    <div class=""page-header"">
        <h3 class=""page-title""> Basic Tables </h3>
        <nav aria-label=""breadcrumb"">
            <ol class=""breadcrumb"">
                <li class=""breadcrumb-item""><a href=""#"">Tables</a></li>
                <li class=""breadcrumb-item active"" aria-current=""page"">Basic tables</li>
            </ol>
        </nav>
    </div>
    <div class=""row"">
        <div class=""col-lg-6 grid-margin stretch-card"">
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""card-title"">Basic Table</h4>
                    <p class=""card-description"">
                        Add class <code>.table</code>
                    </p>
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th>Profile</th>
                                <th>VatNo.</th>
                                <th>Created</th>
                  ");
            WriteLiteral(@"              <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Jacob</td>
                                <td>53275531</td>
                                <td>12 May 2017</td>
                                <td><label class=""badge badge-danger"">Pending</label></td>
                            </tr>
                            <tr>
                                <td>Messsy</td>
                                <td>53275532</td>
                                <td>15 May 2017</td>
                                <td><label class=""badge badge-warning"">In progress</label></td>
                            </tr>
                            <tr>
                                <td>John</td>
                                <td>53275533</td>
                                <td>14 May 2017</td>
                                <td><label class=""badge badge-info"">Fix");
            WriteLiteral(@"ed</label></td>
                            </tr>
                            <tr>
                                <td>Peter</td>
                                <td>53275534</td>
                                <td>16 May 2017</td>
                                <td><label class=""badge badge-success"">Completed</label></td>
                            </tr>
                            <tr>
                                <td>Dave</td>
                                <td>53275535</td>
                                <td>20 May 2017</td>
                                <td><label class=""badge badge-warning"">In progress</label></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""col-lg-6 grid-margin stretch-card"">
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""card-title"">Hoverable Table</h4>
                  ");
            WriteLiteral(@"  <p class=""card-description"">
                        Add class <code>.table-hover</code>
                    </p>
                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                                <th>User</th>
                                <th>Product</th>
                                <th>Sale</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>Jacob</td>
                                <td>Photoshop</td>
                                <td class=""text-danger""> 28.76% <i class=""mdi mdi-arrow-down""></i></td>
                                <td><label class=""badge badge-danger"">Pending</label></td>
                            </tr>
                            <tr>
                                <td>Messsy</td>
                                <td>Fla");
            WriteLiteral(@"sh</td>
                                <td class=""text-danger""> 21.06% <i class=""mdi mdi-arrow-down""></i></td>
                                <td><label class=""badge badge-warning"">In progress</label></td>
                            </tr>
                            <tr>
                                <td>John</td>
                                <td>Premier</td>
                                <td class=""text-danger""> 35.00% <i class=""mdi mdi-arrow-down""></i></td>
                                <td><label class=""badge badge-info"">Fixed</label></td>
                            </tr>
                            <tr>
                                <td>Peter</td>
                                <td>After effects</td>
                                <td class=""text-success""> 82.00% <i class=""mdi mdi-arrow-up""></i></td>
                                <td><label class=""badge badge-success"">Completed</label></td>
                            </tr>
                            <tr>
             ");
            WriteLiteral(@"                   <td>Dave</td>
                                <td>53275535</td>
                                <td class=""text-success""> 98.05% <i class=""mdi mdi-arrow-up""></i></td>
                                <td><label class=""badge badge-warning"">In progress</label></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""col-lg-12 grid-margin stretch-card"">
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""card-title"">Striped Table</h4>
                    <p class=""card-description"">
                        Add class <code>.table-striped</code>
                    </p>
                    <table class=""table table-striped"">
                        <thead>
                            <tr>
                                <th> User </th>
                                <th> First name </th>
                  ");
            WriteLiteral(@"              <th> Progress </th>
                                <th> Amount </th>
                                <th> Deadline </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class=""py-1"">
                                    <img src=""../../assets/images/faces-clipart/pic-1.png"" alt=""image"" />
                                </td>
                                <td> Herman Beck </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-success"" role=""progressbar"" style=""width: 25%"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $ 77.99 </td>
                                <td> May 15, 2015 </td>
                          ");
            WriteLiteral(@"  </tr>
                            <tr>
                                <td class=""py-1"">
                                    <img src=""../../assets/images/faces-clipart/pic-2.png"" alt=""image"" />
                                </td>
                                <td> Messsy Adam </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-danger"" role=""progressbar"" style=""width: 75%"" aria-valuenow=""75"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $245.30 </td>
                                <td> July 1, 2015 </td>
                            </tr>
                            <tr>
                                <td class=""py-1"">
                                    <img src=""../../assets/images/faces-clipart/pic-3.png"" alt=""image"" />
                                ");
            WriteLiteral(@"</td>
                                <td> John Richards </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-warning"" role=""progressbar"" style=""width: 90%"" aria-valuenow=""90"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $138.00 </td>
                                <td> Apr 12, 2015 </td>
                            </tr>
                            <tr>
                                <td class=""py-1"">
                                    <img src=""../../assets/images/faces-clipart/pic-4.png"" alt=""image"" />
                                </td>
                                <td> Peter Meggik </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-");
            WriteLiteral(@"primary"" role=""progressbar"" style=""width: 50%"" aria-valuenow=""50"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $ 77.99 </td>
                                <td> May 15, 2015 </td>
                            </tr>
                            <tr>
                                <td class=""py-1"">
                                    <img src=""../../assets/images/faces-clipart/pic-1.png"" alt=""image"" />
                                </td>
                                <td> Edward </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-danger"" role=""progressbar"" style=""width: 35%"" aria-valuenow=""35"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $ 160.");
            WriteLiteral(@"25 </td>
                                <td> May 03, 2015 </td>
                            </tr>
                            <tr>
                                <td class=""py-1"">
                                    <img src=""../../assets/images/faces-clipart/pic-2.png"" alt=""image"" />
                                </td>
                                <td> John Doe </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-info"" role=""progressbar"" style=""width: 65%"" aria-valuenow=""65"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $ 123.21 </td>
                                <td> April 05, 2015 </td>
                            </tr>
                            <tr>
                                <td class=""py-1"">
                                    <img src=""..");
            WriteLiteral(@"/../assets/images/faces-clipart/pic-3.png"" alt=""image"" />
                                </td>
                                <td> Henry Tom </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-warning"" role=""progressbar"" style=""width: 20%"" aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $ 150.00 </td>
                                <td> June 16, 2015 </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""col-lg-12 grid-margin stretch-card"">
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""card-title"">Bordered table</h4>
                    <p class=""card-description");
            WriteLiteral(@""">
                        Add class <code>.table-bordered</code>
                    </p>
                    <table class=""table table-bordered"">
                        <thead>
                            <tr>
                                <th> # </th>
                                <th> First name </th>
                                <th> Progress </th>
                                <th> Amount </th>
                                <th> Deadline </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td> 1 </td>
                                <td> Herman Beck </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-success"" role=""progressbar"" style=""width: 25%"" aria-valuenow=""25"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                               ");
            WriteLiteral(@"     </div>
                                </td>
                                <td> $ 77.99 </td>
                                <td> May 15, 2015 </td>
                            </tr>
                            <tr>
                                <td> 2 </td>
                                <td> Messsy Adam </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-danger"" role=""progressbar"" style=""width: 75%"" aria-valuenow=""75"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $245.30 </td>
                                <td> July 1, 2015 </td>
                            </tr>
                            <tr>
                                <td> 3 </td>
                                <td> John Richards </td>
                                <td>
            ");
            WriteLiteral(@"                        <div class=""progress"">
                                        <div class=""progress-bar bg-warning"" role=""progressbar"" style=""width: 90%"" aria-valuenow=""90"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $138.00 </td>
                                <td> Apr 12, 2015 </td>
                            </tr>
                            <tr>
                                <td> 4 </td>
                                <td> Peter Meggik </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-primary"" role=""progressbar"" style=""width: 50%"" aria-valuenow=""50"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $ 77.99 </td>
                   ");
            WriteLiteral(@"             <td> May 15, 2015 </td>
                            </tr>
                            <tr>
                                <td> 5 </td>
                                <td> Edward </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-danger"" role=""progressbar"" style=""width: 35%"" aria-valuenow=""35"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $ 160.25 </td>
                                <td> May 03, 2015 </td>
                            </tr>
                            <tr>
                                <td> 6 </td>
                                <td> John Doe </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-info"" role=""prog");
            WriteLiteral(@"ressbar"" style=""width: 65%"" aria-valuenow=""65"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $ 123.21 </td>
                                <td> April 05, 2015 </td>
                            </tr>
                            <tr>
                                <td> 7 </td>
                                <td> Henry Tom </td>
                                <td>
                                    <div class=""progress"">
                                        <div class=""progress-bar bg-warning"" role=""progressbar"" style=""width: 20%"" aria-valuenow=""20"" aria-valuemin=""0"" aria-valuemax=""100""></div>
                                    </div>
                                </td>
                                <td> $ 150.00 </td>
                                <td> June 16, 2015 </td>
                            </tr>
                        </tbody>
                    </tabl");
            WriteLiteral(@"e>
                </div>
            </div>
        </div>
        <div class=""col-lg-12 grid-margin stretch-card"">
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""card-title"">Inverse table</h4>
                    <p class=""card-description"">
                        Add class <code>.table-dark</code>
                    </p>
                    <table class=""table table-dark"">
                        <thead>
                            <tr>
                                <th> # </th>
                                <th> First name </th>
                                <th> Amount </th>
                                <th> Deadline </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td> 1 </td>
                                <td> Herman Beck </td>
                                <td> $ 77.99 </td>
              ");
            WriteLiteral(@"                  <td> May 15, 2015 </td>
                            </tr>
                            <tr>
                                <td> 2 </td>
                                <td> Messsy Adam </td>
                                <td> $245.30 </td>
                                <td> July 1, 2015 </td>
                            </tr>
                            <tr>
                                <td> 3 </td>
                                <td> John Richards </td>
                                <td> $138.00 </td>
                                <td> Apr 12, 2015 </td>
                            </tr>
                            <tr>
                                <td> 4 </td>
                                <td> Peter Meggik </td>
                                <td> $ 77.99 </td>
                                <td> May 15, 2015 </td>
                            </tr>
                            <tr>
                                <td> 5 </td>
                       ");
            WriteLiteral(@"         <td> Edward </td>
                                <td> $ 160.25 </td>
                                <td> May 03, 2015 </td>
                            </tr>
                            <tr>
                                <td> 6 </td>
                                <td> John Doe </td>
                                <td> $ 123.21 </td>
                                <td> April 05, 2015 </td>
                            </tr>
                            <tr>
                                <td> 7 </td>
                                <td> Henry Tom </td>
                                <td> $ 150.00 </td>
                                <td> June 16, 2015 </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class=""col-lg-12 stretch-card"">
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""card-title"">Table");
            WriteLiteral(@" with contextual classes</h4>
                    <p class=""card-description"">
                        Add class <code>.table-{color}</code>
                    </p>
                    <table class=""table table-bordered"">
                        <thead>
                            <tr>
                                <th> # </th>
                                <th> First name </th>
                                <th> Product </th>
                                <th> Amount </th>
                                <th> Deadline </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class=""table-info"">
                                <td> 1 </td>
                                <td> Herman Beck </td>
                                <td> Photoshop </td>
                                <td> $ 77.99 </td>
                                <td> May 15, 2015 </td>
                            </tr>
                 ");
            WriteLiteral(@"           <tr class=""table-warning"">
                                <td> 2 </td>
                                <td> Messsy Adam </td>
                                <td> Flash </td>
                                <td> $245.30 </td>
                                <td> July 1, 2015 </td>
                            </tr>
                            <tr class=""table-danger"">
                                <td> 3 </td>
                                <td> John Richards </td>
                                <td> Premeire </td>
                                <td> $138.00 </td>
                                <td> Apr 12, 2015 </td>
                            </tr>
                            <tr class=""table-success"">
                                <td> 4 </td>
                                <td> Peter Meggik </td>
                                <td> After effects </td>
                                <td> $ 77.99 </td>
                                <td> May 15, 2015 </td>
       ");
            WriteLiteral(@"                     </tr>
                            <tr class=""table-primary"">
                                <td> 5 </td>
                                <td> Edward </td>
                                <td> Illustrator </td>
                                <td> $ 160.25 </td>
                                <td> May 03, 2015 </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
