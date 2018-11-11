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
            TreeNode parentNode = new TreeNode("[" + KW["Type"].ToString() + "] " + KwName);
            treeViewKw.Nodes.Add(retrieveTree(KW["ParentID"].ToString(), parentNode));
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
            TreeNode parentNode = new TreeNode("["+ KW["Type"].ToString() + "] " + KW["Name"].ToString());
            parentNode.Nodes.Add(node);
            return retrieveTree(KW["ParentID"].ToString(), parentNode);

        }

    }
}
