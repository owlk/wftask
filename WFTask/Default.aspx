<%@ Page Title="Category tree" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    
    <asp:TreeView ID="TreeView" runat="server" ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" OnTreeNodeDataBound="TreeView1_TreeNodeDataBound" >
        <DataBindings>
            <asp:TreeNodeBinding DataMember="WebApplication2.Model.Category" TextField="NameAndProductCount" ValueField="Name" />
        </DataBindings>
        <SelectedNodeStyle CssClass="SelectedNode" />
    </asp:TreeView>

    <asp:GridView ID="GridView1" runat="server" Width="100%">
        
        
    </asp:GridView>

    

</asp:Content>
