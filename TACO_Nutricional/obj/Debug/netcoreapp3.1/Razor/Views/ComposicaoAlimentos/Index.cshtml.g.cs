#pragma checksum "C:\Users\Marcos\source\repos\TACO_Nutricional\TACO_Nutricional\Views\ComposicaoAlimentos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "17721fbb0c50f13ee7c2c66ab64f66cfcdba9eca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ComposicaoAlimentos_Index), @"mvc.1.0.view", @"/Views/ComposicaoAlimentos/Index.cshtml")]
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
#line 1 "C:\Users\Marcos\source\repos\TACO_Nutricional\TACO_Nutricional\Views\_ViewImports.cshtml"
using TACO_Nutricional;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Marcos\source\repos\TACO_Nutricional\TACO_Nutricional\Views\_ViewImports.cshtml"
using TACO_Nutricional.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17721fbb0c50f13ee7c2c66ab64f66cfcdba9eca", @"/Views/ComposicaoAlimentos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cba4cbea129fc3431dc499673736ea57734d52e8", @"/Views/_ViewImports.cshtml")]
    public class Views_ComposicaoAlimentos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TACO_Nutricional.Models.Entidades.Alimento>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Marcos\source\repos\TACO_Nutricional\TACO_Nutricional\Views\ComposicaoAlimentos\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1> <i class=""fas fa-apple-alt text-success""></i>  Alimentos</h1>


<table class=""table table-hover table-striped"">

    <thead>
        <tr>
            <th scope=""col"">Nome</th>
            <th class=""text-center"" scope=""col"">Kcal</th>
            <th class=""text-center"" scope=""col"">Proteínas</th>
            <th class=""text-center"" scope=""col"">Lipídeos</th>
            <th class=""text-center"" scope=""col"">Carboidratos</th>
        </tr>
    </thead>

    <tbody>

");
#nullable restore
#line 24 "C:\Users\Marcos\source\repos\TACO_Nutricional\TACO_Nutricional\Views\ComposicaoAlimentos\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">");
#nullable restore
#line 27 "C:\Users\Marcos\source\repos\TACO_Nutricional\TACO_Nutricional\Views\ComposicaoAlimentos\Index.cshtml"
                           Write(item.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td class=\"text-center\">");
#nullable restore
#line 28 "C:\Users\Marcos\source\repos\TACO_Nutricional\TACO_Nutricional\Views\ComposicaoAlimentos\Index.cshtml"
                                   Write(item.Caloria.ToString("0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"text-center\">");
#nullable restore
#line 29 "C:\Users\Marcos\source\repos\TACO_Nutricional\TACO_Nutricional\Views\ComposicaoAlimentos\Index.cshtml"
                                   Write(item.Proteina.ToString("0.0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"text-center\">");
#nullable restore
#line 30 "C:\Users\Marcos\source\repos\TACO_Nutricional\TACO_Nutricional\Views\ComposicaoAlimentos\Index.cshtml"
                                   Write(item.Lipideos.ToString("0.0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td class=\"text-center\"> ");
#nullable restore
#line 31 "C:\Users\Marcos\source\repos\TACO_Nutricional\TACO_Nutricional\Views\ComposicaoAlimentos\Index.cshtml"
                                    Write(item.Carboidrato.ToString("0.0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 33 "C:\Users\Marcos\source\repos\TACO_Nutricional\TACO_Nutricional\Views\ComposicaoAlimentos\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        \r\n    </tbody>\r\n\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TACO_Nutricional.Models.Entidades.Alimento>> Html { get; private set; }
    }
}
#pragma warning restore 1591
