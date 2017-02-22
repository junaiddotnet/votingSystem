using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace votingSystem.Infastructure
{
    public class DayOfWeekHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;      
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.Items.Contains("DayModule_Time") && context.Items["DayModule_Time"] is DateTime)
            {

            
            string day = DateTime.Now.DayOfWeek.ToString();
            if (context.Request.CurrentExecutionFilePathExtension == ".json")
            {
                context.Response.ContentType = "application/json";
                context.Response.Write(string.Format("{{\"day\": \"{0}\"}}", day));
            }
            else
            {
                context.Response.ContentType = "text/html";
                context.Response.Write(string.Format("<span>It is: {0}</span>", day));
            }
        } // end of main iff
            else
            {
                context.Response.ContentType = "text/html";
                context.Response.Write("No Module Data Available");
            }
        }
    }
}