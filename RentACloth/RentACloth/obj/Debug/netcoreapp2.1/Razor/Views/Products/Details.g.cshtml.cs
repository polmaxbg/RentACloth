#pragma checksum "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba9c6cc30e3361ef856bbb0cb38e0c0603dc451b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RentACloth.Areas.Identity.Pages.Products.Views_Products_Details), @"mvc.1.0.view", @"/Views/Products/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Products/Details.cshtml", typeof(RentACloth.Areas.Identity.Pages.Products.Views_Products_Details))]
namespace RentACloth.Areas.Identity.Pages.Products
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\_ViewImports.cshtml"
using RentACloth.Web.Areas.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba9c6cc30e3361ef856bbb0cb38e0c0603dc451b", @"/Views/Products/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b92b77d917296b5e837699f187c8d607c66861ca", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RentACloth.Models.ProductsViewModel.ProductDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(68, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(113, 351, true);
            WriteLiteral(@"
<h2>Details</h2>
<div class=""mx-auto w-50"">
    <table class=""table-hover table table-striped"">
        <tr>
            <th>Name</th>
            <th>Price</th>
            <th>Description</th>
            <th>Brand Name</th>
            <th>Event Type</th>
            <th>Size</th>
        </tr>
       
        <tr>
            <td>");
            EndContext();
            BeginContext(465, 10, false);
#line 20 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\Details.cshtml"
           Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(475, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(499, 11, false);
#line 21 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\Details.cshtml"
           Write(Model.Price);

#line default
#line hidden
            EndContext();
            BeginContext(510, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(534, 17, false);
#line 22 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\Details.cshtml"
           Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(551, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(575, 15, false);
#line 23 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\Details.cshtml"
           Write(Model.BrandName);

#line default
#line hidden
            EndContext();
            BeginContext(590, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(614, 15, false);
#line 24 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\Details.cshtml"
           Write(Model.EventType);

#line default
#line hidden
            EndContext();
            BeginContext(629, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(653, 10, false);
#line 25 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\Details.cshtml"
           Write(Model.Size);

#line default
#line hidden
            EndContext();
            BeginContext(663, 44, true);
            WriteLiteral("</td>\r\n        </tr>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RentACloth.Models.ProductsViewModel.ProductDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591