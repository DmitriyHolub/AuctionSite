#pragma checksum "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\Home\FinishForm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d99783520a8c3c21fe5eb1982055c2230eb2541"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FinishForm), @"mvc.1.0.view", @"/Views/Home/FinishForm.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\_ViewImports.cshtml"
using AuctionSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\_ViewImports.cshtml"
using AuctionSite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d99783520a8c3c21fe5eb1982055c2230eb2541", @"/Views/Home/FinishForm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2173c236f12bad0923230709667d7e264e763f29", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FinishForm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FinishFormModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"finish-form\">\r\n    <h1> ");
#nullable restore
#line 3 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\Home\FinishForm.cshtml"
    Write(Model.FinishMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>   \r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FinishFormModel> Html { get; private set; }
    }
}
#pragma warning restore 1591