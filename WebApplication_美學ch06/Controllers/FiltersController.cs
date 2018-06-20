using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_美學ch06.Controllers
{
    public class FiltersController : Controller
    {
        // GET: Filters
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
            if(file != null)
            {
                if(file.ContentLength > 0)
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
    }
}