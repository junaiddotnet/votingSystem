using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace votingSystem.Infastructure
{
    public class TotalTimeModule : IHttpModule
    {
        public int a = 0;
        private static float totalTime = 0;
        private static float requestCount = 0;
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            IHttpModule module = context.Modules["Timer"];
            if (module != null && module is TimerModule)
            {
                TimerModule timerModule = (TimerModule)module;
                timerModule.RequestedTime += (src, args) => {
                    totalTime += args.Duration;
                    requestCount++;
                };
            }
            context.EndRequest += (src, args) => {
                context.Context.Response.Write(CreateSummary());
            };
        } // end of method
        private string CreateSummary()
        {
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWriter = new HtmlTextWriter(stringWriter);
            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Class,
            "table table-bordered");
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Table);
            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Class, "success");
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
            htmlWriter.Write("Requests");
            htmlWriter.RenderEndTag();
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
            htmlWriter.Write(requestCount);
            htmlWriter.RenderEndTag();
            htmlWriter.RenderEndTag();
            htmlWriter.AddAttribute(HtmlTextWriterAttribute.Class, "success");
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Tr);
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
            htmlWriter.Write("Total Time");
            htmlWriter.RenderEndTag();
            htmlWriter.RenderBeginTag(HtmlTextWriterTag.Td);
            htmlWriter.Write("{0:F5} seconds", totalTime);
            htmlWriter.RenderEndTag();
            htmlWriter.RenderEndTag();
            htmlWriter.RenderEndTag();
            return stringWriter.ToString();
        }
    }
}