<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPageLoad.aspx.cs" Inherits="DevASPNET.FrmPageLoad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Page 클래스</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnPostBack" runat="server" Text="다시 게시(PostBack)" OnClick="btnPostBack_Click" />
            <asp:Button ID="btnNewLoad" runat="server" onclick="btnNewLoad_Click" Text="다시 로드" />
            <asp:Button ID="btntest" runat ="server" OnClick="btntest_Click" Text="테스트" />
            <input type ="button" onclick="btntest_Click"/>
        </div>
    </form>
</body>
</html>
