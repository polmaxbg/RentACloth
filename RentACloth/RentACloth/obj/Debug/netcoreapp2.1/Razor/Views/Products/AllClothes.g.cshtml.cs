#pragma checksum "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllClothes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51995cae5b657ad233436dbc6102c273a7849ab2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RentACloth.Areas.Identity.Pages.Products.Views_Products_AllClothes), @"mvc.1.0.view", @"/Views/Products/AllClothes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Products/AllClothes.cshtml", typeof(RentACloth.Areas.Identity.Pages.Products.Views_Products_AllClothes))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51995cae5b657ad233436dbc6102c273a7849ab2", @"/Views/Products/AllClothes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b92b77d917296b5e837699f187c8d607c66861ca", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_AllClothes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RentACloth.Services.Models.Home.IndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllClothes.cshtml"
  
    ViewData["Title"] = "AllClothes";

#line default
#line hidden
            BeginContext(103, 341, true);
            WriteLiteral(@"
<h2>All Clothes</h2>
<div class=""mx-auto w-50"">
    <table class=""table-hover table table-striped"">
        <tr>
            <th>#</th>
            <th>Name</th>
            <th>Brand Name</th>
            <th>Price</th>
            <th>Event Type</th>
            <th>CategoryName</th>
            <th>Size</th>
        </tr>
");
            EndContext();
#line 19 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllClothes.cshtml"
         for (int i = 0; i < Model.Products.Count(); i++)
        {
            {
                var index = i + 1;
                var product = Model.Products.ToList()[i];

#line default
#line hidden
            BeginContext(624, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(655, 5, false);
#line 25 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllClothes.cshtml"
           Write(index);

#line default
#line hidden
            EndContext();
            BeginContext(660, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(684, 12, false);
#line 26 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllClothes.cshtml"
           Write(product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(696, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(720, 17, false);
#line 27 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllClothes.cshtml"
           Write(product.BrandName);

#line default
#line hidden
            EndContext();
            BeginContext(737, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(761, 13, false);
#line 28 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllClothes.cshtml"
           Write(product.Price);

#line default
#line hidden
            EndContext();
            BeginContext(774, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(798, 16, false);
#line 29 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllClothes.cshtml"
           Write(product.EvenType);

#line default
#line hidden
            EndContext();
            BeginContext(814, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(838, 20, false);
#line 30 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllClothes.cshtml"
           Write(product.CategoryName);

#line default
#line hidden
            EndContext();
            BeginContext(858, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(882, 12, false);
#line 31 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllClothes.cshtml"
           Write(product.Size);

#line default
#line hidden
            EndContext();
            BeginContext(894, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 33 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllClothes.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(942, 22, true);
            WriteLiteral("    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RentACloth.Services.Models.Home.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
