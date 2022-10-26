<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="21-3.aspx.cs" Inherits="Chap15._21_3" %>
<%@ Register Src="~/WebUserControl.ascx" TagName="WebUserControl" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:WebUserControl ID="WebUserControl1" runat="server" /><br />
            <asp:Label ID="label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
