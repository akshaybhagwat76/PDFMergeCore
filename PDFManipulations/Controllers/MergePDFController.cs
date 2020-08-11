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

namespace PDFManipulations.Controllers
{
    public class MergePDFController : Controller
    {

        static string rootFolder = Directory.GetCurrentDirectory();
        public static string outPutFilePath = rootFolder + "\\wwwroot\\MergedPDFs\\Extracted" + ".pdf";
        List<PdfReader> readerListpdf = new List<PdfReader>();
        byte[] password = Encoding.ASCII.GetBytes("123456");

        List<PdfReader> readerList = new List<PdfReader>();
        List<byte[]> combineBytes = new List<byte[]>();
        private Stream st;

        [HttpGet]
        [Route("MergePDFController")]
        public IActionResult MergeFiles()
        {
            return View();
        }
        [HttpPost]
        [Route("MergePDFController/MergeFiless")]
        public ActionResult MergeFiless(IFormFile[] files)
        {
            ViewBag.Message = string.Empty;
            if (files.Length==0)
            {
                ViewBag.Message = "Select some file before you click merge.";
                return View("MergeFiles");
            }
            byte[] password = Encoding.ASCII.GetBytes("123456");

            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    Stream fileStream = files[i].OpenReadStream();
                    var mStreamer = new MemoryStream();

                    mStreamer.SetLength(fileStream.Length);
                    fileStream.Read(mStreamer.GetBuffer(), 0, (int)fileStream.Length);
                    mStreamer.Seek(0, SeekOrigin.Begin);
                    PdfReader pdfReader = new PdfReader(mStreamer, password);
                    readerListpdf.Add(pdfReader);
                    mStreamer.Flush();
                    mStreamer.Dispose();
                }

                Document ManagementReportDoc = new iTextSharp.text.Document(PageSize.A4, 15f, 15f, 75f, 75f);

                FileStream file = new FileStream(outPutFilePath, FileMode.OpenOrCreate);

                PdfWriter writer = PdfWriter.GetInstance(ManagementReportDoc, file); // PdfWriter.GetInstance(ManagementReportDoc, file);

                ManagementReportDoc.Open();

                foreach (PdfReader reader in readerListpdf)
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        PdfImportedPage page = writer.GetImportedPage(reader, i);
                        ManagementReportDoc.Add(iTextSharp.text.Image.GetInstance(page));
                    }
                }
                ManagementReportDoc.Close();
                writer.Dispose();
                ManagementReportDoc.Dispose();
                ViewBag.fileDownload = outPutFilePath;
                return View();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return View(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile()
        {
            var path = outPutFilePath;

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 4096, true))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/pdf", Path.GetFileName(path));
        }
    }
}

