<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ASPNETIdentityTest.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            사용자 아이디 :
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox> <br />
            비밀번호 :
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            암호 확인 :
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox><br />
            <asp:Button ID="btnCreateUser" runat="server" Text="사용자 생성" OnClick="btnCreateUser_Click" /><br />
            <asp:Literal ID="litStatusMessage" runat="server"></asp:Literal>

        </div>
    </form>
</body>
</html>
