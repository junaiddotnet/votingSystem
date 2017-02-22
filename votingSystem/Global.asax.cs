using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace votingSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            //BeginRequest += (src, args) => RecordEvent("BeginRequestss");
            BeginRequest += RecordEvent;
            AuthenticateRequest += RecordEvent;
            PostAuthenticateRequest += RecordEvent;
            MapRequestHandler += RecordEvent;
            PostAcquireRequestState += (src, args) => CreateTimeStamp();
        }
        private void CreateTimeStamp()
        {
            string stamp = Context.Timestamp.ToLongTimeString();
            if (Context.Session != null)
            {
                Session["request_timestamp"] = stamp;
            }
            else
            {
                Application["app_timestamp"] = stamp;
            }
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CreateTimeStamp();
        }
        //protected void Application_BeginRequest()
        //{
        //    RecordEvent("BegingRequest");
        //}
        protected void Application_AuthenticateRequest()
        {
            //RecordEvent("AuthenticateRequest");
        }
        protected void Application_PostAuthenticateRequest()
        {
            //RecordEvent("PostAuthenticateRequest");
        }
        //private void RecordEvent(string name)
        //{
        //    List<string> eventList = Application["events"] as List<string>;
        //    if (eventList == null)
        //    {
        //        Application["events"] = eventList = new List<string>();
        //    }
        //    eventList.Add(name);
        //}
        private void RecordEvent(object src,EventArgs args)
        {
            
            List<string> eventList = Application["events"] as List<string>;
            if (eventList == null)
            {
                Application["events"] = eventList = new List<string>();
            }
            string name = Context.CurrentNotification.ToString();
            if (Context.IsPostNotification)
            {
                name = "Post" + name;
            }
            eventList.Add(name);
        }
        protected void Application_End()
        {

        }
    }
}
