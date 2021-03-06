#pragma checksum "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b60e240d485ebc0b80f69daf00f3a68c5948d83"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lot_SetLot), @"mvc.1.0.view", @"/Views/Lot/SetLot.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\_ViewImports.cshtml"
using AuctionSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\_ViewImports.cshtml"
using AuctionSite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
using AuctionSite.Localize;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b60e240d485ebc0b80f69daf00f3a68c5948d83", @"/Views/Lot/SetLot.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2173c236f12bad0923230709667d7e264e763f29", @"/Views/_ViewImports.cshtml")]
    public class Views_Lot_SetLot : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SetLotModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("set-lot-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Lot/SetLot"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Head", async() => {
                WriteLiteral("\r\n    <script src=\"/js/AddLotImage.js\"></script>\r\n");
            }
            );
            WriteLiteral("\r\n<div class=\"set-lot-wrap\">\r\n    <h1>");
#nullable restore
#line 9 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
   Write(Resource.Lot_SetLot_Creating__a_new_lot);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b60e240d485ebc0b80f69daf00f3a68c5948d835243", async() => {
                WriteLiteral("\r\n        <div class=\"set-lot-form-LotName\">\r\n            ");
#nullable restore
#line 12 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
       Write(Resource.Set_lot_Input_lot_name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 12 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
                                        Write(Html.TextBoxFor(x => x.LotName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 13 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
       Write(Html.ValidationMessageFor(x => x.LotName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"set-lot-form-ProductDescription\">\r\n            ");
#nullable restore
#line 16 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
       Write(Resource.Set_lot_Input_lot_discription);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 16 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
                                               Write(Html.TextBoxFor(x => x.ProductDescription));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 17 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
       Write(Html.ValidationMessageFor(x => x.LotName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div class=\"set-lot-form-StartPrice\">\r\n            ");
#nullable restore
#line 20 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
       Write(Resource.Set_lot_Input_start_price);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 20 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
                                           Write(Html.TextBoxFor(x => x.StartPrice));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 21 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
       Write(Html.ValidationMessageFor(x => x.StartPrice));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        ");
#nullable restore
#line 23 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
   Write(Resource.Set_lot_Choose_type_of_lot);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <div>\r\n            ");
#nullable restore
#line 25 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
       Write(Html.DropDownList(nameof(Model.LotType), Model.AllTypeOfLots));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        </div>\r\n        <div class=\"new-image-for-lot\">\r\n            <input class=\"input-image-lot\" type=\"file\" name=\"LotImages\" value=\"LotImages\" />\r\n        </div>\r\n        <input type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 1260, "\"", 1291, 1);
#nullable restore
#line 30 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\SetLot.cshtml"
WriteAttributeValue("", 1268, Resource.Common_Create, 1268, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SetLotModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
