<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="test0423_StateInfo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Write to Application" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Read from Application" OnClick="Button2_Click" />
        </div>
        <div>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button3" runat="server" Text="Write to Session" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="Read from Session" OnClick="Button4_Click" />
        </div>
        <div>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:Button ID="Button5" runat="server" Text="Write to Cookie" OnClick="Button5_Click" />
            <asp:Button ID="Button6" runat="server" Text="Read from Cookie" OnClick="Button6_Click" />
        </div>
    </form>
</body>
</html>
