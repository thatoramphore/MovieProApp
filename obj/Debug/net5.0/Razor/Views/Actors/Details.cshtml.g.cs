#pragma checksum "C:\Users\thato\Documents\code\MovieProApp\Views\Actors\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f69c85274b4fab2bea7033876440aba68af5729"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Actors_Details), @"mvc.1.0.view", @"/Views/Actors/Details.cshtml")]
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
#line 1 "C:\Users\thato\Documents\code\MovieProApp\Views\_ViewImports.cshtml"
using MovieProApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\thato\Documents\code\MovieProApp\Views\_ViewImports.cshtml"
using MovieProApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\thato\Documents\code\MovieProApp\Views\Actors\Details.cshtml"
using MovieProApp.Models.TMDB;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f69c85274b4fab2bea7033876440aba68af5729", @"/Views/Actors/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f70b7227bd1e1c88b95def12b42cc79cd3d4c065", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Actors_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ActorDetail>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n    <div class=\"media\">\r\n        <img");
            BeginWriteAttribute("src", " src=\"", 93, "\"", 118, 1);
#nullable restore
#line 6 "C:\Users\thato\Documents\code\MovieProApp\Views\Actors\Details.cshtml"
WriteAttributeValue("", 99, Model.profile_path, 99, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""align-self-center mr-3"" alt=""..."">
        <div class=""media-body"">
            <div class=""row"">
                <table class=""table table-hover"">
                    <tbody>
                        <tr>
                            <td>Name:</td>
                            <td>
                                ");
#nullable restore
#line 14 "C:\Users\thato\Documents\code\MovieProApp\Views\Actors\Details.cshtml"
                           Write(Model.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td>Biography:</td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 20 "C:\Users\thato\Documents\code\MovieProApp\Views\Actors\Details.cshtml"
                           Write(Model.biography);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td>Birthday:</td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 26 "C:\Users\thato\Documents\code\MovieProApp\Views\Actors\Details.cshtml"
                           Write(Model.birthday);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td>Place of birth:</td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 32 "C:\Users\thato\Documents\code\MovieProApp\Views\Actors\Details.cshtml"
                           Write(Model.place_of_birth);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n\r\n                    </tbody>\r\n                </table>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\nview rawIntro Feature Set - Actors Details hosted with ❤ by GitHub");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ActorDetail> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591