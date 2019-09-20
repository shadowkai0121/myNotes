<Script Language="VB" runat="server">
   Dim weekstr() = { "日", "一", "二", "三", "四", "五", "六" }
   Dim Nweek = DatePart( DateInterval.Weekday, Now ) - 1
   Dim Cweek = weekstr(Nweek)
</Script>

<HTML><BODY BGCOLOR="#FFFFFF">
<H2>星期<%=Cweek%>的水果是
<HR WIDTH="100%"></H2>
<CENTER>
<IMG SRC="fruit<%=Nweek%>.gif">
</CENTER>
</BODY>
</HTML>
