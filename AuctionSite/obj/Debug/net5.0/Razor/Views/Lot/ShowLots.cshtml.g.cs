#pragma checksum "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e2f6723b11695edc1b66a94ef013690372d47b22"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lot_ShowLots), @"mvc.1.0.view", @"/Views/Lot/ShowLots.cshtml")]
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
#line 2 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
using AuctionSite.Localize;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2f6723b11695edc1b66a94ef013690372d47b22", @"/Views/Lot/ShowLots.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2173c236f12bad0923230709667d7e264e763f29", @"/Views/_ViewImports.cshtml")]
    public class Views_Lot_ShowLots : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShowLotByTypeModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("currency-block "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e2f6723b11695edc1b66a94ef013690372d47b224060", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 6 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
Write(Html.HiddenFor(x => x.numberType));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 7 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
Write(Resource.Currency_selection);

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n    ");
#nullable restore
#line 8 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
Write(Html.DropDownList("Currency", @Model.Currencies));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <input type=\"submit\" value=\"выбор валюты\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 5, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 74, "/Lot/ShowLots?numberType=", 74, 25, true);
#nullable restore
#line 5 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
AddHtmlAttributeValue("", 99, Model.numberType, 99, 17, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 116, "&currency=", 116, 10, true);
#nullable restore
#line 5 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
AddHtmlAttributeValue("", 126, Model.Currency, 126, 15, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue(" ", 141, "", 142, 1, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<div class=\"lot-wrap\">\r\n\r\n");
#nullable restore
#line 13 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
     foreach (var item in @Model.LotsModels)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"lot-block\">\r\n            <div class=\" top-wrap\">\r\n                <div class=\"left-block\">\r\n");
#nullable restore
#line 18 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
                     foreach (var img in @item.UrlImages)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img class=\"lot-image\"");
            BeginWriteAttribute("src", " src=", 691, "", 700, 1);
#nullable restore
#line 20 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
WriteAttributeValue("", 696, img, 696, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /> ");
#nullable restore
#line 20 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
                                                                                             
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"choose-image\">\r\n                    </div>\r\n                </div>\r\n                <div class=\"right-block\">\r\n                    <div class=\"lot-name\">\r\n                        <h1>");
#nullable restore
#line 27 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
                       Write(item.LotName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                    </div>\r\n                    <div class=\"lot-description\">\r\n                        <p>");
#nullable restore
#line 30 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
                      Write(item.ProductDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\" bottom-wrap\">\r\n                <div style=\"color:red\" class=\"price-block\">\r\n                    ");
#nullable restore
#line 36 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
               Write(item.BuyoutPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 36 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
                                 Write(Model.PreferCurrency.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"place-bet-block\">\r\n                    <div class=\"lot-placebet\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1524, "\"", 1559, 2);
            WriteAttributeValue("", 1531, "/Lot/PlaceBet?lotId=", 1531, 20, true);
#nullable restore
#line 40 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
WriteAttributeValue("", 1551, item.Id, 1551, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 40 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
                                                          Write(Resource.Lot_Show_Place_a_bet);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </div>\r\n                    <div class=\"lot-subscribe\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1700, "\"", 1736, 2);
            WriteAttributeValue("", 1707, "/Lot/Subscribe?lotId=", 1707, 21, true);
#nullable restore
#line 43 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
WriteAttributeValue("", 1728, item.Id, 1728, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 43 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
                                                           Write(Resource.Item_subscribe);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </div>\r\n                    <div class=\"lot-download\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 1870, "\"", 1908, 2);
            WriteAttributeValue("", 1877, "/Lot/DownLoadLot?lotId=", 1877, 23, true);
#nullable restore
#line 46 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
WriteAttributeValue("", 1900, item.Id, 1900, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 46 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
                                                             Write(Resource.DownLoad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 51 "C:\Users\HP\source\repos\AuctionSite2\AuctionSite\Views\Lot\ShowLots.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShowLotByTypeModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
