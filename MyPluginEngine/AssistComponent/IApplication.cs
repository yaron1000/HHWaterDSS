using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;

// 暂时先用window本身窗体控件，后面会替换成第三方控件
using System.Windows.Forms;

/**
 * author lk 
 * 2014/12/20
 * 插件式gis应用框架的设计与实现
 * 宿主程序 1 IApplication接口的实现
 * 
 * */

namespace MyPluginEngine
{
    /// <summary>
    /// IApplication接口定义了宿主程序的属性
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// 主程序标题
        /// </summary>
        string Caption { get; set; }
        /// <summary>
        /// 主程序当前使用的工具Tool名称
        /// </summary>
        string CurrentTool { get; set; }
        /// <summary>
        /// 主程序存储GIS数据的数据集
        /// </summary>
        DataSet MainDataSet { get; set; }
        /// <summary>
        /// 主程序包含的文档对象
        /// </summary>
        IMapDocument Document { get; set; }
        /// <summary>
        /// 主程序中的MapControl控件
        /// </summary>
        IMapControlDefault MapControl { get; set; }
        /// <summary>
        /// 主程序中的PageLayoutControl控件
        /// </summary>
        IPageLayoutControlDefault PageLayoutControl { get; set; }
        /// <summary>
        /// 主程序中的TOCControl控件
        /// </summary>
        ITOCControlDefault TOCControl { get; set; }
        /// <summary>
        /// 主程序的名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 主程序的窗体对象 需要进行替换为第三方
        /// </summary>
        Form MainPlatfrom { get; set; }
        /// <summary>
        /// 主程序窗体中的状态栏
        /// </summary>
        DevComponents.DotNetBar.Bar StatusBar { get; set; }
        /// <summary>
        /// 主程序UI界面的Visible属性
        /// </summary>
        bool Visible { get; set; }
    }
}
