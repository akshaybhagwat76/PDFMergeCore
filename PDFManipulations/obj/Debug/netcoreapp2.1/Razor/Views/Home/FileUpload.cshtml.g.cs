#pragma checksum "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a14e97cfbc2f38479a538073eb897975de03e05"
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
#line 1 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\_ViewImports.cshtml"
using PDFManipulations;

#line default
#line hidden
#line 2 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\_ViewImports.cshtml"
using PDFManipulations.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a14e97cfbc2f38479a538073eb897975de03e05", @"/Views/Home/FileUpload.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f43beb3638c2d238f63bf81b445446b4aa2c191", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FileUpload : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PDFManipulations.Models.EmpModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
  
    ViewBag.Title = "PDF Operations";

#line default
#line hidden
            BeginContext(89, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
#line 9 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
 using (Html.BeginForm("FileUpload", "Home", FormMethod.Post, new { enctype = "multipart/form-data" } ))
{
    

#line default
#line hidden
            BeginContext(209, 23, false);
#line 11 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(236, 60, true);
            WriteLiteral("     <div class=\"form-horizontal\">\r\n        <hr />\r\n        ");
            EndContext();
            BeginContext(297, 64, false);
#line 15 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(361, 48, true);
            WriteLiteral("\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(410, 94, false);
#line 17 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
       Write(Html.LabelFor(model => model.files, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(504, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(560, 117, false);
#line 19 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.TextBoxFor(model => model.files, "", new { @type = "file", @multiple = "multiple", accept = "application/pdf" }));

#line default
#line hidden
            EndContext();
            BeginContext(677, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(696, 83, false);
#line 20 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ValidationMessageFor(model => model.files, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(779, 357, true);
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
            BeginContext(1137, 18, false);
#line 30 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(ViewBag.FileStatus);

#line default
#line hidden
            EndContext();
            BeginContext(1155, 126, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <div class=\"col-md-8\">\r\n                ");
            EndContext();
            BeginContext(1282, 58, false);
#line 36 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ActionLink("PDF Details", "Home", "Home/FileDetails"));

#line default
#line hidden
            EndContext();
            BeginContext(1340, 74, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-md-8\">\r\n                ");
            EndContext();
            BeginContext(1415, 78, false);
#line 39 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ActionLink("Merge Files", "MergeFiles", "MergePDF", "MergePDFController"));

#line default
#line hidden
            EndContext();
            BeginContext(1493, 76, true);
            WriteLiteral("\r\n\r\n            </div>\r\n            <div class=\"col-md-8\">\r\n                ");
            EndContext();
            BeginContext(1570, 97, false);
#line 43 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
           Write(Html.ActionLink("Extract Images", "ExtactImagesFromFile", "ImageExtract", "ExtactImagesFromFile"));

#line default
#line hidden
            EndContext();
            BeginContext(1667, 24, true);
            WriteLiteral("\r\n\r\n            </div>\r\n");
            EndContext();
            BeginContext(1823, 28, true);
            WriteLiteral("        </div>\r\n    </div>\r\n");
            EndContext();
#line 52 "D:\06 Nikunj\PDFMergeCore\PDFManipulations\Views\Home\FileUpload.cshtml"
     
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
