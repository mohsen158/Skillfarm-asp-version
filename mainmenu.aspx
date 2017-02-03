<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mainmenu.aspx.cs" Inherits="WebApplication1.mainmenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert  departments" />
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="delete departments" />
        </p>
    </form>
</body>
</html>
