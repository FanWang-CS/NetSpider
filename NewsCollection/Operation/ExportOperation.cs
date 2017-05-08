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
    }
}
