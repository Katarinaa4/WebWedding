#pragma checksum "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ebeb4f9350ee7b6a49be4896f787154997be13e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebWedding.Pages.StraniceNaPocetnoj.Pages_StraniceNaPocetnoj_PrikazProstor), @"mvc.1.0.razor-page", @"/Pages/StraniceNaPocetnoj/PrikazProstor.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ebeb4f9350ee7b6a49be4896f787154997be13e", @"/Pages/StraniceNaPocetnoj/PrikazProstor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3464181ae681d34a13d0f774cba4d279cadfeef3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_StraniceNaPocetnoj_PrikazProstor : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("korisnikID"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "../StraniceNaPocetnoj/BrojZvezdica", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "../StraniceNaPocetnoj/PrikazMenija", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "../Kalendari/KorisnikKalendarProstori", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
     if (Model.ZaKorisnika)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
         if (Model.ImaZahtev)
        {
            Layout = "_LayoutSZ";
        }
        else
        {
            Layout = "_LayoutBZ";
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
         
    }
    else
    {
        Layout = "_LayoutMeniji";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0ebeb4f9350ee7b6a49be4896f787154997be13e6274", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 20 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ebeb4f9350ee7b6a49be4896f787154997be13e8035", async() => {
                WriteLiteral(@"

    <div id=""fh5co-blog-section"" class=""fh5co-section-gray"">
        <div class=""s"">
            <div class=""n"">
                <h1>Prostori</h1>
                <div style=""font-size:large"">U okviru svake firme mozete videti koji datumi su slobodni!</div>
                <br />
            </div>
            <br />
            <div class=""s1"">


");
#nullable restore
#line 34 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                 foreach (var pros in Model.mojiProstori)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div>\n");
#nullable restore
#line 37 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                         if (pros.StatusPrikaza == "Prikaz")
                        {




#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"fh5co-blog animate-box s2\">\n                                <a");
                BeginWriteAttribute("href", " href=\"", 1055, "\"", 1072, 1);
#nullable restore
#line 43 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
WriteAttributeValue("", 1062, pros.Link, 1062, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("><img class=\"img-responsive\"");
                BeginWriteAttribute("src", " src=\"", 1101, "\"", 1118, 1);
#nullable restore
#line 43 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
WriteAttributeValue("", 1107, pros.Slika, 1107, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 1119, "\"", 1125, 0);
                EndWriteAttribute();
                WriteLiteral("></a>\n                                <div class=\"blog-text\">\n                                    <div class=\"prod-title\">\n                                        <h1><a");
                BeginWriteAttribute("href", " href=\"", 1295, "\"", 1312, 1);
#nullable restore
#line 46 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
WriteAttributeValue("", 1302, pros.Link, 1302, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> ");
#nullable restore
#line 46 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                                             Write(pros.Naziv);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a> </h1>\n");
#nullable restore
#line 47 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                         if (Model.ImaZahtev)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div>\n");
#nullable restore
#line 50 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                                 for (var i = 0; i < pros.BrojZvezdica; i++)
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <span class=\"comment\">\n                                                        <a><i class=\"icon-star\"></i></a>\n                                                    </span>\n");
#nullable restore
#line 55 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ebeb4f9350ee7b6a49be4896f787154997be13e12649", async() => {
                    WriteLiteral(" Ocenite nas i vi!");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                                                                                   WriteLiteral(pros.Id);

#line default
#line hidden
#nullable disable
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
                WriteLiteral("\n                                            </div>\n");
#nullable restore
#line 58 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div>\n");
#nullable restore
#line 62 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                                 for (var i = 0; i < pros.BrojZvezdica; i++)
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <span class=\"comment\">\n                                                        <a><i class=\"icon-star\"></i></a>\n                                                    </span>\n");
#nullable restore
#line 67 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            </div>\n");
#nullable restore
#line 69 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <div><span class=\"by\"><i class=\"icon-address\"></i> ");
#nullable restore
#line 70 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                                                                      Write(pros.Adresa);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></div>\n                                        <div><span class=\"comment\"> Max kapacitet - ");
#nullable restore
#line 71 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                                                               Write(pros.Kapacitet);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></div>\n                                        <p>");
#nullable restore
#line 72 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                      Write(pros.Opis);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n                                        <p>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ebeb4f9350ee7b6a49be4896f787154997be13e17975", async() => {
                    WriteLiteral("<i class=\"icon-address-book\"></i>   Meniji...");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                                                                              WriteLiteral(pros.Id);

#line default
#line hidden
#nullable disable
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
                WriteLiteral("</p>\n");
#nullable restore
#line 74 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                         if (Model.ZaKorisnika)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <p>");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ebeb4f9350ee7b6a49be4896f787154997be13e20746", async() => {
                    WriteLiteral("<i class=\"icon-calendar\"></i>   Zakazani i rezervisani datumi...");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                                                                                     WriteLiteral(pros.Id);

#line default
#line hidden
#nullable disable
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
                WriteLiteral("</p>\n");
#nullable restore
#line 77 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </div>\n                                </div>\n                            </div>\n");
#nullable restore
#line 81 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"

                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\n");
#nullable restore
#line 84 "C:\Users\Korisnik\Desktop\Webweding-main\Aplikacija\WebWedding\WebWedding\Pages\StraniceNaPocetnoj\PrikazProstor.cshtml"

                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\n            </div>\n        </div>\n    </div>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<style scoped>

    .ww {
        font-size: 60px;
        color: #ff6666;
    }

    .n {
        width: 100%;
        align-content: center;
        text-align: center;
    }

    .s {
        width: 100%;
        display: grid;
        grid-template-columns: auto;
        margin-left: 20px;
        margin-right: 20px;
    }

    .s1 {
        width: 100%;
        display: grid;
        grid-template-columns: 33% 33% 33%;
    }

    .s2 {
        width: 90%;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebWedding.Pages.StraniceNaPocetnoj.PrikazProstorModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebWedding.Pages.StraniceNaPocetnoj.PrikazProstorModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<WebWedding.Pages.StraniceNaPocetnoj.PrikazProstorModel>)PageContext?.ViewData;
        public WebWedding.Pages.StraniceNaPocetnoj.PrikazProstorModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
