<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmStateShow.aspx.cs" Inherits="DevStateManagement.FrmStateShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>저장된 상태 보기</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>서버에 저장</h3>
            Application 개체 :
            <asp:TextBox ID="txtApplication" runat ="server"></asp:TextBox><br />
            Session 개체 :
            <asp:TextBox ID="txtSession" runat ="server"></asp:TextBox><br />
            Cache 개체 :
            <asp:TextBox ID="txtCache" runat ="server"></asp:TextBox><br />

            <h3>클라이언트에 저장</h3>
            Cookies 개체 :
            <asp:TextBox ID="txtCookies" runat ="server"></asp:TextBox><br />
            ViewState 개체 :
            <asp:TextBox ID="txtViewState" runat ="server"></asp:TextBox><br />
        </div>
    </form>
</body>
</html>
