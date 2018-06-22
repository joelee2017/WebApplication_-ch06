using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace WebApplication_美學ch06.Filters
{
    public class Mvc5Authv2Attribute : ActionFilterAttribute, IAuthenticationFilter, IOverrideFilter
    {
        // InvokeAuthentication 的方法  Filters 在這會觸發
        // 未登入角色或角色不符將回傳 HttpUnauthorizedResult 狀態並重新導向登入頁面
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //展示用：角色不應該寫死，應該由當下context 取得
            filterContext.Principal = new GenericPrincipal(
                                            filterContext.HttpContext.User.Identity, 
                                            new[] { "Admin" }
                                            );
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            // public virtual IPrincipal User { get; set; }
            // 傳回：包含目前 HTTP 要求之安全性資訊的物件。
            // IsInRole 在角色中
            var user = filterContext.HttpContext.User;
            if((user == null) || (!user.Identity.IsAuthenticated && !user.IsInRole("Admin")))
            {
                //HttpUnauthorizedResult    Http未經授權的結果
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public Type FiltersToOverride
        {
            get { return typeof(IAuthenticationFilter); }
        }
    }
}