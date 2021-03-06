#pragma checksum "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2f41787f4f6234dd3eff58a33c92eb17f226b4c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FileUpload), @"mvc.1.0.view", @"/Views/Home/FileUpload.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/FileUpload.cshtml", typeof(AspNetCore.Views_Home_FileUpload))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2f41787f4f6234dd3eff58a33c92eb17f226b4c", @"/Views/Home/FileUpload.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82faf8331e42ecf488282cabdcd00fe0e9b25ca5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FileUpload : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PDFManipulations.Models.EmpModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
  
    ViewBag.Title = "PDF Operations";

#line default
#line hidden
            BeginContext(84, 3, true);
            WriteLiteral("\n\n\n");
            EndContext();
#line 9 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
 using (Html.BeginForm("FileUpload", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
            BeginContext(198, 23, false);
#line 11 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(223, 57, true);
            WriteLiteral("    <div class=\"form-horizontal\">\n        <hr />\n        ");
            EndContext();
            BeginContext(281, 64, false);
#line 15 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(345, 46, true);
            WriteLiteral("\n        <div class=\"form-group\">\n            ");
            EndContext();
            BeginContext(392, 94, false);
#line 17 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
       Write(Html.LabelFor(model => model.files, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(486, 53, true);
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
            EndContext();
            BeginContext(540, 89, false);
#line 19 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.TextBoxFor(model => model.files, "", new { @type = "file", @multiple = "multiple" }));

#line default
#line hidden
            EndContext();
            BeginContext(629, 17, true);
            WriteLiteral("\n                ");
            EndContext();
            BeginContext(647, 83, false);
#line 20 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ValidationMessageFor(model => model.files, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(730, 347, true);
            WriteLiteral(@"
            </div>
        </div>
        <div class=""form-group"">
            <div class=""col-md-offset-2 col-md-10"">
                <input type=""submit"" value=""Upload"" class=""btn btn-primary"" />
            </div>
        </div>
        <div class=""form-group"">
            <div class=""col-md-offset-2 col-md-10 text-success"">
                ");
            EndContext();
            BeginContext(1078, 18, false);
#line 30 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(ViewBag.FileStatus);

#line default
#line hidden
            EndContext();
            BeginContext(1096, 120, true);
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            <div class=\"col-md-8\">\n                ");
            EndContext();
            BeginContext(1217, 58, false);
#line 36 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ActionLink("PDF Details", "Home", "Home/FileDetails"));

#line default
#line hidden
            EndContext();
            BeginContext(1275, 71, true);
            WriteLiteral("\n            </div>\n            <div class=\"col-md-8\">\n                ");
            EndContext();
            BeginContext(1347, 54, false);
#line 39 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ActionLink("List PDFs", "Home", "Home/ListFiles"));

#line default
#line hidden
            EndContext();
            BeginContext(1401, 71, true);
            WriteLiteral("\n            </div>\n            <div class=\"col-md-8\">\n                ");
            EndContext();
            BeginContext(1473, 78, false);
#line 42 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ActionLink("Merge Files", "MergeFiles", "MergePDF", "MergePDFController"));

#line default
#line hidden
            EndContext();
            BeginContext(1551, 72, true);
            WriteLiteral("\n\n            </div>\n            <div class=\"col-md-8\">\n                ");
            EndContext();
            BeginContext(1624, 97, false);
#line 46 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ActionLink("Extract Images", "ExtactImagesFromFile", "ImageExtract", "ExtactImagesFromFile"));

#line default
#line hidden
            EndContext();
            BeginContext(1721, 72, true);
            WriteLiteral("\n\n            </div>\n            <div class=\"col-md-8\">\n                ");
            EndContext();
            BeginContext(1794, 66, false);
#line 50 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ActionLink("Extracted all Images", "ExtractedImages", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(1860, 71, true);
            WriteLiteral("\n            </div>\n            <div class=\"col-md-8\">\n                ");
            EndContext();
            BeginContext(1932, 82, false);
#line 53 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ActionLink("Extract First Pafe of PDF as Image", "Index", "PageFirstExtract"));

#line default
#line hidden
            EndContext();
            BeginContext(2014, 72, true);
            WriteLiteral("\n\n            </div>\n            <div class=\"col-md-8\">\n                ");
            EndContext();
            BeginContext(2087, 68, false);
#line 57 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ActionLink("Highlited PDF's", "HighlightedFileDetails", "Home"));

#line default
#line hidden
            EndContext();
            BeginContext(2155, 21, true);
            WriteLiteral("\n\n            </div>\n");
            EndContext();
            BeginContext(2296, 26, true);
            WriteLiteral("        </div>\n    </div>\n");
            EndContext();
#line 66 "F:\Saif\GitProject\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"

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
