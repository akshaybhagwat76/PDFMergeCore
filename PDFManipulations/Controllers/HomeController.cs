using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PDFManipulations.Models;
using iTextSharp.text.pdf;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using iTextSharp.text;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using iTextSharp.text.pdf.parser;
using System.Security.Cryptography;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using PDFManipulations.Common;

namespace PDFManipulations.Controllers
{
    public class HomeController : Controller
    {

        byte[] password = Encoding.ASCII.GetBytes("123456");
        private IHostingEnvironment _environment;
        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUpload(IFormFile files)
        {

            String FileExt = System.IO.Path.GetExtension(files.FileName).ToUpper();

            if (FileExt == ".PDF")
            {
                if (string.IsNullOrWhiteSpace(_environment.WebRootPath))
                {
                    _environment.WebRootPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }


                var uploads = System.IO.Path.Combine(_environment.WebRootPath, "Files");

                if (!System.IO.Directory.Exists(uploads))
                {
                    System.IO.Directory.CreateDirectory(uploads);
                }

                if (files.Length > 0)
                {
                    var filePath = System.IO.Path.Combine(uploads, files.FileName);
                    using (var FileStremUploaded = new FileStream(filePath, FileMode.Create))
                    {
                        files.CopyTo(FileStremUploaded);
                    }
                }

                Stream fileStream = files.OpenReadStream();
                var mStreamer = new MemoryStream(1000 * 1024);
                mStreamer.SetLength(fileStream.Length);
                fileStream.Read(mStreamer.GetBuffer(), 0, (int)fileStream.Length);
                mStreamer.Seek(0, SeekOrigin.Begin);
                byte[] bytes = mStreamer.GetBuffer();

                FileStream fs = new FileStream(files.FileName, FileMode.Append, FileAccess.Write);
                using (MemoryStream inputData = new MemoryStream(bytes))
                {
                    using (MemoryStream outputData = new MemoryStream())
                    {

                        iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(bytes, password);
                        var font = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.WINANSI, BaseFont.EMBEDDED);
                        byte[] watemarkedbytes = AddWatermark(bytes, font);


                        iTextSharp.text.pdf.PdfReader awatemarkreader = new iTextSharp.text.pdf.PdfReader(watemarkedbytes, password);
                        FileDetailsModel Fd = new Models.FileDetailsModel();
                        PdfEncryptor.Encrypt(awatemarkreader, outputData, true, "123456", "123456", PdfWriter.ALLOW_MODIFY_CONTENTS);

                        bytes = outputData.ToArray();

                        return File(bytes, "application/pdf");
                    }
                }
            }
            else
            {
                ViewBag.FileStatus = "Invalid file format.";
                return View();

            }

        }


        #region View Uploaded files
        [HttpGet]
        public ViewResult FileDetails()
        {
            var uploads = System.IO.Path.Combine(_environment.WebRootPath);
            List<FileDetailsModel> DetList = new List<FileDetailsModel>();
            if (Directory.Exists(uploads))
            {
                string supportedExtensions = "*.pdf";
                foreach (string file in Directory.GetFiles(uploads, supportedExtensions, SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(System.IO.Path.GetExtension(s).ToLower())))
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        if (!file.ToLower().Contains("merged pdfs"))
                        {

                            FileDetailsModel obj = new FileDetailsModel();
                            obj.FileName = System.IO.Path.GetFileName(file);
                            obj.FileTextContent = file;
                            DetList.Add(obj);
                        }
                    }
                }
            }

            return View("FileDetails", DetList);
        }


        [HttpGet]
        public ViewResult ListFiles()
        {
            var uploads = System.IO.Path.Combine(_environment.WebRootPath);
            List<FileDetailsModel> DetList = new List<FileDetailsModel>();
            if (Directory.Exists(uploads))
            {
                string supportedExtensions = "*.pdf";
                var files = Directory.GetFiles(uploads, supportedExtensions, SearchOption.AllDirectories).
                    Where(s => supportedExtensions.Contains(System.IO.Path.GetExtension(s).ToLower()));
                foreach (string file in files)
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        if (!file.ToLower().Contains("merged pdfs"))
                        {

                            FileDetailsModel obj = new FileDetailsModel();
                            obj.FileName = System.IO.Path.GetFileName(file);
                            obj.FileTextContent = file;
                            DetList.Add(obj);
                        }
                    }
                }
            }
            return View("ListFiles", DetList);
        }
        #endregion


        #region View Highlited Uploaded files
        [HttpGet]
        public ViewResult HighlightedFileDetails()
        {
            int count = 1;
            var uploads = System.IO.Path.Combine(_environment.WebRootPath);
            List<FileDetailsModel> DetList = new List<FileDetailsModel>();
            if (Directory.Exists(uploads))
            {
                string supportedExtensions = "*.pdf";
                foreach (string file in Directory.GetFiles(uploads, supportedExtensions, SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(System.IO.Path.GetExtension(s).ToLower())))
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        if (file.ToLower().Contains("highlighted"))
                        {

                            FileDetailsModel obj = new FileDetailsModel();
                            obj.Id = count;
                            obj.FileName = System.IO.Path.GetFileNameWithoutExtension(file);

                            //obj.FileTextContent = "../../books/pdf/FoxitPdfSdk.pdf";
                            obj.FileTextContent = string.Format("../../Highlighted/{0}", System.IO.Path.GetFileName(file));
                            DetList.Add(obj);
                            count++;
                        }
                    }
                }
            }

            return View("HighlightedFileDetails", DetList);
        }
        #endregion

        #region View Extracted Images files
        [HttpGet]
        public ViewResult ExtractedImages()
        {
            var uploads = System.IO.Path.Combine(_environment.WebRootPath);
            List<FileDetailsModel> DetList = new List<FileDetailsModel>();
            if (Directory.Exists(uploads))
            {
                string supportedExtensions = "*.jpg";
                foreach (string file in Directory.GetFiles(uploads, supportedExtensions, SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(System.IO.Path.GetExtension(s).ToLower())).OrderByDescending(d=> new FileInfo(d).CreationTime))
                {
                    if (!string.IsNullOrEmpty(file))
                    {
                        if (file.ToLower().Contains("extractedimages"))
                        {
                            FileDetailsModel obj = new FileDetailsModel();
                            obj.FileName = ConvertImageURLToBase64(file);
                            obj.FileTextContent = file;
                            DetList.Add(obj);
                        }
                    }
                }
            }

            return View("ExtractedImages", DetList);
        }
        #endregion
        /// <summary>
        /// read data from file and db
        /// </summary>
        /// <param name="searchText">searchtext</param>
        /// <returns>return data</returns>
        [HttpGet]
        public IActionResult readDataFromFileAndDB(string searchText)
        {

            var result = new List<string>();

            var uploads = System.IO.Path.Combine(_environment.WebRootPath);
            List<SearchData> listData = new List<SearchData>();
            if (searchText != null)
            {
                if (Directory.Exists(uploads))
                {
                    string supportedExtensions = "*.pdf";
                    foreach (string imageFile in Directory.GetFiles(uploads, supportedExtensions, SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(System.IO.Path.GetExtension(s).ToLower())))
                    {
                        string ext = System.IO.Path.GetFileName(imageFile);

                        if (!string.IsNullOrEmpty(ext))
                        {
                            if (!imageFile.ToLower().Contains("merged pdfs"))
                            {

                                if (ReadPdfFile(imageFile, searchText))
                                {
                                    listData.Add(new SearchData
                                    {
                                        SearchDescription = searchText,
                                        SearchPath = imageFile,
                                        FileName = ext
                                    });
                                }
                            }
                        }
                    }
                }
            }

            return Ok(listData);
        }

        public Boolean ReadPdfFile(string fileName, String searthText)
        {
            if (System.IO.File.Exists(fileName))
            {
                InjectAsposeLicemse();

                var document = new Aspose.Pdf.Document(fileName);

                TextAbsorber textAbsorber = new TextAbsorber();
                document.Pages.Accept(textAbsorber);
                String extractedText = textAbsorber.Text;
                textAbsorber.Visit(document);
                if (extractedText.Contains(searthText, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// HighlightPDF
        /// </summary>
        /// <param name="path"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult HighlightPDF(string path, string desc)
        {
            List<FileDetails> DetList = new List<FileDetails>();
            byte[] result = null;
            if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(desc))
            {
                var details = FetchParagraph(path, desc);
                result = SearcText(path, desc).ToArray();

                if (string.IsNullOrWhiteSpace(_environment.WebRootPath))
                {
                    _environment.WebRootPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }


                var uploads = System.IO.Path.Combine(_environment.WebRootPath, "Highlighted");

                if (!System.IO.Directory.Exists(uploads))
                {
                    System.IO.Directory.CreateDirectory(uploads);
                }


                var filePath = System.IO.Path.Combine(uploads, string.Format("{0}.pdf", System.IO.Path.GetFileNameWithoutExtension(path)));
                System.IO.File.WriteAllBytes(filePath, result);
                DetList.Add(new FileDetails() { FileName = System.IO.Path.GetFileName(path), FilePath = filePath, ParaDetails = details });

            }
            return View("HighLightDetails", DetList);
        }
        /// <summary>
        /// Written by Fredio
        /// </summary>
        /// <param name="path"></param>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public System.IO.MemoryStream SearcText(string path, string phrase)
        {
            InjectAsposeLicemse();

            Aspose.Pdf.Document document = new Aspose.Pdf.Document(path);
            string searchTextValue = string.Format("(?i){0}", phrase);
            TextFragmentAbsorber textFragmentAbsorber = new TextFragmentAbsorber(searchTextValue, new TextSearchOptions(true));
            //TextSearchOptions textSearchOptions = new TextSearchOptions(true);
            //textFragmentAbsorber.TextSearchOptions = textSearchOptions;
            document.Pages.Accept(textFragmentAbsorber);
            TextFragmentCollection textFragmentCollection1 = textFragmentAbsorber.TextFragments;
            if (textFragmentCollection1.Count > 0)
            {
                foreach (TextFragment textFragment in textFragmentCollection1)
                {
                    Aspose.Pdf.Annotations.HighlightAnnotation freeText = new Aspose.Pdf.Annotations.HighlightAnnotation(textFragment.Page, new Aspose.Pdf.Rectangle(textFragment.Position.XIndent, textFragment.Position.YIndent, textFragment.Position.XIndent + textFragment.Rectangle.Width, textFragment.Position.YIndent + textFragment.Rectangle.Height));
                    freeText.Opacity = 0.5;
                    //freeText.Color = Aspose.Pdf.Color.FromRgb(0.6, 0.8, 0.98);
                    freeText.Color = Aspose.Pdf.Color.Yellow;
                    textFragment.Page.Annotations.Add(freeText);
                }
                
            }
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            document.Save(ms);
            return ms;
        }

        public List<ParaDetails> FetchParagraph(string path, string phrase)
        {
            var paraDetails = new List<ParaDetails>();
            InjectAsposeLicemse();

            Aspose.Pdf.Document document = new Aspose.Pdf.Document(path);
            ParagraphAbsorber absorber = new ParagraphAbsorber();
            absorber.Visit(document);
            foreach (PageMarkup markup in absorber.PageMarkups)
            {
                int i = 1;
                foreach (MarkupSection section in markup.Sections)
                {
                    int j = 1;
                    foreach (MarkupParagraph paragraph in section.Paragraphs)
                    {
                        StringBuilder paragraphText = new StringBuilder();

                        foreach (List<TextFragment> line in paragraph.Lines)
                        {
                            foreach (TextFragment fragment in line)
                            {
                                paragraphText.Append(fragment.Text);
                            }
                            paragraphText.Append("\r\n");
                        }
                        paragraphText.Append("\r\n");
                        var paratext = paragraphText.ToString();
                        if (paratext.Contains(phrase, StringComparison.InvariantCultureIgnoreCase))
                        {
                            var paraDetail = new ParaDetails();
                            paraDetail.Details = string.Format("Page {2}, Section {1}, Paragraph {0} says:", j, i, markup.Number);
                            paraDetail.Text = paratext;
                            paraDetails.Add(paraDetail);
                        }
                        j++;
                    }
                    i++;
                }
            }
            return paraDetails;
        }

        private static void InjectAsposeLicemse()
        {
            string LData = "PExpY2Vuc2U+CjxEYXRhPgo8TGljZW5zZWRUbz5BdmVQb2ludDwvTGljZW5zZWRUbz4KPEVtYWlsVG8+aXRfYmlsbGluZ0BhdmVwb2ludC5jb208L0VtYWlsVG8+CjxMaWNlbnNlVHlwZT5EZXZlbG9wZXIgT0VNPC9MaWNlbnNlVHlwZT4KPExpY2Vuc2VOb3RlPkxpbWl0ZWQgdG8gMSBkZXZlbG9wZXIsIHVubGltaXRlZCBwaHlzaWNhbCBsb2NhdGlvbnM8L0xpY2Vuc2VOb3RlPgo8T3JkZXJJRD4xOTA1MjAwNzE1NDY8L09yZGVySUQ+CjxVc2VySUQ+MTU0ODI2PC9Vc2VySUQ+CjxPRU0+VGhpcyBpcyBhIHJlZGlzdHJpYnV0YWJsZSBsaWNlbnNlPC9PRU0+CjxQcm9kdWN0cz4KPFByb2R1Y3Q+QXNwb3NlLlRvdGFsIGZvciAuTkVUPC9Qcm9kdWN0Pgo8L1Byb2R1Y3RzPgo8RWRpdGlvblR5cGU+RW50ZXJwcmlzZTwvRWRpdGlvblR5cGU+CjxTZXJpYWxOdW1iZXI+Y2JmMzVkNWYtOWE2Ni00ZTI4LTg1ZGQtM2ExN2JiZTM0MTNhPC9TZXJpYWxOdW1iZXI+CjxTdWJzY3JpcHRpb25FeHBpcnk+MjAyMDA2MDQ8L1N1YnNjcmlwdGlvbkV4cGlyeT4KPExpY2Vuc2VWZXJzaW9uPjMuMDwvTGljZW5zZVZlcnNpb24+CjxMaWNlbnNlSW5zdHJ1Y3Rpb25zPmh0dHBzOi8vcHVyY2hhc2UuYXNwb3NlLmNvbS9wb2xpY2llcy91c2UtbGljZW5zZTwvTGljZW5zZUluc3RydWN0aW9ucz4KPC9EYXRhPgo8U2lnbmF0dXJlPnpqZDMrdWgzNTdiZHhqR3JWTTZCN3I2c250TkRBTlRXU2MyQi9RWS9hdmZxTnA0VHk5Z0kxR2V1NUdOaWVwRHArY1JrRFBMdjBDRTZ2MHNjYVZwK1JNTkF5SzdiUzdzeGZSL205Z0NtekFNUlptdUxQTm1laEtZVTNvOGJWVDJvWmRJeEY2dVRTMDhIclJxUnk5SWt6c3BxYmRrcEZFY0lGcHlLbDF2NlF2UT08L1NpZ25hdHVyZT4KPC9MaWNlbnNlPg==";

            Stream stream = new MemoryStream(Convert.FromBase64String(LData));
            stream.Seek(0, SeekOrigin.Begin);
            new Aspose.Pdf.License().SetLicense(stream);
        }

        public byte[] AddWatermark(byte[] bytes, BaseFont bf)
        {
            using (var ms = new MemoryStream(1000 * 1024))
            {
                PdfReader reader = new PdfReader(bytes, password);

                PdfStamper stamper = new PdfStamper(reader, ms);
                stamper.SetEncryption(password, password, PdfWriter.ALLOW_MODIFY_ANNOTATIONS, PdfWriter.STRENGTH40BITS);

                PdfContentByte waterMark;
                int times = reader.NumberOfPages;

                if (string.IsNullOrWhiteSpace(_environment.WebRootPath))
                {
                    _environment.WebRootPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                }

                for (int pageIndex = 1; pageIndex <= reader.NumberOfPages; pageIndex++)
                {
                    waterMark = stamper.GetOverContent(pageIndex);
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(_environment.WebRootPath + "\\images\\12097871.jpg");
                    img.SetAbsolutePosition(100, 100);
                    waterMark.AddImage(img);
                }
                stamper.FormFlattening = true;


                stamper.Close();

                return ms.ToArray();
            }
        }

        public String ConvertImageURLToBase64(String url)
        {
            StringBuilder _sb = new StringBuilder();

            Byte[] _byte = System.IO.File.ReadAllBytes(url);

            _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));

            return _sb.ToString();
        }

        [HttpGet]
        public IActionResult ViewListedPDF(string path)
        {
            InjectAsposeLicemse();
            byte[] result = null;
            if (!string.IsNullOrEmpty(path))
            {
                InjectAsposeLicemse();
                Aspose.Pdf.Document document = new Aspose.Pdf.Document(path);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                document.Save(ms);
                result = ms.ToArray();
            }
            return File(result, "application/pdf");
        }

    }
}


