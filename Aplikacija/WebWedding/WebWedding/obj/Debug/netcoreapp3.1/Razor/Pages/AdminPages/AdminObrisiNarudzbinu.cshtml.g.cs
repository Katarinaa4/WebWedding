#pragma checksum "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b05138d34366c8757edf02fdceb360cc6bd1266d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebWedding.Pages.AdminPages.Pages_AdminPages_AdminObrisiNarudzbinu), @"mvc.1.0.razor-page", @"/Pages/AdminPages/AdminObrisiNarudzbinu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b05138d34366c8757edf02fdceb360cc6bd1266d", @"/Pages/AdminPages/AdminObrisiNarudzbinu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3464181ae681d34a13d0f774cba4d279cadfeef3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_AdminPages_AdminObrisiNarudzbinu : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("adminID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./AdminPregledNarudzbina", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 4 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
  
    ViewData["Title"] = "AdminObrisiNarudzbinu";
    Layout = "_Layout_Admin";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\" display:flex;\n                 flex-direction:column;\n                 align-items:center\">\n\n        <h2 style=\"display:flex;color:lightcoral;\">Da li sigurno zelite da obrisete ovu narudzbinu?</h2>\n        <div>\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b05138d34366c8757edf02fdceb360cc6bd1266d5281", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 14 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
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
            WriteLiteral("\n            <dl class=\"dl-horizontal\">\n                <dt>\n                    ");
#nullable restore
#line 17 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayNameFor(model => model.Narudzbina.Ime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 20 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayFor(model => model.Narudzbina.Ime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt>\n                    ");
#nullable restore
#line 23 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayNameFor(model => model.Narudzbina.Prezime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 26 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayFor(model => model.Narudzbina.Prezime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt>\n                    ");
#nullable restore
#line 29 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayNameFor(model => model.Narudzbina.Adresa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 32 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayFor(model => model.Narudzbina.Adresa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt>\n                    Broj Telefona\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 38 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayFor(model => model.Narudzbina.BrojTelefona));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt>\n                    ");
#nullable restore
#line 41 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayNameFor(model => model.Narudzbina.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 44 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayFor(model => model.Narudzbina.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt>\n                    Cena\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 50 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayFor(model => model.Narudzbina.UkupnaCena));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt>\n                    ");
#nullable restore
#line 53 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayNameFor(model => model.Narudzbina.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 56 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayFor(model => model.Narudzbina.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n                <dt>\n                    Planer\n                </dt>\n                <dd>\n                    ");
#nullable restore
#line 62 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
               Write(Html.DisplayFor(model => model.Narudzbina.MojPlaner.Naziv));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </dd>\n            </dl>\n\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b05138d34366c8757edf02fdceb360cc6bd1266d12220", async() => {
                WriteLiteral("\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b05138d34366c8757edf02fdceb360cc6bd1266d12493", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 67 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\AdminPages\AdminObrisiNarudzbinu.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Narudzbina.Id);

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
                WriteLiteral("\n                <input type=\"submit\" value=\"Obrisi\" class=\"btn btn-default\" /> |\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b05138d34366c8757edf02fdceb360cc6bd1266d14344", async() => {
                    WriteLiteral("Nazad na listu narudzbina");
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
            WriteLiteral("\n        </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebWedding.Pages.AdminPages.AdminObrisiNarudzbinuModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebWedding.Pages.AdminPages.AdminObrisiNarudzbinuModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebWedding.Pages.AdminPages.AdminObrisiNarudzbinuModel>)PageContext?.ViewData;
        public WebWedding.Pages.AdminPages.AdminObrisiNarudzbinuModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
