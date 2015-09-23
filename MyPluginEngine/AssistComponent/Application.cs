﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;

// 暂时
using System.Windows.Forms;

/**
 * author lk 
 * 2014/12/20
 * 插件式gis应用框架的设计与实现
 * 宿主程序 2 Application类（实现了IApplication接口）
 * gao
 * */
namespace MyPluginEngine
{
    /// <summary>
    /// IApplication接口的实现
    /// </summary>
    public class Application:IApplication
    {
        private string _Caption;
        private string _CurrentTool;
        private DataSet _MainDataSet;
        private IMapDocument _Document;
        private IMapControlDefault _MapControl;
        private IPageLayoutControlDefault _PageLayoutControl;
        private ITOCControlDefault _TOCControl;
        private string _Name;
        private Form _MainPlatfrom;
        private DevComponents.DotNetBar.Bar _StatusBar;
        private bool _Visible;


        #region IApplication 成员
        /// <summary>
        /// 主程序标题 值类型和引用类型才需要
        /// </summary>
        public string Caption
        {
            get
            {
                _Caption = this.MainPlatfrom.Text;
                return _Caption;
            }
            set
            {
                _Caption = value;
                _MainPlatfrom.Text = this._Caption;
            }
        }

        /// <summary>
        /// 主程序当前使用的工具Tool名称
        /// </summary>
        public string CurrentTool
        {
            get
            {
                return _CurrentTool;
            }
            set
            {
                _CurrentTool = value;
            }
        }

        /// <summary>
        /// 主程序存储GIS数据的数据集
        /// </summary>
        public DataSet MainDataSet
        {
            get
            {
                return _MainDataSet;
            }
            set
            {
                _MainDataSet = value;
            }
        }

        /// <summary>
        /// 主程序包含的文档对象
        /// </summary>
        public IMapDocument Document
        {
            get
            {
                return _Document;
            }
            set
            {
                _Document = value;
            }
        }

        /// <summary>
        /// 主程序中的MapControl控件
        /// </summary>
        public IMapControlDefault MapControl
        {
            get
            {
                return _MapControl;
            }
            set
            {
                _MapControl = value;
            }
        }

        /// <summary>
        /// 主程序中的PageLayoutControl控件
        /// </summary>
        public IPageLayoutControlDefault PageLayoutControl
        {
            get
            {
                return _PageLayoutControl;
            }
            set
            {
                _PageLayoutControl = value;
            }
        }

        public ITOCControlDefault TOCControl
        {
            get
            {
                return _TOCControl;
            }
            set
            {
                _TOCControl = value;
            }
        }

        /// <summary>
        /// 主程序的名称
        /// </summary>
        public string Name
        {
            get
            {
                this._Name = _MainPlatfrom.Text;
                return _Name;
            }
        }

        /// <summary>
        /// 主程序的窗体对象
        /// </summary>
        public Form MainPlatfrom
        {
            get
            {
                return _MainPlatfrom;
            }
            set
            {
                _MainPlatfrom = value;
            }
        }

        /// <summary>
        /// 主程序窗体中的状态栏
        /// </summary>
        public DevComponents.DotNetBar.Bar StatusBar
        {
            get
            {
                return _StatusBar;
            }
            set
            {
                _StatusBar = value;
            }
        }

        /// <summary>
        /// 主程序UI界面的Visible属性
        /// </summary>
        public bool Visible
        {
            get
            {
                _Visible = _MainPlatfrom.Visible;
                return _Visible;
            }
            set
            {
                _Visible = value;
                this._MainPlatfrom.Visible = _Visible;
            }
        }

        #endregion

    }
}
