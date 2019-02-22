using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X4.PULA.Common;
using X4.PULA.Demo.Infrastructure;

namespace X4.PULA.Demo.Controllers
{
    public class LogsController : Controller
    {
        [X4Authorize]
        public ActionResult Index()
        {
            return View("Index", X4Env.LoginInfo.IsInRole(X4Env.X4Roles.CampusAdmin) || X4Env.LoginInfo.IsInRole(X4Env.X4Roles.SysAdmin) ? "_LayoutCASAdmin" : "_LayoutUsers");
        }
    }
}