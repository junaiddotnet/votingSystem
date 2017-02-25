using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using votingSystem.Infastructure;

namespace votingSystem.Controllers
{
    public class ConfigController : Controller
    {
        // GET: Config
        public ActionResult Index() 
        {
            Dictionary<string, object> configData = new Dictionary<string, object>();
            configData.Add("Counter", appStateHelper.Get(AppStateKeys.COUNTER,0));
            //foreach (string key in WebConfigurationManager.AppSettings)
            //{
             
            //    configData.Add(key, WebConfigurationManager.AppSettings[key]);

            //}

            return View(configData);
        }
        public ActionResult Increment()
        {
            int currentValue = (int)appStateHelper.Get(AppStateKeys.COUNTER, 0);
            appStateHelper.Set(AppStateKeys.COUNTER, currentValue + 1);
            return RedirectToAction("Index");
        }
    }
}