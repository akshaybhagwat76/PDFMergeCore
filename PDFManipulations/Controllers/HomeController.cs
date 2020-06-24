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

            String FileExt = Path.GetExtension(files.FileName).ToUpper();

            if (FileExt == ".PDF")
            {
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

                        iTextSharp.text.pdf.PdfReader awatemarkreader = new iTextSharp.text.pdf.PdfReader(watemarkedbytes, password);

                        PdfEncryptor.Encrypt(awatemarkreader, outputData, true, "123456", "123456", PdfWriter.ALLOW_MODIFY_CONTENTS);

                        bytes = outputData.ToArray();

                        FileDetailsModel Fd = new Models.FileDetailsModel();
                        Fd.FileName = files.FileName;
                        Fd.FileContent = bytes;
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
            // return View();

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
            List<FileDetailsModel> DetList = new List<FileDetailsModel>();

            DbConnection();
            con.Open();
            DetList = SqlMapper.Query<FileDetailsModel>(con, "GetFileDetails", commandType: CommandType.StoredProcedure).ToList();
            con.Close();
            return DetList;
        }

        #endregion

        #region Database related operations
        private void SaveFileDetails(FileDetailsModel objDet)
        {

            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@FileName", objDet.FileName);
            Parm.Add("@FileContent", objDet.FileContent);
            DbConnection();
            con.Open();
            con.Execute("AddFileDetails", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();


        }
        #endregion

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
