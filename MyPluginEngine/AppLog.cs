using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//开启log4net监听器
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace MyPluginEngine
{
    /// <summary>
    /// 使用Log4net插件的log日志对象
    /// </summary>
    public class AppLog
    {
        /// <summary>
        /// ILog4net日志静态类对象
        /// </summary>
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("LKGIS");
    }
}
