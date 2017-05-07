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
    public class WebsiteOpeartion
    {
        //刷新
        public void refresh(TreeView treeView1)
        {
            DataBaseManager dataManager = DataBaseManager.getInstance();
            treeView1.Nodes.Clear();
            DataTable dt1 = dataManager.getWebsiteGroup();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                TreeNode tn = treeView1.Nodes.Add(dt1.Rows[i]["title"] as String);
                DataTable dt2 = dataManager.getWebsiteInGroup(dt1.Rows[i]["title"] as String);
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    TreeNode ntn = new TreeNode(dt2.Rows[j]["title"] as String);
                    tn.Nodes.Add(ntn);
                }
            }
        }
        //搜索时界面的展示刷新
        public void refresh(TreeView treeView1,DataTable dt1)
        {
            treeView1.Nodes.Clear();
            TreeNode tn = new TreeNode();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                if (i == 0)
                {
                    tn = treeView1.Nodes.Add(dt1.Rows[i]["groupname"] as String);
                }
                else if(!(dt1.Rows[i]["groupid"] as String).Equals(dt1.Rows[i-1]["groupid"] as String))
                {
                    tn = treeView1.Nodes.Add(dt1.Rows[i]["groupname"] as String);
                }
                TreeNode ntn = new TreeNode(dt1.Rows[i]["website"] as String);
                tn.Nodes.Add(ntn);
            }
        }
    }
}
