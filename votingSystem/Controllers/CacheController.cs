using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace votingSystem.Controllers
{
    public class CacheController : Controller
    {
        // GET: Cache
        public ActionResult Index()
        {
            return View((long?)HttpContext.Cache["PageLength"]);
        }
        [HttpPost]
        public async Task<ActionResult> PopulateData()
        {
            HttpResponseMessage result = await new HttpClient().GetAsync("http://apress.com");
            long? data = result.Content.Headers.ContentLength;
            DateTime dateExpirt = DateTime.Now.AddSeconds(30);
            HttpContext.Cache.Insert("PageLength",data, null, dateExpirt,Cache.NoSlidingExpiration);
           // HttpContext.Cache["PageLength"] = result.Content.Headers.ContentLength;
            return RedirectToAction("Index");
        }
    }
}