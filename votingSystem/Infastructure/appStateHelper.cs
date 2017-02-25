using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace votingSystem.Infastructure
{
    public enum AppStateKeys
    {
        COUNTER
    };
    public static class appStateHelper
    {
        public static Object Get(AppStateKeys key,object defaultValue=null)
        {
            string keyString = Enum.GetName(typeof(AppStateKeys), key);
            if (HttpContext.Current.Application[keyString]==null && defaultValue!=null)
            {
                HttpContext.Current.Application[keyString] = defaultValue;
            }
            return HttpContext.Current.Application[keyString];

        } // End of Get Method
        public static object Set(AppStateKeys key,object value)

        {
            return HttpContext.Current.Application[Enum.GetName(typeof(AppStateKeys),key)] = value;
        }
    }
}