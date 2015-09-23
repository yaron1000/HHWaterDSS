using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseManageBar
{
    public partial class fm_CreateTableToWord : DevComponents.DotNetBar.OfficeForm
    {
        public fm_CreateTableToWord()
        {
            InitializeComponent();
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
        private void btn_CreateDirctToWord_Click(object sender, EventArgs e)
        {

            try
            {
                SaveFileDialog sfd_Form = new SaveFileDialog();
                //设置文件类型  
                sfd_Form.Filter = "Word(*.docx)|*.docx|Word(*.doc)|*.doc|All files(*.*)|*.*";

                //设置默认文件类型显示顺序  
                sfd_Form.FilterIndex = 3;

                //保存对话框是否记忆上次打开的目录  
                sfd_Form.RestoreDirectory = true;

                if (sfd_Form.ShowDialog() == DialogResult.OK)
                {
                    this.progressBar1.Visible = true;
                    for (int progressValue = 0; progressValue < 80; progressValue += 10)
                    {
                        System.Threading.Thread.Sleep(100);
                        progressBar1.Value = progressValue;

                    }

                    //获取所有的表名并除去字典表
                    string[] dbTableNames = SqlOperation.GetAllTableName();//数据库所有的表名
                    List<string> tableNames = new List<string>();//除去字典表的表名
                    foreach (string tableName in dbTableNames)
                    {
                        if (tableName != "tb_dict")
                        {
                            tableNames.Add(tableName);
                        }
                    }
                    //查询每张表所对应的字典表数据
                    List<System.Data.DataTable> listDtDicts = new List<System.Data.DataTable>();//储存所有表所对应的字典表

                    //获取字典表
                    foreach (string tableName in tableNames)
                    {
                        string sqlselectDict = "select * from tb_dict where TableName = '" + tableName + "'";
                        System.Data.DataTable dt = SqlOperation.SelectData(sqlselectDict);
                        listDtDicts.Add(dt);

                    }

                    Microsoft.Office.Interop.Word._Application app = new Microsoft.Office.Interop.Word.Application();//创建word应用程序
                    Microsoft.Office.Interop.Word._Document doc = app.Documents.Add();//添加一个word文档
                    object oMissing = System.Reflection.Missing.Value;


                    for (int tableIndex = 0; tableIndex < listDtDicts.Count; tableIndex++)
                    {
                        System.Data.DataTable dt = listDtDicts[tableIndex];
                        int rows = dt.Rows.Count + 1;//表格行数加1是为了标题栏
                        int cols = dt.Columns.Count;//表格列数

                        //输出大标题加粗加大字号水平居中
                        app.Selection.Font.Bold = 700;
                        app.Selection.Font.Size = 16;
                        app.Selection.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        app.Selection.Text = tableNames[tableIndex].ToString() + "字典表";

                        //换行添加表格
                        object line = Microsoft.Office.Interop.Word.WdUnits.wdLine;
                        app.Selection.MoveDown(ref line, oMissing, oMissing);
                        app.Selection.TypeParagraph();//换行

                        Microsoft.Office.Interop.Word.Range range = app.Selection.Range;
                        Microsoft.Office.Interop.Word.Table table = app.Selection.Tables.Add(range, rows, cols, ref oMissing, ref oMissing);

                        //设置表格的字体大小粗细
                        table.Range.Font.Size = 10;
                        table.Range.Font.Bold = 0;
                        //设置表格边框
                        table.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                        table.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;

                        //设置表格标题 
                        for (int field = 0; field < cols; field++)
                        {
                            //注意Word下标从一开始
                            table.Cell(1, field + 1).Range.Text = dt.Columns[field].ColumnName;
                        }


                        //循环数据创建数据行
                        for (int row = 0; row < dt.Rows.Count; row++)
                        {
                            for (int column = 0; column < cols; column++)
                            {
                                //对单元格设置上下居中
                                table.Cell(row + 2, column + 1).VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                                //写入数据
                                if (column == 0)
                                {
                                    table.Cell(row + 2, column + 1).Range.Text = (row + 1).ToString();
                                }
                                else
                                {
                                    table.Cell(row + 2, column + 1).Range.Text = dt.Rows[row][column].ToString();
                                }
                            }

                        }
                        //object WdStory = Microsoft.Office.Interop.Word.WdUnits.wdLine;
                        //app.Selection.EndKey(ref WdStory, ref oMissing);
                        object count = rows + 2;
                        object WdLine = Microsoft.Office.Interop.Word.WdUnits.wdLine;//换一行;
                        app.Selection.MoveDown(ref WdLine, ref count, ref oMissing);//移动焦点
                        app.Selection.TypeParagraph();
                    }
                    //导出到文件
                    string filePath = sfd_Form.FileName.ToString();
                    doc.SaveAs(filePath,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                    doc.Close();//关闭文档
                    app.Quit();//退出应用程序
                    this.progressBar1.Value = 100;
                    MessageBox.Show("导出成功！", "消息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.progressBar1.Visible = false;
                    this.progressBar1.Value = 30;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
