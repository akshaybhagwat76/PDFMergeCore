#pragma checksum "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03289c0c04832393b2ccd7e62ec839e4ca7bdcdf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MergePDF_MergeFiles), @"mvc.1.0.view", @"/Views/MergePDF/MergeFiles.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MergePDF/MergeFiles.cshtml", typeof(AspNetCore.Views_MergePDF_MergeFiles))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03289c0c04832393b2ccd7e62ec839e4ca7bdcdf", @"/Views/MergePDF/MergeFiles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82faf8331e42ecf488282cabdcd00fe0e9b25ca5", @"/Views/_ViewImports.cshtml")]
    public class Views_MergePDF_MergeFiles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PDFManipulations.Models.EmpModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiles.cshtml"
  
    ViewBag.Title = "PDF Operations";

#line default
#line hidden
            BeginContext(84, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 7 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiles.cshtml"
 using (Html.BeginForm("MergeFiless", "MergePDF", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
            BeginContext(201, 23, false);
#line 9 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiles.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(226, 45, true);
            WriteLiteral("<div class=\"form-horizontal\">\n    <hr />\n    ");
            EndContext();
            BeginContext(272, 64, false);
#line 13 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiles.cshtml"
Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(336, 38, true);
            WriteLiteral("\n    <div class=\"form-group\">\n        ");
            EndContext();
            BeginContext(375, 94, false);
#line 15 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiles.cshtml"
   Write(Html.LabelFor(model => model.files, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(469, 45, true);
            WriteLiteral("\n        <div class=\"col-md-10\">\n            ");
            EndContext();
            BeginContext(515, 89, false);
#line 17 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiles.cshtml"
       Write(Html.TextBoxFor(model => model.files, "", new { @type = "file", @multiple = "multiple" }));

#line default
#line hidden
            EndContext();
            BeginContext(604, 13, true);
            WriteLiteral("\n            ");
            EndContext();
            BeginContext(618, 83, false);
#line 18 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiles.cshtml"
       Write(Html.ValidationMessageFor(model => model.files, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(701, 306, true);
            WriteLiteral(@"
        </div>
    </div>
    <div class=""form-group"">
        <div class=""col-md-offset-2 col-md-10"">
            <input type=""submit"" value=""Merge"" class=""btn btn-primary"" />
        </div>
    </div>
    <div class=""form-group"">
        <div class=""col-md-offset-2 col-md-10 text-success"">
            ");
            EndContext();
            BeginContext(1008, 18, false);
#line 28 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiles.cshtml"
       Write(ViewBag.FileStatus);

#line default
#line hidden
            EndContext();
            BeginContext(1026, 45, true);
            WriteLiteral("\n        </div>\n    </div>\n    <div>\n        ");
            EndContext();
            BeginContext(1072, 64, false);
#line 32 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiles.cshtml"
   Write(Html.ActionLink("Click to download", "DownloadFile", "MergePDF"));

#line default
#line hidden
            EndContext();
            BeginContext(1136, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(1211, 19, true);
            WriteLiteral("    </div>\n\n</div>\n");
            EndContext();
#line 37 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\MergePDF\MergeFiles.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PDFManipulations.Models.EmpModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
