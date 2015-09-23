using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using MyMainGIS.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace MyMainGIS
{
    public partial class frmAttributeTable : DevComponents.DotNetBar.OfficeForm
    {
        private ILayer m_layer;
        private MapControl m_MapControl;
        System.Data.DataTable pDataTable = new System.Data.DataTable();
        public frmAttributeTable(ILayer layer,MapControl pMapControl)
        {
            InitializeComponent();
            this.m_layer = layer;
            this.m_MapControl = pMapControl;
            //禁用Glass主题
            this.EnableGlass = false;
            //不显示最大化最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //去除图标
            this.ShowIcon = false;
        }

        private void frmAttributeTable_Load(object sender, EventArgs e)
        {
            string sLayerName = LayerDataTable.getValidFeatureClassName(this.m_layer.Name);
            pDataTable = LayerDataTable.CreateDataTable(this.m_layer, sLayerName);

            BindingSource bs = new BindingSource();
            dataGridView.DataSource = bs;
            bs.DataSource = pDataTable;
            bindingNavigator1.BindingSource=bs;
        }

        //private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.RowIndex != -1)
        //    {
        //        IFeature pFeat = null;
        //        try
        //        {
        //            IFeatureClass pFeatCls = (m_MapControl.CustomProperty as IFeatureLayer).FeatureClass;
        //            pFeat = pFeatCls.GetFeature(Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value));
        //        }
        //        catch (Exception ex )
        //        {
        //            pFeat = null;
        //        }
        //        if (pFeat != null)
        //        {
        //            if (pFeat.Shape.GeometryType == ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint)
        //            {
        //                m_MapControl.CenterAt((IPoint)pFeat.Shape);
        //            }
        //            else
        //            {
        //                IEnvelope pEnv = pFeat.Shape.Envelope;
        //                pEnv.Expand(5,5,true);
        //                m_MapControl.ActiveView.Extent = pEnv;
        //            }
        //            m_MapControl.ActiveView.Refresh();
        //            m_MapControl.ActiveView.ScreenDisplay.UpdateWindow();
        //            switch (pFeat.Shape.GeometryType)
        //            { 
        //                case esriGeometryType.esriGeometryPoint:
        //                    FlashFeature.FlashPoint(m_MapControl,m_MapControl.ActiveView.ScreenDisplay,pFeat.Shape);
        //                    break;
        //                case esriGeometryType.esriGeometryPolyline:
        //                    FlashFeature.FlashLine(m_MapControl, m_MapControl.ActiveView.ScreenDisplay, pFeat.Shape);
        //                    break;
        //                case esriGeometryType.esriGeometryPolygon:
        //                    FlashFeature.FlashPoint(m_MapControl, m_MapControl.ActiveView.ScreenDisplay, pFeat.Shape);
        //                    break;
        //                default:
        //                    break;
        //            }
        //            m_MapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection,null,null);
        //            m_MapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        //        }

        //    }
        //}


        /// <summary>
        /// 构造查询条件
        /// </summary>
        /// <param name="where"></param>
        public void FilterLayer(string where)
        {
            IFeatureLayer flyr = m_layer as IFeatureLayer;
            IFeatureClass fcls = flyr.FeatureClass;

            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = where;

            // 缩放到选择结果集，并高亮显示 
            ZoomToSelectedFeature(flyr, queryFilter);

            //闪烁选中得图斑 
            IFeatureCursor featureCursor = fcls.Search(queryFilter, true);
            FlashPolygons(featureCursor);
        }
        /// <summary>
        /// 缩放到图层，并高亮显示
        /// </summary>
        /// <param name="pFeatureLyr"></param>
        /// <param name="pQueryFilter"></param>
        private void ZoomToSelectedFeature(IFeatureLayer pFeatureLyr, IQueryFilter pQueryFilter)
        {
            #region 高亮显示查询到的要素集合

            //符号边线颜色 
            IRgbColor pLineColor = new RgbColor();
            pLineColor.Red = 0;
            pLineColor.Green = 255;
            pLineColor.Blue = 255;
            ILineSymbol ilSymbl = new SimpleLineSymbolClass();
            ilSymbl.Color = pLineColor;
            ilSymbl.Width = 3;

            //定义选中要素的符号为红色 
            ISimpleFillSymbol ipSimpleFillSymbol = new SimpleFillSymbol();
            ipSimpleFillSymbol.Outline = ilSymbl;
            RgbColor pFillColor = new RgbColor();
            pFillColor.Green = 60;
            ipSimpleFillSymbol.Color = pFillColor;
            //ipSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSForwardDiagonal;
            ipSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSNull;

            //选取要素集 
            IFeatureSelection pFtSelection = pFeatureLyr as IFeatureSelection;
            pFtSelection.SetSelectionSymbol = true;
            pFtSelection.SelectionSymbol = (ISymbol)ipSimpleFillSymbol;
            pFtSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);

            #endregion
            m_MapControl.ActiveView.Refresh();
        }
        /// <summary>
        /// 闪烁选中图斑
        /// </summary>
        /// <param name="featureCursor"></param>
        private void FlashPolygons(IFeatureCursor featureCursor)
        {
            IArray geoArray = new ArrayClass();
            IFeature feature = null;
            while ((feature = featureCursor.NextFeature()) != null)
            {
                //feature是循环外指针，所以必须用ShapeCopy 
                geoArray.Add(feature.ShapeCopy);
            }

            //通过IHookActions闪烁要素集合 
            HookHelperClass m_pHookHelper = new HookHelperClass();
            m_pHookHelper.Hook = m_MapControl.Object;
            IHookActions hookActions = (IHookActions)m_pHookHelper;

            hookActions.DoActionOnMultiple(geoArray, esriHookActions.esriHookActionsPan);

            System.Windows.Forms.Application.DoEvents();
            m_pHookHelper.ActiveView.ScreenDisplay.UpdateWindow();

            hookActions.DoActionOnMultiple(geoArray, esriHookActions.esriHookActionsFlash);
            System.Windows.Forms.Application.DoEvents();
            m_pHookHelper.ActiveView.ScreenDisplay.UpdateWindow();

        }

        private void dataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView.SelectedRows[0].Cells[0].Value.ToString() != "")
            {
                long strflag = Convert.ToInt64(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
                string filename = pDataTable.Columns[0].ToString();

                if (filename == "FID")
                {

                    FilterLayer("FID=" + strflag + "");
                }
                else
                {


                    FilterLayer("OBJECTID=" + strflag + "");
                }
            }

        }

        /// <summary>
        /// 保存EXCEL事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files(*.xlsx)|*.xlsx|Excel files(*.xls)|*.xls|CSV files (*.csv)|*.csv";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "导出属性表";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportForDataGridview(dataGridView, saveFileDialog.FileName, false);
                    MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 由DataGridView导出EXCEL
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="fileName"></param>
        /// <param name="isShowExcle"></param>
        /// <returns></returns>
        public static bool ExportForDataGridview(DataGridView gridView, string fileName, bool isShowExcle)
        {

            //建立EXCEL对象
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                if (app == null)
                {
                    return false;
                }

                app.Visible = isShowExcle;
                Workbooks workbooks = app.Workbooks;
                _Workbook workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Sheets sheets = workbook.Worksheets;
                _Worksheet worksheet = (_Worksheet)sheets.get_Item(1);
                if (worksheet == null)
                {
                    return false;
                }
                string sLen = "";
                //取得最后一列列名
                char H = (char)(64 + gridView.ColumnCount / 26);
                char L = (char)(64 + gridView.ColumnCount % 26);
                if (gridView.ColumnCount < 26)
                {
                    sLen = L.ToString();
                }
                else
                {
                    sLen = H.ToString() + L.ToString();
                }


                //标题
                string sTmp = sLen + "1";
                Range ranCaption = worksheet.get_Range(sTmp, "A1");
                string[] asCaption = new string[gridView.ColumnCount];
                for (int i = 0; i < gridView.ColumnCount; i++)
                {
                    asCaption[i] = gridView.Columns[i].HeaderText;
                }
                ranCaption.Value2 = asCaption;

                //数据
                object[] obj = new object[gridView.Columns.Count];
                for (int r = 0; r < gridView.RowCount - 1; r++)
                {
                    for (int l = 0; l < gridView.Columns.Count; l++)
                    {
                        if (gridView[l, r].ValueType == typeof(DateTime))
                        {
                            obj[l] = gridView[l, r].Value.ToString();
                        }
                        else
                        {
                            obj[l] = gridView[l, r].Value;
                        }
                    }
                    string cell1 = sLen + ((int)(r + 2)).ToString();
                    string cell2 = "A" + ((int)(r + 2)).ToString();
                    Range ran = worksheet.get_Range(cell1, cell2);
                    ran.Value2 = obj;
                }
                //保存
                workbook.SaveCopyAs(fileName);
                workbook.Saved = true;
            }
            finally
            {
                //关闭
                app.UserControl = false;
                app.Quit();
            }
            return true;
        }
    }
}
