using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace votingSystem.Infastructure
{
    public class RequestTimerEventArgs:EventArgs
    {
        public float Duration { get; set; }
    }
    public class TimerModule : IHttpModule
    {
        public event EventHandler<RequestTimerEventArgs> RequestedTime;
        private Stopwatch timer;
        private static int count = 0;
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += HandleEvent;
            context.EndRequest += HandleEvent;
        }
        public void HandleEvent (object src,EventArgs args)
        {
            HttpContext cx = HttpContext.Current;
            
             if (cx.CurrentNotification==RequestNotification.BeginRequest)
            {
                timer = Stopwatch.StartNew();
                count++;
            }

            else
            {
                float duration = ((float)timer.ElapsedTicks) / Stopwatch.Frequency;
                cx.Response.Write(string.Format(
                "<div class='alert alert-success'>Elapsed: {0:F5} seconds</div>",
                duration));

                cx.Response.Write(string.Format(
               "<div class='alert alert-success'>Elapsed: {0} seconds</div>",
               count));

                if (RequestedTime != null)
                {
                    RequestedTime(this,
                    new RequestTimerEventArgs { Duration = duration });
                }
            }
             if (cx.CurrentNotification==RequestNotification.EndRequest)
            {
                cx.Response.Write(count);
            }
        }
    }
}