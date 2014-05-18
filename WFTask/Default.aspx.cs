using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.App_Code;
using WebApplication2.Model;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        Dictionary<string, Category> pathToCategoryDict = new Dictionary<string, Category>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TreeView.DataSource = DataRepository.GetCategoriesRoot();
                TreeView.DataBind();
                Session.Add(Constants.SESSION_KEY_DICTIONARY, pathToCategoryDict);
            }
            else
            {
                pathToCategoryDict = Session[Constants.SESSION_KEY_DICTIONARY] as Dictionary<string, Category>;
            }
            

        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            var tree = sender as TreeView;
            var category = pathToCategoryDict[tree.SelectedNode.ValuePath];

            GridView1.DataSource = category.Products;
            GridView1.DataBind();

        }

        protected void TreeView1_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {
            pathToCategoryDict.Add(e.Node.ValuePath, e.Node.DataItem as Category);
        }
    }
}