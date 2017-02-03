<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="masterpage.Master" CodeBehind="insert_departments.aspx.cs" Inherits="WebApplication1.insert_departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ui container segment" style="margin-top: 20px">

        <div class="ui form">
            <div class="panel-heading">insert department</div>
            <div class="panel-body">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button CssClass="ui button" ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />
            </div>
            <div class="panel-footer">
                <asp:GridView ID="GridView1" class="ui celled padded table" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
            </div>
        </div>
       

    </div>



</asp:Content>
