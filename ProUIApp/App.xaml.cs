using BaseLibs.Handlers.ExceptionConfigPack;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProUIApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                var appender = (log4net.Appender.FileAppender)LogManager.GetRepository().GetAppenders()[0];
                appender.File = @"C:\whatever.log";
                appender.ActivateOptions();
            }
            catch(Exception ex)
            {
                ex.ErrorLog();
            }
        }
    }
}
