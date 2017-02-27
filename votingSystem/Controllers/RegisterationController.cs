using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using votingSystem.Infastructure;
using static votingSystem.Infastructure.SessionStateHelper;

namespace votingSystem.Controllers
{
    public class RegisterationController : Controller
    {
        // GET: Registeration
        public ActionResult Index()
        {
            SessionStateHelper.Set(SessionStateKeys.NAME, "juaid mahmood");
            ViewBag.name = SessionStateHelper.Get(SessionStateKeys.NAME);
            return View(); 
        }
        public ActionResult show ()
        {
            ViewBag.name = SessionStateHelper.Get(SessionStateKeys.NAME);
            
            return View();
        }
        public ActionResult destroy ()
        {
            Session.Abandon();
            return RedirectToAction("show");
        }
    }
}