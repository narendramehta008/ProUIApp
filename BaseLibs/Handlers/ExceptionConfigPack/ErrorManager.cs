using BaseLibs.Handlers.LoggerConfigPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.Handlers.ExceptionConfigPack
{
   public static class ErrorManager
    {
        public static void ErrorLog(this Exception exception,string message=null)
        {
            try
            {
                if (message == null)
                    message = string.Empty;
                Logger.Log.Error($"{message} {exception.ToString()}");
            }
            catch(Exception ex)
            {
            }
        }

    }
}
