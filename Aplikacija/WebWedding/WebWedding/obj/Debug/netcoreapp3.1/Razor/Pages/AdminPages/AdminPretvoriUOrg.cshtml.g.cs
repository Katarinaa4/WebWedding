#pragma checksum "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c5ea7db69b1967095830e0ee1ac10302a752f52"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebWedding.Pages.AdminPages.Pages_AdminPages_AdminPretvoriUOrg), @"mvc.1.0.razor-page", @"/Pages/AdminPages/AdminPretvoriUOrg.cshtml")]
namespace WebWedding.Pages.AdminPages
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
#line 1 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\_ViewImports.cshtml"
using WebWedding;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c5ea7db69b1967095830e0ee1ac10302a752f52", @"/Pages/AdminPages/AdminPretvoriUOrg.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3464181ae681d34a13d0f774cba4d279cadfeef3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_AdminPages_AdminPretvoriUOrg : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("adminID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./AdminPregledKorisnika", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
  
    ViewData["Title"] = "AdminPretvoriUOrg";
    Layout = "_Layout_Admin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    <div style=\" display:flex;\n                 flex-direction:column;\n                 align-items:center\">\n\n        <h3>Da li ste sigurni da zelite da ovog korisnika pretvorite u organizatora?</h3>\n        <div>\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0c5ea7db69b1967095830e0ee1ac10302a752f525204", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 14 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.AdminID);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n            <hr />\n            <dl class=\"dl-horizontal\">\n                <dt>\n                    ");
#nullable restore
#line 18 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
               Write(Html.DisplayNameFor(model => model.Korisnik.Ime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 21 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
               Write(Html.DisplayFor(model => model.Korisnik.Ime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt>\n                    ");
#nullable restore
#line 24 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
               Write(Html.DisplayNameFor(model => model.Korisnik.Prezime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 27 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
               Write(Html.DisplayFor(model => model.Korisnik.Prezime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt>\n                    ");
#nullable restore
#line 30 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
               Write(Html.DisplayNameFor(model => model.Korisnik.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 33 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
               Write(Html.DisplayFor(model => model.Korisnik.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt>\n                    ");
#nullable restore
#line 36 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
               Write(Html.DisplayNameFor(model => model.Korisnik.Sifra));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 39 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
               Write(Html.DisplayFor(model => model.Korisnik.Sifra));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt>\n                    Broj Telefona\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 45 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
               Write(Html.DisplayFor(model => model.Korisnik.BrojTelefona));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n            </dl>\n\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c5ea7db69b1967095830e0ee1ac10302a752f5210450", async() => {
                WriteLiteral("\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0c5ea7db69b1967095830e0ee1ac10302a752f5210723", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 50 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminPretvoriUOrg.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Korisnik.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                <input type=\"submit\" value=\"Pretvori\" class=\"btn btn-default\" /> |\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c5ea7db69b1967095830e0ee1ac10302a752f5212570", async() => {
                    WriteLiteral("Nazad na listu korisnika");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebWedding.Pages.AdminPages.AdminPretvoriUOrgModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebWedding.Pages.AdminPages.AdminPretvoriUOrgModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebWedding.Pages.AdminPages.AdminPretvoriUOrgModel>)PageContext?.ViewData;
        public WebWedding.Pages.AdminPages.AdminPretvoriUOrgModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
