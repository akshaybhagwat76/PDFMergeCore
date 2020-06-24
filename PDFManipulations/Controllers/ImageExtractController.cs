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
using PDFManipulations.Helpers;

namespace PDFManipulations.Controllers
{
    public class ImageExtractController : Controller
    {
        
        static string rootFolder = Directory.GetCurrentDirectory();
        public static string outPutFilePath = rootFolder + "\\wwwroot\\MergedPDFs\\Extracted" + ".pdf";
        List<PdfReader> readerListpdf = new List<PdfReader>();
        byte[] password = Encoding.ASCII.GetBytes("123456");

        [HttpGet]
        public IActionResult ExtactImagesFromFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExtactImagesFromFile(EmpModel model)
        {
            try
            {
                string rootFolder = Directory.GetCurrentDirectory();

                Stream fileStream = model.files.OpenReadStream();

                 string outPutFilePath = rootFolder + "\\wwwroot\\ExtractedImages\\";


                var images = PdfImageExtractor.ExtractImages(fileStream, model.files.FileName);
                var directory = System.IO.Path.GetDirectoryName(outPutFilePath);

                foreach (var name in images.Keys)
                {
                    images[name].Save(System.IO.Path.Combine(directory, name));
                }

                ViewBag.ImageExtracted = "Image Extracted Succesfully in this path :- " + outPutFilePath;
            }
            catch (Exception)
            {

            }
            return View();
        }
    }
}
