<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyDefault.aspx.cs" Inherits="SafetyPrac.MyDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> <br />
            <asp:Button ID="Button1" runat="server" Text="로그아웃" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
