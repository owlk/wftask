<%@ Page Title="Category management" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryManagement.aspx.cs" Inherits="WebApplication2.CategoryManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <asp:Label ID="AlertLabel" runat="server" Text="Label" Visible="False" Font-Bold="True" Font-Size="Large" ForeColor="#CC0000"></asp:Label>
    <asp:TreeView ID="TreeView" runat="server"
        ShowLines="True"
        OnTreeNodeDataBound="TreeView_TreeNodeDataBound">
        <DataBindings>
            <asp:TreeNodeBinding DataMember="WebApplication2.Model.Category" TextField="Name" ValueField="Name" />
        </DataBindings>

        <SelectedNodeStyle CssClass="SelectedNode" />
    </asp:TreeView>

    <asp:RequiredFieldValidator runat="server"
        ControlToValidate="NameTB"
        ErrorMessage="Name field is required. " Display="Dynamic" ValidationGroup="NameVG"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="NameTB" runat="server" placeholder="category name" Width="40%"></asp:TextBox>
    <br />
    <asp:Button ID="AddBtn" runat="server" OnClick="AddBtn_Click"
        Text="add category" Width="40%" ValidationGroup="NameVG" />
     <br />

    <asp:Button ID="RootBtn" runat="server" OnClick="RootBtn_Click"
        Text="deselect category" Width="40%" Visible = "false" />
     <br />
    <asp:Button ID="RemoveBtn" runat="server" OnClick="RemoveBtn_Click"
        Text="remove selected category" 
        OnClientClick="return confirm('Removing category will cause all it\'s products erasure. Are you sure?');"
         Width="40%" />
    <br />
</asp:Content>
