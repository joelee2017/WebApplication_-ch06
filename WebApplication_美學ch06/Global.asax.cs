using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication_美學ch06
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //調整 ViewEngine 順序
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            ViewEngines.Engines.Add(new WebFormViewEngine);

            //加上 String-->Decimal 的轉換函數
            ModelBinders.Binders.Add(
                typeof(decimal),
                new FlexModelBinder(
                    s => Convert.ToDecimal(s, CultureInfo.CurrentCulture)));
        }
    }

    public class FlexModelBinder : IModelBinder
    {
        // 將轉換核心抽出來變成 Func<string, object> 當成初始化數
        // 傳入不同轉換函數，就可以變成不同型別的 ModelBinder 
        private Func<object, decimal> _convFn = null;
        public FlexModelBinder(Func<object, decimal> convFunc)
        {
            _convFn = convFunc;
        }

        //實作 IModelBinder 介面
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //ValueProviderResult
            //表示將值 (例如從表單張貼或查詢字串) 繫結至動作方法引數屬性或繫結至引數本身的結果

            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);
            ModelState modelState = new ModelState { Value = valueResult };
            object actualvalue = null;
            try
            {
                //valueResul: 取得或設定轉換為顯示字串之未經處理的值。
                //_convFn 委派:進行轉換
                actualvalue = _convFn(valueResult.AttemptedValue);
            }
            catch(FormatException e)
            {
                modelState.Errors.Add(e);
            }

            bindingContext.ModelState.Add(bindingContext.ModelName, modelState);
            return actualvalue;
        }
    }
}
