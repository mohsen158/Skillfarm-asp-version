<%@ Page Language="C#" AutoEventWireup="true"MasterPageFile="masterpage.Master" CodeBehind="department_courses.aspx.cs" Inherits="WebApplication1.department_courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="ui container segment">
       
      
 <div class="ui form">
                <div class="panel-heading">
                    courses of department
                </div>

                <div class="panel-body">

                    <asp:TextBox ID="TextBox1" runat="server">id</asp:TextBox>
                    <asp:Button ID="Button1" class="ui button" runat="server" Text="search" OnClick="Button1_Click" />

                </div>
                <div class="panel-footer">


                    <asp:GridView class="ui celled padded table" ID="GridView1" runat="server">
                    </asp:GridView>
                  

                </div>
            

        </div>

    </div>
</asp:Content>