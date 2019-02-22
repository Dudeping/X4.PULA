using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using X4.PULA.Common;
using X4.PULA.Common.Cache;

namespace X4.PULA.Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public MvcApplication()
        {
            BeginRequest += MvcApplication_BeginRequest;
        }

        private void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            // 获取登录信息
            if (Request.Cookies[X4Env.LoginCookieName] is HttpCookie cookie && cookie != null && cookie.Value is string key && key != null)
            {
                if (X4CacheHelper.GetCache<LoginInfo>(key) is LoginInfo loginInfo && loginInfo != null)
                {
                    // 存储 Items, 在管道中传递
                    HttpContext.Current.Items.Add(X4Env.LoginInfoKey, loginInfo);

                    // 滑动窗口
                    cookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Set(cookie);
                    X4CacheHelper.SetCache(key, loginInfo, DateTime.Now.AddMinutes(30));
                    return;
                }
            }
            HttpContext.Current.Items.Add(X4Env.LoginInfoKey, new LoginInfo()); // 未登录
        }
    }
}
