#pragma checksum "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3d054e5d5ea41138871c5af9776e40e5473fc1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RentACloth.Areas.Identity.Pages.Products.Views_Products_AllShoes), @"mvc.1.0.view", @"/Views/Products/AllShoes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Products/AllShoes.cshtml", typeof(RentACloth.Areas.Identity.Pages.Products.Views_Products_AllShoes))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3d054e5d5ea41138871c5af9776e40e5473fc1e", @"/Views/Products/AllShoes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b92b77d917296b5e837699f187c8d607c66861ca", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_AllShoes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RentACloth.Services.Models.Home.IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml"
  
    ViewData["Title"] = "AllShoes";

#line default
#line hidden
            BeginContext(101, 340, true);
            WriteLiteral(@"
<h2>All Shoes</h2>
<div class=""mx-auto w-50"">
    <table class=""table-hover table table-striped"">
        <tr>
            <th>#</th>
            <th>Name</th>
            <th>Brand Name</th>
            <th>Price</th>
            <th>Event Type</th>
            <th>Category Name</th>
            <th>Size</th>
        </tr>
");
            EndContext();
#line 19 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml"
         for (int i = 0; i < Model.Products.Count(); i++)
        {
            {
                var index = i + 1;
                var product = Model.Products.ToList()[i];

#line default
#line hidden
            BeginContext(621, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(652, 5, false);
#line 25 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml"
           Write(index);

#line default
#line hidden
            EndContext();
            BeginContext(657, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(681, 12, false);
#line 26 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml"
           Write(product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(693, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(717, 17, false);
#line 27 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml"
           Write(product.BrandName);

#line default
#line hidden
            EndContext();
            BeginContext(734, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(758, 13, false);
#line 28 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml"
           Write(product.Price);

#line default
#line hidden
            EndContext();
            BeginContext(771, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(795, 16, false);
#line 29 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml"
           Write(product.EvenType);

#line default
#line hidden
            EndContext();
            BeginContext(811, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(835, 20, false);
#line 30 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml"
           Write(product.CategoryName);

#line default
#line hidden
            EndContext();
            BeginContext(855, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(879, 12, false);
#line 31 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml"
           Write(product.Size);

#line default
#line hidden
            EndContext();
            BeginContext(891, 23, true);
            WriteLiteral("</td>\r\n            <th>");
            EndContext();
            BeginContext(914, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fe93c054f8441cb8f773d9495c60637", async() => {
                BeginContext(1003, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 32 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml"
                                                                                WriteLiteral(product.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1014, 22, true);
            WriteLiteral("</th>\r\n        </tr>\r\n");
            EndContext();
#line 34 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Products\AllShoes.cshtml"
            }
        }

#line default
#line hidden
            BeginContext(1062, 22, true);
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
