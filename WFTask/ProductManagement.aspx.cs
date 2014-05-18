
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Model;
using WebApplication2.App_Code;

namespace WebApplication2
{
    public partial class ProductManagement : System.Web.UI.Page
    {
        

        private Dictionary<string, Category> pathToCategoryDict;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pathToCategoryDict = new Dictionary<string, Category>();
                Session.Add(Constants.SESSION_KEY_DICTIONARY, pathToCategoryDict);

                BindTreeWithCategoryRoot();
            }
            else
            {
                pathToCategoryDict = Session[Constants.SESSION_KEY_DICTIONARY] as Dictionary<string, Category>;
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            AlertUtils.HandleCommunicate(Session, AlertLabel);
        }


        

        private Category GetCurrentSelectedCategory()
        {
            return pathToCategoryDict[TreeView.SelectedNode.ValuePath];
        }

        private void BindTreeWithCategoryRoot()
        {
            pathToCategoryDict.Clear();
            TreeView.DataSource = DataRepository.GetCategoriesRoot();
            TreeView.DataBind();
        }

        protected void TreeView_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {
            pathToCategoryDict.Add(e.Node.ValuePath, e.Node.DataItem as Category);
        }

        protected void AddProductBtn_Click(object sender, EventArgs e)
        {

            if (TreeView.SelectedNode != null)
            {
                var category = GetCurrentSelectedCategory();
                category.Products.Add(new Product(NameTB.Text, DescTB.Text, PriceTB.Text));

                AlertUtils.SetCommunicate(Session, Constants.COMMUNICATE_PRODUCT_ADDED);

                ClearTextBoxes();
            }
            else
            {
                AlertUtils.SetCommunicate(Session, Constants.COMMUNICATE_NOTE_NOT_SELECTED);
            } 
        }

        private void ClearTextBoxes()
        {
            NameTB.Text = "";
            DescTB.Text = "";
            PriceTB.Text = "";
        }

    }
}