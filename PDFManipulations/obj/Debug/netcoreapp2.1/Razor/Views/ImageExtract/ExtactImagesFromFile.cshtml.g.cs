#pragma checksum "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "688e982da752ea2f6ccbb2f81fc2087009441eca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ImageExtract_ExtactImagesFromFile), @"mvc.1.0.view", @"/Views/ImageExtract/ExtactImagesFromFile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ImageExtract/ExtactImagesFromFile.cshtml", typeof(AspNetCore.Views_ImageExtract_ExtactImagesFromFile))]
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
#line 1 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\_ViewImports.cshtml"
using PDFManipulations;

#line default
#line hidden
#line 2 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\_ViewImports.cshtml"
using PDFManipulations.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"688e982da752ea2f6ccbb2f81fc2087009441eca", @"/Views/ImageExtract/ExtactImagesFromFile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82faf8331e42ecf488282cabdcd00fe0e9b25ca5", @"/Views/_ViewImports.cshtml")]
    public class Views_ImageExtract_ExtactImagesFromFile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PDFManipulations.Models.EmpModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
  
    ViewBag.Title = "PDF Operations";

#line default
#line hidden
            BeginContext(89, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
 if (ViewBag.ImageExtracted != null)
{

#line default
#line hidden
            BeginContext(132, 49, true);
            WriteLiteral("    <script type=\"text/javascript\">\r\n      alert(");
            EndContext();
            BeginContext(182, 22, false);
#line 10 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
       Write(ViewBag.ImageExtracted);

#line default
#line hidden
            EndContext();
            BeginContext(204, 19, true);
            WriteLiteral(");\r\n    </script>\r\n");
            EndContext();
            BeginContext(228, 22, false);
#line 12 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
Write(ViewBag.ImageExtracted);

#line default
#line hidden
            EndContext();
#line 12 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
                           
}

#line default
#line hidden
            BeginContext(255, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 15 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
 using (Html.BeginForm("ExtactImagesFromFile", "ImageExtract", FormMethod.Post, new { enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
            BeginContext(388, 23, false);
#line 17 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(415, 59, true);
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <hr />\r\n        ");
            EndContext();
            BeginContext(475, 64, false);
#line 21 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(539, 48, true);
            WriteLiteral("\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(588, 94, false);
#line 23 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
       Write(Html.LabelFor(model => model.files, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(682, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(738, 89, false);
#line 25 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
           Write(Html.TextBoxFor(model => model.files, "", new { @type = "file", @multiple = "multiple" }));

#line default
#line hidden
            EndContext();
            BeginContext(827, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(846, 83, false);
#line 26 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
           Write(Html.ValidationMessageFor(model => model.files, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(929, 358, true);
            WriteLiteral(@"
            </div>
        </div>
        <div class=""form-group"">
            <div class=""col-md-offset-2 col-md-10"">
                <input type=""submit"" value=""Extract"" class=""btn btn-primary"" />
            </div>
        </div>
        <div class=""form-group"">
            <div class=""col-md-offset-2 col-md-10 text-success"">
                ");
            EndContext();
            BeginContext(1288, 18, false);
#line 36 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
           Write(ViewBag.FileStatus);

#line default
#line hidden
            EndContext();
            BeginContext(1306, 53, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div>\r\n");
            EndContext();
            BeginContext(1525, 30, true);
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n");
            EndContext();
#line 45 "F:\MyResearch\PDFManipulations-master\PDFManipulations-master\PDFManipulations\Views\ImageExtract\ExtactImagesFromFile.cshtml"
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
