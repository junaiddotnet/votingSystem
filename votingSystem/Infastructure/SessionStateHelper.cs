using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace votingSystem.Infastructure
{
    public static class SessionStateHelper
    {
        public enum SessionStateKeys
        {
            NAME
        }
        public static object Get(SessionStateKeys key)
        {
            string keyString = Enum.GetName(typeof(SessionStateKeys), key);
            return HttpContext.Current.Session[keyString];
        }
        public static object Set(SessionStateKeys key,object Value)
        {
            string keyString = Enum.GetName(typeof(SessionStateKeys), key);
            return HttpContext.Current.Session[keyString]=Value;
        }
    }
}