using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace votingSystem.Infastructure
{
    public class DayModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PostMapRequestHandler += (src, args) =>
            {
                if (context.Context.Handler is DayOfWeekHandler)
                {
                    context.Context.Items["DayModule_Time"] = DateTime.Now;

                }
            };
        }
    }
}