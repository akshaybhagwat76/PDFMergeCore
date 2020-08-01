using Aspose.Pdf;
using Aspose.Pdf.Facades;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using PDFManipulations.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace PDFManipulations.Controllers
{
    public class PageFirstExtractController : Controller
    {
        static string rootFolder = Directory.GetCurrentDirectory();
        public static string outPutFilePath = rootFolder + "\\wwwroot\\MergedPDFs\\Extracted" + ".pdf";
        List<PdfReader> readerListpdf = new List<PdfReader>();
        byte[] password = Encoding.ASCII.GetBytes("123456");

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string ExtactImagesFromFile(EmpModel model)
        {
            try
            {
                string LData = "PExpY2Vuc2U+CjxEYXRhPgo8TGljZW5zZWRUbz5BdmVQb2ludDwvTGljZW5zZWRUbz4KPEVtYWlsVG8+aXRfYmlsbGluZ0BhdmVwb2ludC5jb208L0VtYWlsVG8+CjxMaWNlbnNlVHlwZT5EZXZlbG9wZXIgT0VNPC9MaWNlbnNlVHlwZT4KPExpY2Vuc2VOb3RlPkxpbWl0ZWQgdG8gMSBkZXZlbG9wZXIsIHVubGltaXRlZCBwaHlzaWNhbCBsb2NhdGlvbnM8L0xpY2Vuc2VOb3RlPgo8T3JkZXJJRD4xOTA1MjAwNzE1NDY8L09yZGVySUQ+CjxVc2VySUQ+MTU0ODI2PC9Vc2VySUQ+CjxPRU0+VGhpcyBpcyBhIHJlZGlzdHJpYnV0YWJsZSBsaWNlbnNlPC9PRU0+CjxQcm9kdWN0cz4KPFByb2R1Y3Q+QXNwb3NlLlRvdGFsIGZvciAuTkVUPC9Qcm9kdWN0Pgo8L1Byb2R1Y3RzPgo8RWRpdGlvblR5cGU+RW50ZXJwcmlzZTwvRWRpdGlvblR5cGU+CjxTZXJpYWxOdW1iZXI+Y2JmMzVkNWYtOWE2Ni00ZTI4LTg1ZGQtM2ExN2JiZTM0MTNhPC9TZXJpYWxOdW1iZXI+CjxTdWJzY3JpcHRpb25FeHBpcnk+MjAyMDA2MDQ8L1N1YnNjcmlwdGlvbkV4cGlyeT4KPExpY2Vuc2VWZXJzaW9uPjMuMDwvTGljZW5zZVZlcnNpb24+CjxMaWNlbnNlSW5zdHJ1Y3Rpb25zPmh0dHBzOi8vcHVyY2hhc2UuYXNwb3NlLmNvbS9wb2xpY2llcy91c2UtbGljZW5zZTwvTGljZW5zZUluc3RydWN0aW9ucz4KPC9EYXRhPgo8U2lnbmF0dXJlPnpqZDMrdWgzNTdiZHhqR3JWTTZCN3I2c250TkRBTlRXU2MyQi9RWS9hdmZxTnA0VHk5Z0kxR2V1NUdOaWVwRHArY1JrRFBMdjBDRTZ2MHNjYVZwK1JNTkF5SzdiUzdzeGZSL205Z0NtekFNUlptdUxQTm1laEtZVTNvOGJWVDJvWmRJeEY2dVRTMDhIclJxUnk5SWt6c3BxYmRrcEZFY0lGcHlLbDF2NlF2UT08L1NpZ25hdHVyZT4KPC9MaWNlbnNlPg==";

                Stream stream = new MemoryStream(Convert.FromBase64String(LData));

                stream.Seek(0, SeekOrigin.Begin);
                new Aspose.Pdf.License().SetLicense(stream);


                //// file license in app_code folder
                //Aspose.Pdf.License license = new Aspose.Pdf.License();
                //license.SetLicense(Server.MapPath("~/app_code/license.lic"));
                string rootFolder = Directory.GetCurrentDirectory();

                Stream fileStream = model.files.OpenReadStream();

                string outPutFilePath = rootFolder + "\\wwwroot\\ExtractedImages\\";
                PdfConverter objConverter = new PdfConverter();
                objConverter.BindPdf(fileStream);
                objConverter.DoConvert();
                objConverter.CoordinateType = PageCoordinateType.CropBox;
                var stamp = DateTime.Now.Ticks.ToString() + "_1.jpg";
                if (objConverter.HasNextImage())
                {
                    objConverter.GetNextImage(outPutFilePath + model.files.FileName + stamp, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                objConverter.Close();

                return "Image Extracted Succesfully in this path :- " + System.IO.Path.Combine(outPutFilePath, model.files.FileName + stamp);
            }
            catch (Exception ex)
            {

            }
            return "Some error occured, try after some time";
        }
    }
}