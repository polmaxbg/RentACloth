#pragma checksum "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\Confirm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6eeb3e05216c9171afc453dd7d839130682c2835"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RentACloth.Areas.Identity.Pages.Orders.Views_Orders_Confirm), @"mvc.1.0.view", @"/Views/Orders/Confirm.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Orders/Confirm.cshtml", typeof(RentACloth.Areas.Identity.Pages.Orders.Views_Orders_Confirm))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6eeb3e05216c9171afc453dd7d839130682c2835", @"/Views/Orders/Confirm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b92b77d917296b5e837699f187c8d607c66861ca", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Confirm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RentACloth.Models.Оrders.ConfirmOrderViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Orders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Complete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\Confirm.cshtml"
  
    ViewData["Title"] = "Потвърди поръчката";

#line default
#line hidden
            BeginContext(111, 35, true);
            WriteLiteral("\r\n<div class=\"h3 text-center mb-3\">");
            EndContext();
            BeginContext(147, 17, false);
#line 7 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\Confirm.cshtml"
                            Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(164, 328, true);
            WriteLiteral(@"</div>
<div class=""progress mb-3"">
    <div class=""progress-bar"" role=""progressbar"" style=""width: 66%;"" aria-valuenow=""66"" aria-valuemin=""0"" aria-valuemax=""66"">66%</div>
</div>

<div class=""row"">
    <div class=""col-md-6"">
        <div class=""card card-body"">
            <div><span class=""font-weight-bold"">Име:</span> ");
            EndContext();
            BeginContext(493, 15, false);
#line 15 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\Confirm.cshtml"
                                                       Write(Model.Recipient);

#line default
#line hidden
            EndContext();
            BeginContext(508, 100, true);
            WriteLiteral("</div>\r\n            <hr />\r\n            <div><span class=\"font-weight-bold\">Телефонен номер:</span> ");
            EndContext();
            BeginContext(609, 17, false);
#line 17 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\Confirm.cshtml"
                                                                   Write(Model.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(626, 90, true);
            WriteLiteral("</div>\r\n            <hr />\r\n            <div><span class=\"font-weight-bold\">Адрес:</span> ");
            EndContext();
            BeginContext(717, 27, false);
#line 19 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\Confirm.cshtml"
                                                         Write(Model.DeliveryAddressStreet);

#line default
#line hidden
            EndContext();
            BeginContext(744, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(746, 32, false);
#line 19 "C:\Users\Viktor\Desktop\Project\RentACloth\RentACloth\Views\Orders\Confirm.cshtml"
                                                                                      Write(Model.DeliveryAddressDescription);

#line default
#line hidden
            EndContext();
            BeginContext(778, 136, true);
            WriteLiteral("</div>\r\n            <hr />\r\n        </div>\r\n    </div>\r\n    <div class=\"col-md-6\">\r\n        <div class=\"text-center mt-4\">\r\n            ");
            EndContext();
            BeginContext(914, 142, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b215d4380fd4026b0674ac070b82d07", async() => {
                BeginContext(1005, 47, true);
                WriteLiteral("<i class=\"fas fa-check\"></i> Потвърди поръчката");
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1056, 36, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RentACloth.Models.Оrders.ConfirmOrderViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
