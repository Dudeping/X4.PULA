using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X4.PULA.Common;
using X4.PULA.Demo.Infrastructure;

namespace X4.PULA.Demo.Controllers
{
    // TODO:校园大使和系统管理员同时使用此控制器所以有的地方需要校验操作者所在角色，来保证数据安全
    public class AdminController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "CampusAdmin,SysAdmin")]
        public ActionResult Index()
        {
            if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.CampusAdmin))
                return View("CIndex");
            return View("SIndex");
        }

        /// <summary>
        /// 学校列表
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "CampusAdmin,SysAdmin")]
        public ActionResult Schools()
        {
            return View();
        }

        /// <summary>
        /// 搜索学校组织
        /// </summary>
        /// <param name="searchStr"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "CampusAdmin,SysAdmin")]
        public ActionResult SearchSchs(string searchStr)
        {
            return View("Schools");
        }

        /// <summary>
        /// 学校详情
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "CampusAdmin,SysAdmin")]
        public ActionResult School(int id)
        {
            return View();
        }

        /// <summary>
        /// 添加学校页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult AddSchool()
        {
            return View();
        }

        /// <summary>
        /// 处理添加学校
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult AddSchool(string model)
        {
            return Content(X4RetHelper.GetRetText("学校信息已提交给系统管理员审核!请稍候.", Url.Action("Schools")));
        }

        /// <summary>
        /// 学校的所有组织
        /// </summary>
        /// <param name="schoolId">学校Id</param>
        /// <returns></returns>
        [X4Authorize(Roles = "CampusAdmin,SysAdmin,School")]
        public ActionResult Organizes(int id)
        {
            if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.School)) return View("Organizes", "_LayoutUsers");
            return View();
        }

        /// <summary>
        /// 搜索组织
        /// </summary>
        /// <param name="searchStr"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "CampusAdmin,SysAdmin,School")]
        public ActionResult SearchOrgs(string searchStr)
        {
            if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.School)) return View("Organizes", "_LayoutUsers");
            return View("Organizes");
        }

        /// <summary>
        /// 组织详情
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        [X4Authorize(Roles = "CampusAdmin,SysAdmin,School")]
        public ActionResult Organize(int id)
        {
            if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.School)) return View("Organize", "_LayoutUsers");
            return View();
        }

        /// <summary>
        /// 组织的所有活动
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        [X4Authorize(Roles = "CampusAdmin,SysAdmin,School")]
        public ActionResult Activities(int id)
        {
            if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.School)) return View("Activities", "_LayoutUsers");
            return View();
        }

        /// <summary>
        /// 搜索活动
        /// </summary>
        /// <param name="searchStr"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "CampusAdmin,SysAdmin,School")]
        public ActionResult SearchActs(string searchStr)
        {
            if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.School)) return View("SearchActs", "_LayoutUsers");
            return View("Activities");
        }

        /// <summary>
        /// 活动详情
        /// </summary>
        /// <param name="actId"></param>
        /// <returns></returns>
        [X4Authorize]
        public ActionResult Activity(int id)
        {
            if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.School) || X4Env.LoginInfo.IsInRole(X4Env.X4Roles.Company)|| X4Env.LoginInfo.IsInRole(X4Env.X4Roles.Organize)) return View("Activity", "_LayoutUsers");
            return View();
        }

        /// <summary>
        /// 待审核组织列表
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult AuditOrgs()
        {
            return View();
        }

        /// <summary>
        /// 审核组织详情
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult AuditOrganize(int id)
        {
            return View();
        }

        /// <summary>
        /// 组织通过审核
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult OrgAuditPass(int id)
        {
            return Content(X4RetHelper.GetRetText("审核成功!已提交系统管理员确认.", Url.Action("AuditOrgs")));
        }

        /// <summary>
        /// 组织不通过审核
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult OrgAuditNotPass(int id, string reason)
        {
            return Content(X4RetHelper.GetRetText("标记通过成功!已返回给组织创建者.", Url.Action("AuditOrgs")));
        }

        /// <summary>
        /// 待审核活动列表
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult AuditActs()
        {
            return View();
        }

        /// <summary>
        /// 审核活动详情
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult AuditActivity(int id)
        {
            return View();
        }

        /// <summary>
        /// 活动通过审核
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult ActAuditPass(int id)
        {
            return Content(X4RetHelper.GetRetText("审核成功!活动已发布.", Url.Action("AuditActs")));
        }

        /// <summary>
        /// 活动不通过审核
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult ActAuditNotPass(int id, string reason)
        {
            return Content(X4RetHelper.GetRetText("标记通过成功!已返回给该组织.", Url.Action("AuditActs")));
        }

        /// <summary>
        /// 没有提交资料的活动
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult NoSubmitActs()
        {
            return View();
        }

        /// <summary>
        /// 显示提交资料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult SubmitSrc(int id)
        {
            return View();
        }

        /// <summary>
        /// 处理提交资料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "CampusAdmin")]
        public ActionResult SubmitSrc(string model)
        {
            return Content(X4RetHelper.GetRetText("活动资料保存成功", Url.Action("NoSubmitActs")));
        }

        /// <summary>
        /// 管理校园大使
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult CampusAdmins()
        {
            return View();
        }

        /// <summary>
        /// 搜索校园大使
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult SearchCampuesAdmin(string searchStr)
        {
            return View("CampusAdmins");
        }

        /// <summary>
        /// 添加校园大使页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult AddCampusAdmin()
        {
            return View();
        }

        /// <summary>
        /// 处理添加校园大使
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult AddCampusAdmin(string model)
        {
            return Content(X4RetHelper.GetRetText("添加校园大使成功!", Url.Action("CampusAdmins")));
        }

        /// <summary>
        /// 删除校园大使
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult DelCampusAdmin(int id)
        {
            return Content(X4RetHelper.GetRetText("删除校园大使成功!", Url.Action("CampusAdmins")));
        }

        /// <summary>
        /// 审核学校列表
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult AuditSchs()
        {
            return View();
        }

        /// <summary>
        /// 审核学校
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult AuditSchool(int id)
        {
            return View();
        }

        /// <summary>
        /// 学校审核通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult SchAuditPass(int id)
        {
            return Content(X4RetHelper.GetRetText("审核成功!学校已建立.", Url.Action("AuditSchs", "Admin")));
        }

        /// <summary>
        /// 学校审核不通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult SchAuditNotPass(int id, string reason)
        {
            return Content(X4RetHelper.GetRetText("标记不通过成功!已返回给提交者.", Url.Action("AuditSchs", "Admin")));
        }

        /// <summary>
        /// 审核企业列表
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult AuditCpys()
        {
            return View();
        }

        /// <summary>
        /// 审核企业
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult AuditCompany(int id)
        {
            return View();
        }

        /// <summary>
        /// 企业审核通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult CpyAuditPass(int id)
        {
            return Content(X4RetHelper.GetRetText("审核成功!企业已建立.", Url.Action("AuditCpys", "Admin")));
        }

        /// <summary>
        /// 企业审核不通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult CpyAuditNotPass(int id, string reason)
        {
            return Content(X4RetHelper.GetRetText("标记不通过成功!已返回给提交者.", Url.Action("AuditCpys", "Admin")));
        }

        /// <summary>
        /// 确认组织列表
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult ComfirmOrgs()
        {
            return View();
        }

        /// <summary>
        /// 确认组织详情页面
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult ComfirmOrganize(int id)
        {
            return View();
        }

        /// <summary>
        /// 组织确认核通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult CpyComfirmPass(int id)
        {
            return Content(X4RetHelper.GetRetText("确认成功!组织已建立.", Url.Action("ComfirmOrgs", "Admin")));
        }

        /// <summary>
        /// 组织确认不通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult CpyComfirmNotPass(int id, string reason)
        {
            return Content(X4RetHelper.GetRetText("标记不通过成功!已返回给提交者.", Url.Action("ComfirmOrgs", "Admin")));
        }

        /// <summary>
        /// 申请查看列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult AuditShows()
        {
            return View();
        }

        /// <summary>
        /// 申请查看详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult AuditShow(int id)
        {
            return View();
        }

        /// <summary>
        /// 申请审核通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult ShowAuditPass(int id)
        {
            return Content(X4RetHelper.GetRetText("审核成功!已对该企业开放该活动的查看权限.", Url.Action("AuditShows", "Admin")));
        }

        /// <summary>
        /// 申请审核不通过
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult ShowAuditNotPass(int id)
        {
            return Content(X4RetHelper.GetRetText("标记不通过成功!已将消息返回给企业.", Url.Action("AuditShows", "Admin")));
        }

        /// <summary>
        /// 管理企业
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult Companies()
        {
            return View();
        }

        /// <summary>
        /// 搜索企业
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult SearchCmp(string searchStr)
        {
            return View("Companies");
        }

        /// <summary>
        /// 企业详情
        /// </summary>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult Company(int id)
        {
            return View();
        }

        /// <summary>
        /// 企业的所有活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult Envents(int id)
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
        [X4Authorize(Roles = "SysAdmin")]
        public ActionResult SearchEvts(string searchStr)
        {
            return View("Envents");
        }

        /// <summary>
        /// 活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [X4Authorize(Roles = "SysAdmin,Company")]
        public ActionResult Envent(int id)
        {
            if (X4Env.LoginInfo.IsInRole(X4Env.X4Roles.Company)) return View("Envent", "_LayoutUsers");
            return View();
        }
    }
}