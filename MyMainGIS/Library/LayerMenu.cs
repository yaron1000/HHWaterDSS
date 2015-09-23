using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF;
using System.Windows.Forms;
using System.Data;

/**
 * author lk 
 * 2015/7/17
 * 插件式gis应用框架的设计与实现
 * toccontrol layer 上右键时弹出快捷菜单
 * 
 * */
namespace MyMainGIS.Library
{
    public class LayerMenu : ESRI.ArcGIS.ADF.BaseClasses.BaseCommand, ICommandSubType
    {

        private IHookHelper m_hookHelper = new HookHelperClass();
        private long m_subType;
        private ILayer m_layer;
        private IMapControlDefault m_mapControl;

        public LayerMenu(IMapControlDefault _mapControl)
        {
            this.m_mapControl = _mapControl;
            //this.m_layer = (ILayer)_mapControl.CustomProperty;
        }

        public override void OnClick()
        {
            this.m_layer = (ILayer)this.m_mapControl.CustomProperty;
            switch (m_subType)
            {
                case 1:
                    m_hookHelper.FocusMap.DeleteLayer(this.m_layer);
                    break;
                case 2:
                    this.m_mapControl.Extent = this.m_layer.AreaOfInterest;
                    break;
                case 3:
                    if (this.m_layer is IRasterLayer)
                    {
                        return;
                    }
                    
                    frmAttributeTable fmAttriTable = new frmAttributeTable(this.m_layer,this.m_mapControl as MapControl);
                    fmAttriTable.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        public override void OnCreate(object hook)
        {
            m_hookHelper.Hook = hook;
        }

        #region ICommandSubType 成员

        public int GetCount()
        {
            return 3;
        }

        public void SetSubType(int SubType)
        {
            m_subType = SubType;
        }

        #endregion

        public override string Caption
        {
            get
            {
                switch (m_subType)
                {
                    case 1:
                        return "删除图层";
                    case 2:
                        return "缩放至图层";
                    case 3:
                        return "打开属性表";
                    default:
                        return "";
                }
            }
        }

    }
}
