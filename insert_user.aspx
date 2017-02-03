<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert_user.aspx.cs" Inherits="WebApplication1.insert_user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            insert user
        </div>
        <div>
            <asp:TextBox ID="name" runat="server"> </asp:TextBox>name
        </div>
        <div>
            <asp:TextBox ID="email" runat="server"> </asp:TextBox>email
        </div>
        <div>
            <asp:TextBox ID="pass" runat="server"> </asp:TextBox>password
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Insert" OnClick="Button1_Click" />
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
