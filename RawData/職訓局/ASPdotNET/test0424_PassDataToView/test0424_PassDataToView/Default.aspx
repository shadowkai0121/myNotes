<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="test0424_PassDataToView.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ul>
                <%-- 網頁裡面嵌入程式 程式裡面再放網頁 --%>
                <%for (int i = 0; i < testData; i++)
                    {%>
                <li><%=i+1 %></li>
                <%  } %>
            </ul>
        </div>
    </form>
</body>
</html>
