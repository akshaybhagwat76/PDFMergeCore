#pragma checksum "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiless.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a33ddf453949f78163a80e98ae1a2a38b5c453a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MergePDF_MergeFiless), @"mvc.1.0.view", @"/Views/MergePDF/MergeFiless.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MergePDF/MergeFiless.cshtml", typeof(AspNetCore.Views_MergePDF_MergeFiless))]
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
#line 1 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\_ViewImports.cshtml"
using PDFManipulations;

#line default
#line hidden
#line 2 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\_ViewImports.cshtml"
using PDFManipulations.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a33ddf453949f78163a80e98ae1a2a38b5c453a", @"/Views/MergePDF/MergeFiless.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82faf8331e42ecf488282cabdcd00fe0e9b25ca5", @"/Views/_ViewImports.cshtml")]
    public class Views_MergePDF_MergeFiless : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 2 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiless.cshtml"
  
    ViewData["Title"] = "Merge Files";

#line default
#line hidden
            BeginContext(45, 90, true);
            WriteLiteral("\n<h2>Files has been merged and will be in ~\\wwwroot\\ Folder named MergedPDF</h2>\n<td>\n    ");
            EndContext();
            BeginContext(136, 63, false);
#line 8 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiless.cshtml"
Write(Html.ActionLink("Click to download", "DownloadFile","MergePDF"));

#line default
#line hidden
            EndContext();
            BeginContext(199, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(270, 7, true);
            WriteLiteral("</td>\n\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591