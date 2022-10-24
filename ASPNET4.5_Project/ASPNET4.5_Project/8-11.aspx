<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="8-11.aspx.cs" Inherits="ASPNET4._5_Project._8_11" %>
<%@ import Namespace="System.Data.SqlClient" %>
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
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    아이디: <%#Eval("UserID") %><br />
                    암호: <%#Eval("Password") %><br />
                    이름: <%#Eval("Name") %><br />
                    연락처: <%#Eval("Phone") %>
                    <hr />

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
