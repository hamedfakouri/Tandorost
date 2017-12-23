using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketing.Interface.WebUI.Models;

namespace Ticketing.Interface.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: MainPage
        public ActionResult Index()
        {
            var res=new IndexViewModel();
            return View(new IndexViewModel());
        }
        public JsonResult Config()
        {
            var res = new IndexViewModel().ServiceHostUrl;
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}