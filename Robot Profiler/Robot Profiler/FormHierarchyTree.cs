using System;
using System.Data;
using System.Windows.Forms;

namespace Robot_Profiler
{
    public partial class FormHierarchyTree : Form
    {

        private String DataFile;
        private String KwName;
        private String KwID;


        public FormHierarchyTree()
        {
            InitializeComponent();
        }

        public FormHierarchyTree(String datafile, String kwName, string ID)
        {
            InitializeComponent();
            DataFile = datafile;
            KwName = kwName;
            KwID = ID;
            this.Text = "Keyword:" + kwName + " - " + datafile;
        }

        private void FormHierarchyTree_Shown(object sender, EventArgs e)
        {            
            ProfileDB db = new ProfileDB(DataFile, false);
            DataRow KW = db.GetKwByID(KwID);
            TreeNode parentNode = generateNode(KW);
            treeViewKw.Nodes.Add(retrieveTree(KW["ParentID"].ToString(), parentNode));
            treeViewKw.ShowNodeToolTips = true;
            treeViewKw.ExpandAll();
        }

        private TreeNode retrieveTree (string ID, TreeNode node)
        {
            ProfileDB db = new ProfileDB(DataFile, false);
            DataRow KW = db.GetKwByID(ID);

            if (KW == null)
            {
                return node;
            }
            TreeNode parentNode = generateNode(KW);          
            parentNode.Nodes.Add(node);
            return retrieveTree(KW["ParentID"].ToString(), parentNode);

        }

        private TreeNode generateNode(DataRow KW)
        {
            TreeNode node;
            switch (KW["Type"].ToString())
            {
                case "suite":
                    if (KW["Status"].ToString() == "PASS")
                    {
                        node = new TreeNode(KW["Name"].ToString(), 2, 2);
                    }
                    else
                    {
                        node = new TreeNode(KW["Name"].ToString(), 3, 3);
                    }
                    break;
                case "test":
                    if (KW["Status"].ToString() == "PASS")
                    {
                        node = new TreeNode(KW["Name"].ToString(), 4, 4);
                    }
                    else
                    {
                        node = new TreeNode(KW["Name"].ToString(), 5, 5);
                    }
                    break;
                case "kw":
                    if (KW["Status"].ToString() == "PASS")
                    {
                        node = new TreeNode(KW["Name"].ToString(), 6, 6);
                    }
                    else
                    {
                        node = new TreeNode(KW["Name"].ToString(), 7, 7);
                    }
                    break;
                default:
                    node = new TreeNode("[" + KW["Type"].ToString() + "] " + KW["Name"].ToString());
                    break;
            }
            node.ToolTipText = "Start Time: " + KW["StartTime"].ToString() + "\nEnd Time: " + KW["EndTime"].ToString() + "\nDuration: " + KW["Duration"].ToString();
            node.Tag = KW["ID"].ToString();
            return node;
        }

        private void graphAllPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeViewKw.SelectedNode;
            if (node!= null)
            {
                Form formGraphKwPoints = new FormGraphKwPoints(DataFile, node.Text, node.Tag.ToString())
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                formGraphKwPoints.Show();
            }


        }
    }
}
