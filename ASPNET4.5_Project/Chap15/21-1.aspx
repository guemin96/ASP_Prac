<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="21-1.aspx.cs" Inherits="Chap15._21_1" %>
<%@ OutputCache Duration="10" VaryByParam="MyParameter" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="21-1.aspx?MyParameter=a">21-1.aspx a</a>
            <a href="21-1.aspx?MyParameter=b">21-1.aspx b</a>
            페이지가 캐싱된 시간 : <asp:Label ID="label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
