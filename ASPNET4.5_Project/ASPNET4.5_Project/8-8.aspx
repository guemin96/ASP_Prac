<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="8-8.aspx.cs" Inherits="ASPNET4._5_Project._8_8" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            아이디 : 
            <asp:TextBox ID ="TextBox1" runat="server"></asp:TextBox><br />
            
            암호 : 
            <asp:TextBox ID ="TextBox2" runat="server"></asp:TextBox><br />
            
            이름 : 
            <asp:TextBox ID ="TextBox3" runat="server"></asp:TextBox><br />
            
            연락처 : 
            <asp:TextBox ID ="TextBox4" runat="server"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="입력" OnClick="Button1_Click" /><br /><br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
