using NewsCollection.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsCollection.Operation
{
    class TaskOperation
    {
        DataBaseManager dataManager = DataBaseManager.getInstance();
        //刷新
        public void refresh(TreeView treeView1)
        {
            
            treeView1.Nodes.Clear();
            DataTable dt1 = dataManager.getTaskGroup();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                TreeNode tn = treeView1.Nodes.Add(dt1.Rows[i]["title"] as String);
                DataTable dt2 = dataManager.getTaskInGroup(dt1.Rows[i].ItemArray[0] as String);
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    TreeNode ntn = new TreeNode(dt2.Rows[j]["name"] as String);
                    tn.Nodes.Add(ntn);
                }
            }
        }
        
    }
}
