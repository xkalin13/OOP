<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>+</asp:ListItem>
                <asp:ListItem>-</asp:ListItem>
                <asp:ListItem>*</asp:ListItem>
                <asp:ListItem>/</asp:ListItem>

            </asp:DropDownList>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
            <asp:Label ID="Label1" runat="server" Font-Size="Large" Height="25px" Text="Label" Width="50px"></asp:Label>
        </div>
    </form>
</body>
</html>
