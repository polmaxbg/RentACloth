#pragma checksum "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\MyOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c6c167d6d643818de531cdd7864503a49da850c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RentACloth.Areas.Identity.Pages.Orders.Views_Orders_MyOrders), @"mvc.1.0.view", @"/Views/Orders/MyOrders.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Orders/MyOrders.cshtml", typeof(RentACloth.Areas.Identity.Pages.Orders.Views_Orders_MyOrders))]
namespace RentACloth.Areas.Identity.Pages.Orders
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c6c167d6d643818de531cdd7864503a49da850c", @"/Views/Orders/MyOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b92b77d917296b5e837699f187c8d607c66861ca", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_MyOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RentACloth.Models.Оrders.MyOrdersViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm mobile-fondsize-11"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\MyOrders.cshtml"
  
    ViewData["Title"] = "Моите поръчки";
    Layout = "_LayoutClear";

#line default
#line hidden
            BeginContext(130, 64, true);
            WriteLiteral("\r\n<div class=\"mobile-fondsize-20 h2 mt-4 text-center text-info\">");
            EndContext();
            BeginContext(195, 17, false);
#line 7 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\MyOrders.cshtml"
                                                         Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(212, 743, true);
            WriteLiteral(@"</div>
<hr />

<div class=""container mobile-fondsize-11 mt-5"">
    <table class=""table table-hover"">
        <thead>
            <tr class=""row"">
                <th scope=""col"" class=""col-2 d-flex justify-content-center"">Номер</th>
                <th scope=""col"" class=""col-2 d-flex justify-content-center"">Име на продукта</th>
                <th scope=""col"" class=""col-2 d-flex justify-content-center"">Количество</th>
                <th scope=""col"" class=""col-2 d-flex justify-content-center"">Цена</th>
                <th scope=""col"" class=""col-2 d-flex justify-content-center"">Общо</th>
                <th scope=""col"" class=""col-2 d-flex justify-content-center""></th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 23 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\MyOrders.cshtml"
             foreach (var order in Model.Orders)
            {

#line default
#line hidden
            BeginContext(1020, 128, true);
            WriteLiteral("                <tr class=\"row\">\r\n                    <td class=\"col-2 d-flex justify-content-center\">\r\n                        ");
            EndContext();
            BeginContext(1149, 8, false);
#line 27 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\MyOrders.cshtml"
                   Write(order.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1157, 123, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"col-2 d-flex justify-content-center\">\r\n                        ");
            EndContext();
            BeginContext(1281, 17, false);
#line 30 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\MyOrders.cshtml"
                   Write(order.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(1298, 123, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"col-2 d-flex justify-content-center\">\r\n                        ");
            EndContext();
            BeginContext(1422, 14, false);
#line 33 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\MyOrders.cshtml"
                   Write(order.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1436, 123, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"col-2 d-flex justify-content-center\">\r\n                        ");
            EndContext();
            BeginContext(1560, 18, false);
#line 36 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\MyOrders.cshtml"
                   Write(order.ProductPrice);

#line default
#line hidden
            EndContext();
            BeginContext(1578, 127, true);
            WriteLiteral(" лв.\r\n                    </td>\r\n                    <td class=\"col-2 d-flex justify-content-center\">\r\n                        ");
            EndContext();
            BeginContext(1706, 16, false);
#line 39 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\MyOrders.cshtml"
                   Write(order.TotalPrice);

#line default
#line hidden
            EndContext();
            BeginContext(1722, 178, true);
            WriteLiteral(" лв.\r\n                    </td>\r\n                    <td class=\"col-md-2 d-flex justify-content-around\">\r\n                        <div class=\"mr-2\">\r\n                            ");
            EndContext();
            BeginContext(1900, 149, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f94630345a34c698d40d979484ce129", async() => {
                BeginContext(2032, 13, true);
                WriteLiteral(" Към продукта");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 43 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\MyOrders.cshtml"
                                                                                WriteLiteral(order.ProductId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2049, 84, true);
            WriteLiteral("\r\n                        </div>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 47 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\MyOrders.cshtml"
            }

#line default
#line hidden
            BeginContext(2148, 42, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RentACloth.Models.Оrders.MyOrdersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
