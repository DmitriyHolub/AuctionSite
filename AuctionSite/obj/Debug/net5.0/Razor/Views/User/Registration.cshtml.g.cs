#pragma checksum "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca34f4cbfaf7a961475c86550c9e75b3907a12cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Registration), @"mvc.1.0.view", @"/Views/User/Registration.cshtml")]
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
#nullable restore
#line 2 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
using AuctionSite.Localize;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca34f4cbfaf7a961475c86550c9e75b3907a12cc", @"/Views/User/Registration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2173c236f12bad0923230709667d7e264e763f29", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Registration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RegistrationUserModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ValidateLogin.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("registration-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/User/Registration"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Head", async() => {
                WriteLiteral(" \r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca34f4cbfaf7a961475c86550c9e75b3907a12cc5056", async() => {
                    WriteLiteral(" ");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n<div class=\"registration\">\r\n    <h1> Регистрация нового пользователя</h1>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca34f4cbfaf7a961475c86550c9e75b3907a12cc6338", async() => {
                WriteLiteral("\r\n        <div>\r\n            ");
#nullable restore
#line 12 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
       Write(Html.ValidationMessageFor(x => x.Login));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 13 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
       Write(Resource.Registration_Input_Login);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 13 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
                                          Write(Html.TextBoxFor(x => x.Login));

#line default
#line hidden
#nullable disable
                WriteLiteral(" <span class=\"login-hint-good\">хорошо</span><span class=\"login-hint-bad\">Плохо</span>\r\n            ");
#nullable restore
#line 14 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
       Write(Html.ValidationMessageFor(x => x.Login));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div>\r\n            ");
#nullable restore
#line 17 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
       Write(Resource.Registration_Input_password);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 17 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
                                             Write(Html.PasswordFor(x => x.Password));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 18 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
       Write(Html.ValidationMessageFor(x => x.Password));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div>\r\n            ");
#nullable restore
#line 21 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
       Write(Resource.Registration_Confirm_password);

#line default
#line hidden
#nullable disable
                WriteLiteral("  ");
#nullable restore
#line 21 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
                                                Write(Html.PasswordFor(x => x.CheckPassword));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 22 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
       Write(Html.ValidationMessageFor(x => x.CheckPassword));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <div>\r\n            ");
#nullable restore
#line 25 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
       Write(Resource.Registration_Input_email);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 25 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
                                          Write(Html.TextBoxFor(x => x.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            ");
#nullable restore
#line 26 "C:\Users\HP\source\repos\AuctionSite\AuctionSite\Views\User\Registration.cshtml"
       Write(Html.ValidationMessageFor(x => x.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        </div>\r\n        <input type=\"submit\" value=\"Registration\" />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n \r\n   \r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RegistrationUserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591