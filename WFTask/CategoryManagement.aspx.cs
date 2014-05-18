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
    public partial class CategoryManagement : System.Web.UI.Page
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
            HandleButtonsVisibility();
            AlertUtils.HandleCommunicate(Session, AlertLabel);
        }

        private void HandleButtonsVisibility()
        {
            RemoveBtn.Visible = IsCategorySelected();
            RootBtn.Visible = IsCategorySelected();
        }

        private bool IsCategorySelected()
        {
            return (TreeView.SelectedNode != null);
        }

        private void BindTreeWithCategoryRoot()
        {
            pathToCategoryDict.Clear();
            TreeView.DataSource = DataRepository.GetCategoriesRoot();
            TreeView.DataBind();
        }

        protected void RemoveBtn_Click(object sender, EventArgs e)
        {
            var parentNode = TreeView.SelectedNode.Parent;
            var category = GetCurrentSelectedCategory();

            if (parentNode != null)
            {

                var parentCategory = pathToCategoryDict[parentNode.ValuePath];
                parentCategory.Children.Remove(category);
                parentNode.ChildNodes.Remove(TreeView.SelectedNode);
            }
            else
            {
                DataRepository.GetCategoriesRoot().Remove(category);
                TreeView.Nodes.Remove(TreeView.SelectedNode);
            }

            
        }

        private Category GetCurrentSelectedCategory()
        {
            return pathToCategoryDict[TreeView.SelectedNode.ValuePath];
        }

        protected void TreeView_TreeNodeDataBound(object sender, TreeNodeEventArgs e)
        {
            pathToCategoryDict.Add(e.Node.ValuePath, e.Node.DataItem as Category);
        }      

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            var newCategory = new Category(NameTB.Text);

            bool succeeded = false; 

            if (TreeView.SelectedNode == null)
            {
                succeeded = DataRepository.GetCategoriesRoot().Add(newCategory);
            }
            else
            {
                succeeded = GetCurrentSelectedCategory().AddChild(newCategory);
            }

            if (succeeded)
            {
                NameTB.Text = "";
            }

            SetCategoryAdditionCommunicate(succeeded);
            
            BindTreeWithCategoryRoot();
        }

        private void SetCategoryAdditionCommunicate(bool succeeded)
        {
            if (!succeeded)
            {
                AlertUtils.SetCommunicate(Session, Constants.COMMUNICATE_CATEGORY_EXISTS);
            }
         
        }

        protected void RootBtn_Click(object sender, EventArgs e)
        {
            if (TreeView.SelectedNode != null)
            {
                TreeView.SelectedNode.Selected = false;
            }
        }

    }
}