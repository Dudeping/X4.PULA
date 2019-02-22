using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.HttpContext.Response.Write("提前返回!" + Url.Action("About", "Home", new { ReturnUrl = Request.Url.PathAndQuery }));
            filterContext.HttpContext.Response.End();
            filterContext.HttpContext.Response.Write("提前返回!");
            filterContext.HttpContext.Response.End();
            return;
        }
    }
}