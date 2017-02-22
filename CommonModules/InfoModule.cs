using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CommonModules
{
    public class InfoModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.EndRequest += HandleEvent;
        } // end of Init
        public void HandleEvent(object src, EventArgs args)
        {
            HttpContext ctx = HttpContext.Current;

            if (ctx.CurrentNotification == RequestNotification.EndRequest)
            {
                ctx.Response.Write(string.Format(
                "<div class='alert alert-success'>URL: {0} Status: {1}</div>",
                ctx.Request.RawUrl, ctx.Response.StatusCode));

            }

        } // end of method
      }
    }
