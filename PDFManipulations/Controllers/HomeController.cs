﻿using System;
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

                        //ReaderProperties rp = new ReaderProperties();

                        iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(bytes, password);
                        var font = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.WINANSI, BaseFont.EMBEDDED);
                        byte[] watemarkedbytes = AddWatermark(bytes, font);

                        int PageNum = reader.NumberOfPages;
                        string[] words;
                        string line = string.Empty;

                        for (int i = 1; i <= PageNum; i++)
                        {
                            string text = PdfTextExtractor.GetTextFromPage(reader, i, new LocationTextExtractionStrategy());

                            words = text.Split('\n');
                            for (int j = 0, len = words.Length; j < len; j++)
                            {
                                line += Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
                            }
                        }

                        iTextSharp.text.pdf.PdfReader awatemarkreader = new iTextSharp.text.pdf.PdfReader(watemarkedbytes, password);
                        FileDetailsModel Fd = new Models.FileDetailsModel();
                        Fd.FileContentWithoutPWD = outputData.ToArray();
                        PdfEncryptor.Encrypt(awatemarkreader, outputData, true, "123456", "123456", PdfWriter.ALLOW_MODIFY_CONTENTS);

                        bytes = outputData.ToArray();

                        Fd.FileName = files.FileName;
                        Fd.FileContent = bytes;
                        Fd.FileTextContent = line;
                        SaveFileDetails(Fd);
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

        [HttpGet]
        public ActionResult DownLoadFile(int id)
        {
            List<FileDetailsModel> ObjFiles = GetFileList();

            var FileById = (from FC in ObjFiles
                            where FC.Id.Equals(id)
                            select new { FC.FileName, FC.FileContent }).ToList().FirstOrDefault();
            return File(FileById.FileContent, "application/pdf");
        }



        #region View Uploaded files
        [HttpGet]
        public ViewResult FileDetails()
        {
            List<FileDetailsModel> DetList = GetFileList();
            return View("FileDetails", DetList);
        }

        [HttpGet]
        public ViewResult ViewPDF(int id)
        {
            List<FileDetailsModel> ObjFiles = GetFileList();

            var FileById = (from FC in ObjFiles
                            where FC.Id.Equals(id)
                            select new { FC.Id, FC.FileName, FC.FileContent }).ToList().FirstOrDefault();

            ViewData["ID"] = FileById.Id;
            // return File(FileById.FileContent, "application/pdf", FileById.FileName);

            return View();
            // return View();

        }

        private List<FileDetailsModel> GetFileList()
        {
            DbConnection();
            con.Open();
            List<FileDetailsModel> DetList = SqlMapper.Query<FileDetailsModel>(con, "GetFileDetails", commandType: CommandType.StoredProcedure).ToList();
            con.Close();
            return DetList;
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
            var listOfFiles = GetFileList();
            if (searchText != null)
            {
                if (Directory.Exists(uploads))
                {
                    string supportedExtensions = "*.pdf";
                    foreach (string imageFile in Directory.GetFiles(uploads, "*.*", SearchOption.AllDirectories).Where(s => supportedExtensions.Contains(System.IO.Path.GetExtension(s).ToLower())))
                    {
                        string ext = System.IO.Path.GetFileName(imageFile);

                        bool bResult = listOfFiles.Any(cus => cus.FileName == ext);
                        var fileFromDB = listOfFiles.Where(x => x.FileName == ext).FirstOrDefault();
                        if (bResult && fileFromDB != null && !string.IsNullOrEmpty(fileFromDB.FileTextContent))
                        {

                            if (fileFromDB.FileTextContent.ToLower().Contains(searchText.ToLower()))
                            {
                                listData.Add(new SearchData
                                {
                                    SearchDescription = searchText.ToLower(),
                                    SearchPath = imageFile
                                });
                            }
                        }
                    }
                }
            }

            return Ok(listData);
        }


        #region Database related operations
        private void SaveFileDetails(FileDetailsModel objDet)
        {

            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@FileName", objDet.FileName);
            Parm.Add("@FileContent", objDet.FileContent);
            Parm.Add("@FileTextContent", objDet.FileTextContent);
            Parm.Add("@FileContentWithoutPWD", objDet.FileContentWithoutPWD);

            DbConnection();
            con.Open();
            con.Execute("AddFileDetails", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();


        }
        #endregion

        /// <summary>
        /// HighlightPDF
        /// </summary>
        /// <param name="path"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult HighlightPDF(string path, string desc)
        {
            if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(desc))
            {
                var testFile = path;

                PdfReader reader = new PdfReader(testFile);

                var numberOfPages = reader.NumberOfPages;
                System.Globalization.CompareOptions cmp = System.Globalization.CompareOptions.None;
                //Create an instance of our strategy

                MemoryStream m = new MemoryStream();

                //using (var fs = new FileStream(highLightFile, FileMode.Create, FileAccess.Write, FileShare.None))
                //{
                using (Document document = new Document(PageSize.A4))
                {
                    PdfWriter.GetInstance(document, m);

                    using (PdfStamper stamper = new PdfStamper(reader, m))
                    {
                        //document.Open();
                        for (var currentPageIndex = 1; currentPageIndex <= numberOfPages; currentPageIndex++)
                        {

                            MyLocationTextExtractionStrategy strategyTest = new MyLocationTextExtractionStrategy(desc);
                            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                            //Parse page 1 of the document above
                            using (var r = new PdfReader(testFile))
                            {
                                var ex = PdfTextExtractor.GetTextFromPage(r, currentPageIndex, strategyTest);
                            }   

                            //Loop through each chunk found

                            foreach (var p in strategyTest.myPoints)
                            {

                                //Console.WriteLine(string.Format("Found text {0} at {1}x{2}", p.Text, p.Rect.Left, p.Rect.Bottom));
                                float[] quad = { p.Rect.Left, p.Rect.Bottom, p.Rect.Right, p.Rect.Bottom, p.Rect.Left, p.Rect.Top, p.Rect.Right, p.Rect.Top };

                                Rectangle rect = new Rectangle(p.Rect.Left,
                                                               p.Rect.Top,
                                                               p.Rect.Bottom,
                                                               p.Rect.Right);

                                PdfAnnotation highlight = PdfAnnotation.CreateMarkup(stamper.Writer, rect, null, PdfAnnotation.MARKUP_HIGHLIGHT, quad);

                                //Set the color
                                highlight.Color = BaseColor.YELLOW;

                                //Add the annotation
                                stamper.AddAnnotation(highlight, 1);
                            }
                        }
                    }
                }
                //}


                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                byte[] result = ms.ToArray();
                return File(result, "application/pdf");
            }

            return View("FileUpload");
            //return File(FileById.FileContent, "application/pdf");
        }

        #region Database connection

        private SqlConnection con;
        private string constr;
        private void DbConnection()
        {
            constr = @"Server=Bhagwat;Database=ExcelData;User Id=sa;Password=sa123;";
            con = new SqlConnection(constr);
        }
        #endregion



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
    }
}
