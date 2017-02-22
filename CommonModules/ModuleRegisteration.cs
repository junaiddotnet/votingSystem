using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(CommonModules.ModuleRegisteration),
"RegisterModule")]

namespace CommonModules
{
    public class ModuleRegisteration
    {
        public static void RegisterModule()
        {
            HttpApplication.RegisterModule(typeof(CommonModules.InfoModule));
        }
    }
}
