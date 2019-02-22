using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;
using X4.PULA.Common;
using X4.PULA.Common.Cache;

namespace X4.PULA.Demo.Infrastructure
{
    public class X4AuthorizeAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 允许访问的用户，多个用户用","分割
        /// </summary>
        public string UserNames { get; set; }

        /// <summary>
        /// 允许访问的角色，多个角色用","分割
        /// </summary>
        public string Roles { get; set; }

        /// <summary>
        /// Url 帮助类
        /// </summary>
        private UrlHelper Url { get; set; } = new UrlHelper(HttpContext.Current.Request.RequestContext, RouteTable.Routes);

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            // 判断用户是否登录
            if (!X4Env.LoginInfo.IsLogin)
            {
                filterContext.HttpContext.Response.Write(X4RetHelper.GetRetText("登录过期!请重新登录.", Url.Action("Login", "Account", new { ReturnUrl = filterContext.HttpContext.Request.Url.PathAndQuery })));
                filterContext.HttpContext.Response.End();
            }
            // 判断 用户是否为限定用户 和 角色是否为限定角色
            if (!X4Env.LoginInfo.IsLogin || (UserNames != null && !UserNames.Split(',').Any(u => u == X4Env.LoginInfo.UserName)) || (Roles != null && !Roles.Split(',').Any(r => r == X4Env.LoginInfo.RoleName)))
            {
                filterContext.HttpContext.Response.Write(X4RetHelper.GetRetText("权限不足!请重新登录.", Url.Action("Login", "Account", new { ReturnUrl = filterContext.HttpContext.Request.Url.PathAndQuery })));
                filterContext.HttpContext.Response.End();
            }
        }
    }
}