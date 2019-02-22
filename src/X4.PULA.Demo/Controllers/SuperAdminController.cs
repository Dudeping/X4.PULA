using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X4.PULA.Demo.Infrastructure;
using X4.PULA.Demo.Models;

namespace X4.PULA.Demo.Controllers
{
    [X4Authorize(Roles = "SuperAdmin")]
    public class SuperAdminController : Controller
    {
        /// <summary>
        /// 超级管理员首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 系统管理员列表
        /// </summary>
        /// <returns></returns>
        public ActionResult SysAdminList()
        {
            return View();
        }

        /// <summary>
        /// 添加系统管理员页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddSysAdmin()
        {
            return View();
        }

        /// <summary>
        /// 处理添加系统管理员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSysAdmin(string model)
        {
            return Content(X4RetHelper.GetRetText("添加系统管理员成功!", Url.Action("SysAdminList")));
        }

        /// <summary>
        /// 删除系统管理员
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DelSysAdmin(int id)
        {
            return Content(X4RetHelper.GetRetText("删除系统管理员成功!", Url.Action("SysAdminList")));
        }

        /// <summary>
        /// 系统日志
        /// </summary>
        /// <returns></returns>
        public ActionResult Logs()
        {
            return View();
        }

        /// <summary>
        /// 系统公告列表
        /// </summary>
        /// <returns></returns>
        public ActionResult SysNewsList()
        {
            return View();
        }

        /// <summary>
        /// 添加系统公告页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddSysNews()
        {
            return View();
        }

        /// <summary>
        /// 处理添加系统公告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSysNews(string model)
        {
            return Content(X4RetHelper.GetRetText("添加系统公告成功!", Url.Action("SysNewsList")));
        }

        /// <summary>
        /// 删除系统公告
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DelSysNews(int id)
        {
            return Content(X4RetHelper.GetRetText("删除该公告成功!", Url.Action("SysNewsList")));
        }

        /// <summary>
        /// 编辑网站配置页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditWebConfig()
        {
            return View();
        }

        /// <summary>
        /// 处理编辑网站配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditWebConfig(string model)
        {
            return Content(X4RetHelper.GetRetText("修改网站配置成功", Url.Action("EditWebConfig")));
        }
    }
}