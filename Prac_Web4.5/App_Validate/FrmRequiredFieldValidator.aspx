<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRequiredFieldValidator.aspx.cs" Inherits="App_Validate.FrmRequiredFieldValidator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>입력 확인 유효성 검사 컨트롤</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>입력 확인 유효성 검사 컨트롤</h3>
            아이디 :
            <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valUserID" runat="server" 
                ControlToValidate="txtUserID" ErrorMessage="아이디를 입력하세요" Display="Static">
            </asp:RequiredFieldValidator>
            <br />
            비밀번호 :
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="암호를 입력하시오"></asp:RequiredFieldValidator>
            <hr />

            <asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_Click">로그인</asp:LinkButton>
        
        </div>
    </form>
</body>
</html>
