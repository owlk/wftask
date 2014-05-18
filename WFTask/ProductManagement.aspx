<%@ Page Title="Product management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductManagement.aspx.cs" Inherits="WebApplication2.ProductManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
     <asp:Label ID="AlertLabel" runat="server" Text="Label" Visible="False" Font-Bold="True" Font-Size="Large" ForeColor="#CC0000"></asp:Label>
    
    <asp:TreeView SelectedNodeStyle-ForeColor="Green" ID="TreeView" runat="server"
        ShowLines="True" 
        OnTreeNodeDataBound="TreeView_TreeNodeDataBound">
        <DataBindings>
            <asp:TreeNodeBinding DataMember="WebApplication2.Model.Category" TextField="Name" ValueField="Name" />
        </DataBindings>

        <SelectedNodeStyle CssClass="SelectedNode" />
    </asp:TreeView>
    <br />
    <asp:RequiredFieldValidator runat=server 
            ControlToValidate=NameTB
            ErrorMessage="Name field is required. " Display="Dynamic"> 
    </asp:RequiredFieldValidator>
 
    <asp:RequiredFieldValidator runat=server 
            ControlToValidate=PriceTB
            ErrorMessage="Price field is required. " Display="Dynamic"> 
    </asp:RequiredFieldValidator>

    <asp:CompareValidator  runat="server" ControlToValidate=PriceTB 
        ErrorMessage="Incorrect price value. " 
        Operator="DataTypeCheck" Type="Currency" Display="Dynamic">
    </asp:CompareValidator>
    <br />
    <asp:TextBox ID="NameTB" runat="server" placeholder="name"></asp:TextBox>
    <asp:TextBox ID="DescTB" runat="server" placeholder="description"></asp:TextBox>
    <asp:TextBox ID="PriceTB" runat="server" placeholder="price"></asp:TextBox>
<br />
<asp:Button ID="AddProductBtn" runat="server" OnClick="AddProductBtn_Click" Text="add product" />
</asp:Content>
