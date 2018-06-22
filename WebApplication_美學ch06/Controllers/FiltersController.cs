using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_美學ch06.Extensions;
using WebApplication_美學ch06.Filters;
using WebApplication_美學ch06.Models;

namespace WebApplication_美學ch06.Controllers
{
    public class FiltersController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        // GET: Filters
        [Mvc5Authv1]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DemoFilePath()
        {
            string path = Server.MapPath(@"~\Content\Site.css");
            return File(path, "text/css");
        }

        //圖片上傳
        public ActionResult UploadToDisk()
        {
            return View();
        }

        //
        // 摘要:
        //     Serves as the base class for classes that provide access to individual files
        //     that have been uploaded by a client.
        [HttpPost]
        public ActionResult UploadToDisk(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    //Combine 結合
                    string path = Path.Combine(Server.MapPath("~/Files/"), fileName);
                    file.SaveAs(path);
                    string message = "Name" + fileName + ",<br>" +
                                    "Content Type:  " + file.ContentType + ",<br>" +
                                     "Size:  " + file.ContentLength + ",<br>" +
                                     "上傳成功。";
                    TempData["Message"] = message;
                }
                else
                {
                    TempData["Message"] = "空白檔案 ?";
                }
            }
            else
            {
                TempData["Message"] = "有選到檔案 ?";
            }
            return RedirectToAction("UploadToDisk");
        }


        //多檔案上傳
        public ActionResult MultiFileUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MultiFileUpload(IEnumerable<HttpPostedFileBase> files)
        {
            string message = null;
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Files/"), fileName);
                    file.SaveAs(path);
                    message += fileName + "  上傳成功。<br>";
                }
            }
            TempData["Message"] = message;
            return View();
        }

        //上傳檔案至資料庫
        public ActionResult UploadToDB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadToDB(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                int length = file.ContentLength;
                byte[] buffer = new byte[length];
                //讀取 Strem 、寫入buffer
                file.InputStream.Read(buffer, 0, length);

                DbFile dbfile = new DbFile()
                {
                    Name = fileName,
                    MimeType = file.ContentType,
                    Size = file.ContentLength,
                    Content = buffer
                };
                try
                {
                    db.DbFiles.Add(dbfile);
                    db.SaveChanges();
                    string message = "Name:  " + fileName + ",<br>" +
                                    "Conten Type:  " + file.ContentType + ",<br>" +
                                    "Size:  " + file.ContentLength + ",<br>" +
                                    "上傳成功。";
                    TempData["Message"] = message;
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "儲存錯誤: " + ex.Message;
                }
            }
            else
            {
                TempData["Message"] = "未選擇或空白檔案。";
            }
            return View();
        }

        //多上傳檔案至資料庫
        public ActionResult MultiFileUploadDB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MultiFileUploadDB(IEnumerable<HttpPostedFileBase> files)
        {
            string message = null;
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    int length = file.ContentLength;
                    byte[] buffer = new byte[length];
                    //讀取 Strem 、寫入buffer
                    file.InputStream.Read(buffer, 0, length);

                    DbFile dbfile = new DbFile()
                    {
                        //圖片資料
                        Name = fileName,
                        MimeType = file.ContentType,
                        Size = file.ContentLength,
                        //圖片實體
                        Content = buffer
                    };
                    try
                    {
                        db.DbFiles.Add(dbfile);
                        db.SaveChanges();
                        message = "Name:  " + fileName + ",<br>" +
                                   "Conten Type:  " + file.ContentType + ",<br>" +
                                   "Size:  " + file.ContentLength + ",<br>" +
                                   "上傳成功。";
                        TempData["Message"] = message;
                    }
                    catch (Exception ex)
                    {
                        TempData["Message"] = "儲存錯誤: " + ex.Message;
                    }
                }
                else
                {
                    TempData["Message"] = "未選擇或空白檔案。";
                }
            }
            return View();
        }

        public ActionResult DemoFileContent(int id)
        {
            var file = db.DbFiles
                       .Where(f => f.Id == id)
                       .SingleOrDefault();
            if (file != null)
            {
                byte[] buffer = file.Content;
                return File(buffer, file.MimeType, file.Name);
            }
            return Content("找不到檔案 !");
        }

        //動態輸出圖片
        public ActionResult GetImage(string image)
        {
            string path = Server.MapPath(@"~\Files\" + image + ".jpg");
            byte[] by;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryReader br = new BinaryReader(fs);
                by = br.ReadBytes((int)fs.Length);
            }
            return File(by, "image/jpeg");
        }

        public ActionResult ShowImages()
        {
            return View();
        }

        //FileStreamResult 
        public ActionResult DemoFileStream(string image)
        {
            string path =Server.MapPath(@"~\Files\" + image + ".jpg");
            FileStream fs = System.IO.File.OpenRead(path);
            return File(fs, "image/jpge");
        }

        public ActionResult StreamImages()
        {
            return View();
        }

        //RazorViewEngine
        public ActionResult DemoActionName()
        {
            ViewBag.Book = "ASP.NET MVC 5";
            // return View();
            return View("DemoActionName2");
        }

        //預設 MasterName
        public ActionResult DemoMaster()
        {
            return View(null, "_Layout2");
        }

        //VideoResult
        public ActionResult DemoVideo()
        {
            // 應由資料庫取得相關資訊
            return new VideoResult("001.mp4", "video/mp4");
        }

        public ActionResult ShowVideo()
        {
            return View();
        }


        [ChildActionOnly]
        public ActionResult ImageTag(string name)
        {
            string filePath = "/Files/" + name + ".jpg";
            string imgTag = "<img src=\"" + filePath + "\" />";
            return Content(imgTag);
        }

        //[RequireHttps]
        public ActionResult Secure()
        {
            return View();
        }
    }
}