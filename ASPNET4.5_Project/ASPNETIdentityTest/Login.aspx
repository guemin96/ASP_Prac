<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ASPNETIdentityTest.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="phStatusText" runat="server" Visible="false">
                <p>
                    <asp:Literal ID="litStatusText" runat="server"></asp:Literal>
                </p>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phLogin" runat="server" Visible="false">
                사용자 아이디 :
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox><br />
                암호 :
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
                <asp:Button ID="btnLogin" runat="server" Text="로그인" OnClick="btnLogin_Click" />
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="phLogout" runat="server" Visible="false">
                <asp:Button ID="btnLogout" runat="server" Text="로그아웃" OnClick="btnLogout_Click" />
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
