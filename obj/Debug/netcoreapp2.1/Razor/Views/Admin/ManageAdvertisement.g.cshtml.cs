#pragma checksum "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7415baaef2669ddc82a83be2260046f14679d84a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ManageAdvertisement), @"mvc.1.0.view", @"/Views/Admin/ManageAdvertisement.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/ManageAdvertisement.cshtml", typeof(AspNetCore.Views_Admin_ManageAdvertisement))]
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
#line 3 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\_ViewImports.cshtml"
using OnlineShopping.Models;

#line default
#line hidden
#line 4 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\_ViewImports.cshtml"
using OnlineShopping.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\_ViewImports.cshtml"
using OnlineShopping.Services;

#line default
#line hidden
#line 6 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 7 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\_ViewImports.cshtml"
using OnlineShopping.HelperUser;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7415baaef2669ddc82a83be2260046f14679d84a", @"/Views/Admin/ManageAdvertisement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a96f90fb2833102f5d693d20751e04b41939f10f", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ManageAdvertisement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AdvertisementViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeAdvertisement", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteAdvertisement", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
  Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(116, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
#line 7 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
     if (Model.Count() == 0)
    {

#line default
#line hidden
            BeginContext(159, 39, true);
            WriteLiteral("        <div><p>Nema oglasa</p></div>\r\n");
            EndContext();
#line 10 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(222, 358, true);
            WriteLiteral(@"    <table class=""table table-bordered"">
        <thead>
            <tr>
                <td>Advertisement Type</td>
                <td>Description</td>
                <td>Create Date</td>
                <td>Expire Date</td>
                <td>Client</td>
                <td>Action</td>
            </tr>
        </thead>
        <tbody>

");
            EndContext();
#line 26 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(629, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(668, 13, false);
#line 29 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
               Write(item.TypeName);

#line default
#line hidden
            EndContext();
            BeginContext(681, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(709, 16, false);
#line 30 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
               Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(725, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(753, 41, false);
#line 31 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
               Write(item.RegistrationDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(794, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(822, 39, false);
#line 32 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
               Write(item.ExpirationDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(861, 28, true);
            WriteLiteral("</td>\r\n                <td >");
            EndContext();
            BeginContext(890, 13, false);
#line 33 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
                Write(item.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(903, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(930, 199, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c85616836e54eac9e7577ab77902afa", async() => {
                BeginContext(1119, 6, true);
                WriteLiteral("Change");
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
#line 34 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
                                                                                WriteLiteral(service.GetAdvertisementByNameUser(item.TypeName, item.UserName, item.RegistrationDate.ToString()).AdvertisementId);

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
            BeginContext(1129, 47, true);
            WriteLiteral("\r\n                    |  \r\n                    ");
            EndContext();
            BeginContext(1176, 225, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "39ee9f9afe9b4657939c5fba29101d59", async() => {
                BeginContext(1391, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 37 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
                          WriteLiteral(service.GetAdvertisementByNameUser(item.TypeName, item.UserName, item.RegistrationDate.ToString()).AdvertisementId);

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
            BeginContext(1401, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 39 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
        }

#line default
#line hidden
            BeginContext(1438, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 42 "C:\Users\Asus-i5\Desktop\RS1_Seminarski git\OnlineShop\Views\Admin\ManageAdvertisement.cshtml"
    }

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IArtikliService service { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AdvertisementViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
