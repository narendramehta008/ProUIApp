using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.Handlers.LoggerConfigPack
{
    public delegate void InfoLogger(string message);
   public class Logger
    {
        public static InfoLogger InfoLogger;
        private static readonly ILog _log;

        static Logger()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
        public static class Log
        {
            public static void Info(string message)
            {
                try
                {
                    InfoLogger(message);
                }
                catch(Exception ex)
                {
                }
            }

            public static void Error(string message)
            {
                try
                {
                    _log.Error(message);
                }
                catch(Exception ex)
                {

                }
            }
        }
    }
}
