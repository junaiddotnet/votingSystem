using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace votingSystem.Controllers
{
    public class RegisterationController : Controller
    {
        // GET: Registeration
        public ActionResult Index()
        {
            ControllerContext.HttpContext.Session["name"] = "junaid Mahmood";
            
            return View();
        }
        public ActionResult show ()
        {
            string name = ControllerContext.HttpContext.Session["name"].ToString();
            return View("show",name);
        }
    }
}