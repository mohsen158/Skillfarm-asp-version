<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="masterpage.Master" CodeBehind="delete_department.aspx.cs" Inherits="WebApplication1.delete_department" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="ui container segment">

           
                <div class="ui form">
                    <div class="panel-heading">delete department</div>
                     
                        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged">id</asp:TextBox>
                        <asp:Button ID="Button1" class="ui button" runat="server" OnClick="Button1_Click" Text="Delete" />
                    
                    <div class="panel-footer">
                        <asp:GridView class="ui celled padded table" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="LinqDataSource1">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                                <asp:BoundField DataField="name" HeaderText="name" ReadOnly="True" SortExpression="name" />
                            </Columns>
                        </asp:GridView>
                        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="WebApplication1.DataClasses1DataContext" EntityTypeName="" Select="new (id, name, created_at, courses)" TableName="departments">
                        </asp:LinqDataSource>
                    </div>
                </div>
         

        </div>
    
</asp:Content>