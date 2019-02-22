using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using X4.PULA.Common;
using X4.PULA.Common.Cache;
using X4.PULA.Demo.Infrastructure;
using X4.PULA.Demo.Models;

namespace X4.PULA.Demo.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <param name="ReturnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        /// <summary>
        /// 处理登录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="ReturnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                // 超级管理员(superadmin)、系统管理员(x4s0001)、校园大使(x4c0001)、学校(x4e0001)、学生组织(x4t0001)、企业(x4b0001)
                var x4login = new string[] { "p", "s", "c", "e", "t", "b" };
                var identity = model.Account.Substring(2, 1).ToLower();
                if (model.Password == "123456" && x4login.Where(x => x.ToLower() == identity).Any())
                {
                    var role =
                        identity == "p" ? X4Env.X4Roles.SuperAdmin :
                        identity == "s" ? X4Env.X4Roles.SysAdmin :
                        identity == "c" ? X4Env.X4Roles.CampusAdmin :
                        identity == "e" ? X4Env.X4Roles.School :
                        identity == "t" ? X4Env.X4Roles.Organize :
                        X4Env.X4Roles.Company;

                    var roleName =
                        identity == "p" ? "超级管理员" :
                        identity == "s" ? "系统管理员" :
                        identity == "c" ? "校园大使" :
                        identity == "e" ? "学校" :
                        identity == "t" ? "学生组织" :
                        "企业";

                    var key = Guid.NewGuid().ToString().Replace("-", "");
                    X4CacheHelper.AddCache(key, new LoginInfo { Account = model.Account, RoleName = role, RoleDescript = roleName, IsLogin = true }, DateTime.Now.AddMinutes(30));
                    Response.Cookies.Add(new HttpCookie(X4Env.LoginCookieName, key) { Expires = DateTime.Now.AddMinutes(30), HttpOnly = true });
                    if (!string.IsNullOrWhiteSpace(ReturnUrl) && Url.IsLocalUrl(ReturnUrl)) return Redirect(ReturnUrl);

                    return RedirectToAction("X4LoginRedirect");
                }
                ModelState.AddModelError("", "用户名或密码错误!");
            }
            return View();
        }

        /// <summary>
        /// 跳转
        /// </summary>
        /// <returns></returns>
        [X4Authorize]
        public ActionResult X4LoginRedirect()
        {
            if (X4Env.LoginInfo.IsLogin)
            {
                // 超级管理员
                if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.SuperAdmin)) return RedirectToAction("Index", "SuperAdmin");
                // 系统管理员、校园大使
                if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.CampusAdmin) || X4Env.LoginInfo.IsInRole(X4Env.X4Roles.SysAdmin)) return RedirectToAction("Index", "Admin");
                // 企业、学校、学校组织
                return RedirectToAction("Index", "Users");
            }
            return Content(X4RetHelper.GetRetText("登录过期！请重新登录.", Url.Action("Login", "Account")));
        }

        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 处理注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string type)
        {
            return ModelState.IsValid ? Content(X4RetHelper.GetRetText($"注册信息已提交{(type == "org" ? "校园大使" : "系统管理员")}审核!请稍等.", Url.Action("Index", "Home"))) : View() as ActionResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            // 获取 Cookie
            var cookie = Request.Cookies[X4Env.LoginCookieName];
            if (cookie == null) return Redirect("/");
            // 获取 Cookie 中存储的登录信息 Key
            var key = cookie.Value;
            if (string.IsNullOrWhiteSpace(key)) return Redirect("/");
            // 清除
            X4CacheHelper.Delete(key);
            Response.Cookies.Remove(cookie.Name);
            return Redirect("/");
        }

        /// <summary>
        /// 更改密码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [X4Authorize]
        public ActionResult ResetPassword()
        {
            return View();
        }

        /// <summary>
        /// 处理更改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [X4Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPassword model)
        {
            return Content(X4RetHelper.GetRetText("修改密码成功!", Url.Action("Index")));
        }
    }
}