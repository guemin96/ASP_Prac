<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberControl.aspx.cs" Inherits="SafetyPrac.MemberControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
<asp:CreateUserWizard runat="server">
    <wizardsteps>
        <asp:CreateUserWizardStep runat="server" />
        <asp:CompleteWizardStep runat="server" />
    </wizardsteps>
</asp:CreateUserWizard>
</html>
