using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection.Operation
{
    class ExportOperation
    {
        //导出到数据库
        public List<List<String>> outputDatas(DataGridView dataGridView)
        {
            int rowNum = dataGridView.Rows.Count;
            int colNum = dataGridView.Columns.Count;
            List<List<String>> tables = new List<List<string>>();
            for (int i = 0; i < rowNum; i++)
            {
                List<String> row = new List<string>();
                for (int j = 0; j < colNum; j++)
                {
                    row.Add(dataGridView.Rows[i].Cells[j].Value as String);
                }
                tables.Add(row);
            }
            return tables;
        }
        //dataGridView导出到TXT
        public void dataGridViewTOTxt(DataGridView dataGridView1)
        {
            string fileName = "";
            string saveFileName = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "txt";
            saveDialog.Filter = "文本文档|*.txt";
            saveDialog.FileName = fileName;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0)
                return; //被点了取消
            FileStream fileStream = new FileStream(saveFileName, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream, System.Text.Encoding.Unicode);

            StringBuilder strBuilder = new StringBuilder();

            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    strBuilder = new StringBuilder();
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        strBuilder.Append(dataGridView1.Rows[i].Cells[j].Value.ToString() + " ");
                    }
                    strBuilder.Remove(strBuilder.Length - 1, 1);
                    streamWriter.WriteLine(strBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                string strErrorMessage = ex.Message;
            }
            finally
            {
                streamWriter.Close();
                fileStream.Close();
            }
        }

        #region 导出到Excel
        public void ReportToExcel(DataGridView dataGridView1, string ReportTitleName)
        {
            //获取用户选择的excel文件名称
            string path;
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Excel files(*.xls)|*.xls";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                //获取保存路径
                path = savefile.FileName;
                Workbook wb = new Workbook();
                Worksheet ws = wb.Worksheets[0];
                Cells cell = ws.Cells;
                //定义并获取导出的数据源
                int RowsCount = dataGridView1.Rows.Count - 1;
                string[,] _ReportDt = new string[RowsCount, dataGridView1.ColumnCount];
                for (int i = 0; i < RowsCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if(dataGridView1.Rows[i].Cells[j].Value as String == null)
                        {
                            _ReportDt[i, j] = "";
                        }
                        else
                        {
                            _ReportDt[i, j] = dataGridView1.Rows[i].Cells[j].Value as String;
                        }
                        
                    }
                }
                //合并第一行单元格
                Range range = cell.CreateRange(0, 0, 1, dataGridView1.ColumnCount);
                range.Merge();
                cell["A1"].PutValue(ReportTitleName); //标题

                //设置行高
                cell.SetRowHeight(0, 20);

                //设置字体样式
                Style style1 = wb.Styles[wb.Styles.Add()];
                style1.HorizontalAlignment = TextAlignmentType.Center;//文字居中
                style1.Font.Name = "宋体";
                style1.Font.IsBold = true;//设置粗体
                style1.Font.Size = 12;//设置字体大小

                Style style2 = wb.Styles[wb.Styles.Add()];
                style2.HorizontalAlignment = TextAlignmentType.Center;
                style2.Font.Size = 10;

                //给单元格关联样式
                cell["A1"].SetStyle(style1); //报表名字 样式

                //设置Execl列名
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    cell[1, i].PutValue(dataGridView1.Columns[i].HeaderText);
                    cell[1, i].SetStyle(style2);
                }

                //设置单元格内容
                int posStart = 2;
                for (int i = 0; i < RowsCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        cell[i + posStart, j].PutValue(_ReportDt[i, j].ToString());
                        cell[i + posStart, j].SetStyle(style2);
                    }
                }
                //保存excel表格
                wb.Save(path);
            }
        }
        #endregion
    }
}
