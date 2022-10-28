<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyLogin.aspx.cs" Inherits="SafetyPrac.MyLogin" %>

<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            아이디 : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
            암호 : <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:CheckBox ID="CheckBox1" runat="server" />로그인 상태 유지<br />
            <asp:Button ID="Button1" runat="server" Text="로그인" OnClick="Button1_Click" /><br />
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
