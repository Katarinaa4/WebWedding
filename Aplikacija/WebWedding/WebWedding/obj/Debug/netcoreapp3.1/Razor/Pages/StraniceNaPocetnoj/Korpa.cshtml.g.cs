#pragma checksum "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed7c60a8aeb5c8c9195f09516b7540a1b8485d8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebWedding.Pages.StraniceNaPocetnoj.Pages_StraniceNaPocetnoj_Korpa), @"mvc.1.0.razor-page", @"/Pages/StraniceNaPocetnoj/Korpa.cshtml")]
namespace WebWedding.Pages.StraniceNaPocetnoj
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed7c60a8aeb5c8c9195f09516b7540a1b8485d8a", @"/Pages/StraniceNaPocetnoj/Korpa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3464181ae681d34a13d0f774cba4d279cadfeef3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_StraniceNaPocetnoj_Korpa : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("korisnikID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Ukloni", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", new global::Microsoft.AspNetCore.Html.HtmlString("Ukloni"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "../StraniceNaPocetnoj/PosaljiNarudzbinu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
     if (Model.ZaKorisnika)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
         if (Model.ImaZahtev)
        {
            Layout = "_Layout_PlanerKSZ";
        }
        else
        {
            Layout = "_Layout_PlanerKBZ";
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
         

    }
    else
    {
        Layout = "_Layout_PlanerK";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ed7c60a8aeb5c8c9195f09516b7540a1b8485d8a6717", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 22 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.KorisnikID);

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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed7c60a8aeb5c8c9195f09516b7540a1b8485d8a8470", async() => {
                WriteLiteral("\n\n    <div>\n        <br />\n        <br />\n        <div class=\" s\"><h1><i class=\"icon-heart\"></i> Vasa korpa <i class=\"icon-heart\"></i></h1></div>\n        <br />\n        <br />\n        <div id=\"fh5co-blog-section\" class=\"fh5co-section-gray\">\n");
#nullable restore
#line 32 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
             foreach (var nar in Model.listaNarudzbina)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
                 if (nar.Status == null || nar.Status == "Rasprodato")
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <br />\n                    <div class=\"blog-text\">\n                        <div class=\"s1\">\n                            <div class=\"s2 s\"><a><img");
                BeginWriteAttribute("src", " src=\"", 986, "\"", 1012, 1);
#nullable restore
#line 39 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
WriteAttributeValue("", 992, nar.MojPlaner.Slika, 992, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" width=\"300px\" height=\"200px\"");
                BeginWriteAttribute("alt", " alt=\"", 1042, "\"", 1048, 0);
                EndWriteAttribute();
                WriteLiteral(">  </a></div>\n                            <div class=\"s2 s ll\"><a><h2> ");
#nullable restore
#line 40 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
                                                    Write(nar.MojPlaner.Naziv);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </h2></a> <span class=\"comment\"></span></div>\n                            <div class=\"s2 s l\">\n                                <div><span class=\"by\">Cena ");
#nullable restore
#line 42 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
                                                      Write(nar.MojPlaner.Cena);

#line default
#line hidden
#nullable disable
                WriteLiteral(" rsd</span></div>\n");
#nullable restore
#line 43 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
                                 if (nar.Status == "Rasprodato")
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <div><span class=\"by\">Status: ");
#nullable restore
#line 45 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
                                                             Write(nar.Status);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </span></div>\n");
#nullable restore
#line 46 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </div>\n                            <div>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ed7c60a8aeb5c8c9195f09516b7540a1b8485d8a12275", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 48 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
                                                                                  WriteLiteral(nar.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</div>\n                        </div>\n                    </div>\n                    <br />\n");
#nullable restore
#line 52 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\n        <br />\n        <div class=\"s3\">\n            <div class=\"pp s\">Ukupna cena: ");
#nullable restore
#line 57 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
                                      Write(Model.ukupnaCena);

#line default
#line hidden
#nullable disable
                WriteLiteral(" rsd</div>\n");
#nullable restore
#line 58 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
             if (!Model.praznaKorpa)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <div class=\"pp s\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ed7c60a8aeb5c8c9195f09516b7540a1b8485d8a16047", async() => {
                    WriteLiteral("Naruči <i class=\"icon-arrow-right2\"></i>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-cena", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
                                                                                            WriteLiteral(Model.ukupnaCena);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["cena"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-cena", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["cena"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("</div>\n");
#nullable restore
#line 61 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\Korpa.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </div>\n        <br />\n    </div>\n\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<style scoped>

    kkk {
        font-size: 40px;
        color: #ff6666;
    }


    .l {
        font-size: 20px;
        color: #8B3A3A;
    }

    .ll {
        font-size: 45px;
        color: #8B3A3A;
    }

    .lll {
        font-size: 25px;
        color: #8B3A3A;
    }

    .s {
        width: 100%;
        text-align: center;
        align-content: center;
    }

    .s1 {
        width: 100%;
        display: grid;
        grid-template-columns: 40% 30% 20% 10%;
        align-content: center;
    }

    .s2 {
        width: 100%;
    }

    .p {
        font-size: 35px;
        color: #8B3A3A;
    }

    .pp {
        font-size: 27px;
        color: #8B3A3A;
    }

    .s3 {
        width: 100%;
        display: grid;
        align-content: flex-end;
    }
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebWedding.Pages.StraniceNaPocetnoj.KorpaModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebWedding.Pages.StraniceNaPocetnoj.KorpaModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebWedding.Pages.StraniceNaPocetnoj.KorpaModel>)PageContext?.ViewData;
        public WebWedding.Pages.StraniceNaPocetnoj.KorpaModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
