using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using X4.PULA.Common;
using X4.PULA.Demo.Infrastructure;

namespace X4.PULA.Demo.Controllers
{
    public class UsersController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "School,Organize,Company")]
        public ActionResult Index()
        {
            if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.School)) return View("SIndex");
            else if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.Organize)) return View("OIndex");
            else return View("CIndex");
        }

        /// <summary>
        /// 活动管理
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Organize")]
        public ActionResult Activities()
        {
            return View();
        }

        /// <summary>
        /// 搜索活动
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Organize")]
        public ActionResult SearchActs(string searchStr)
        {
            return View("Activities");
        }

        /// <summary>
        /// 添加活动
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [X4Authorize(Roles = "Organize")]
        public ActionResult AddActivity()
        {
            return View();
        }

        /// <summary>
        /// 添加活动
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Organize")]
        public ActionResult AddActivity(string model)
        {
            return Content(X4RetHelper.GetRetText("活动已提交校园大使审核!请稍候.", Url.Action("Activities")));
        }

        /// <summary>
        /// 修改组织页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [X4Authorize(Roles = "Organize")]
        public ActionResult EditActivity(int id)
        {
            return View();
        }

        /// <summary>
        /// 修改组织页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Organize")]
        public ActionResult EditActivity(string model)
        {
            return Content(X4RetHelper.GetRetText("修改成功,活动已提交校园大使审核!请稍候.", Url.Action("Activities")));
        }

        /// <summary>
        /// 删除成功
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Organize")]
        public ActionResult DelActivity(int id)
        {
            return Content(X4RetHelper.GetRetText("删除活动成功!", Url.Action("Activities")));
        }

        /// <summary>
        /// 企业活动列表
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Organize")]
        public ActionResult Envents()
        {
            return View();
        }

        /// <summary>
        /// 搜索企业活动
        /// </summary>
        /// <param name="searchStr"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Organize")]
        public ActionResult SearchEnvents(string searchStr)
        {
            return View("Envents");
        }

        /// <summary>
        /// 企业活动详情
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Organize")]
        public ActionResult Envent()
        {
            return View();
        }

        /// <summary>
        /// 活动评价列表
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Organize")]
        public ActionResult OrgActComs()
        {
            return View();
        }

        /// <summary>
        /// 活动评价详情
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [X4Authorize(Roles = "Organize")]
        public ActionResult OrgActCom()
        {
            return View();
        }

        /// <summary>
        /// 处理活动评价
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Organize")]
        public ActionResult OrgActCom(string model)
        {
            return View();
        }

        /// <summary>
        /// 组织信息
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Organize")]
        public ActionResult OrgInfo()
        {
            return View();
        }

        /// <summary>
        /// 公司活动列表
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Company")]
        public ActionResult CpyEnvents()
        {
            return View();
        }

        /// <summary>
        /// 搜索公司活动
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Company")]
        public ActionResult SearchCpyEnvents(string searchStr)
        {
            return View("CpyEnvents");
        }
        
        /// <summary>
        /// 公司活动详情
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Company")]
        public ActionResult CpyEnvent(int id)
        {
            return View();
        }

        /// <summary>
        /// 添加公司活动
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [X4Authorize(Roles = "Company")]
        public ActionResult AddCpyEnvent()
        {
            return View();
        }

        /// <summary>
        /// 添加公司活动
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Company")]
        public ActionResult AddCpyEnvent(string model)
        {
            return Content(X4RetHelper.GetRetText("添加活动成功!", Url.Action("CpyEnvents")));
        }

        /// <summary>
        /// 编辑公司活动
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [X4Authorize(Roles = "Company")]
        public ActionResult EditCpyEnvent(int id)
        {
            return View();
        }

        /// <summary>
        /// 编辑公司活动
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Company")]
        public ActionResult EditCpyEnvent(string model)
        {
            return Content(X4RetHelper.GetRetText("编辑活动成功!", Url.Action("CpyEnvents")));
        }

        /// <summary>
        /// 删除公司活动
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Company")]
        public ActionResult DelCpyEnvent(int id)
        {
            return Content(X4RetHelper.GetRetText("删除活动成功!", Url.Action("CpyEnvents")));
        }

        /// <summary>
        /// 组织活动列表
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Company")]
        public ActionResult Acts()
        {
            return View();
        }

        /// <summary>
        /// 搜索组织活动
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Company")]
        public ActionResult SearchActs()
        {
            return View("Acts");
        }

        /// <summary>
        /// 组织活动详情
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Company")]
        public ActionResult Activity(int id)
        {
            return View();
        }

        /// <summary>
        /// 申请查看
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Company")]
        public ActionResult Apply(int id)
        {
            return Content(X4RetHelper.GetRetText("申请已提交给系统管理员!请稍候.", Url.Action("Activity", new { id = 2 })));
        }

        /// <summary>
        /// 赞助
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Company")]
        public ActionResult Deal(int id)
        {
            return View();
        }

        /// <summary>
        /// 赞助
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Company")]
        public ActionResult Deal(string model)
        {
            return Content(X4RetHelper.GetRetText("赞助成功!", Url.Action("Acts")));
        }

        /// <summary>
        /// 活动评价列表
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Company")]
        public ActionResult CpyActComs()
        {
            return View();
        }

        /// <summary>
        /// 活动评价页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [X4Authorize(Roles = "Company")]
        public ActionResult CpyActCom(int id)
        {
            return View();
        }

        /// <summary>
        /// 处理活动评价
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "Company")]
        public ActionResult CpyActCom(string model)
        {
            return Content(X4RetHelper.GetRetText("评价成功!", Url.Action("CpyActComs")));
        }

        /// <summary>
        /// 企业信息
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "Company")]
        public ActionResult CpyInfo()
        {
            return View();
        }
    }
}