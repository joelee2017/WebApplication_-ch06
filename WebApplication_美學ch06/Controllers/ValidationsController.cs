using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_美學ch06.Models;

namespace WebApplication_美學ch06.Controllers
{
    public class ValidationsController : Controller
    {
        // GET: Validations/Price 讓用戶端進行 AJAX 呼叫，並回傳一個JSON結果。將設計好的Controller 套用至 Remote 屬性上
        public ActionResult Price([Bind(Include ="UnitPrice")]Product product)
        {
            string message = null;
            if(product.UnitPrice.HasValue)
            {
                // min: 應該由資料庫或組態檔取得
                const decimal min = 10;

                if(product.UnitPrice < min)
                {
                    message = "價格低於系統限制。";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }                
            }
            else
            {
                message = "誤錯。";
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}