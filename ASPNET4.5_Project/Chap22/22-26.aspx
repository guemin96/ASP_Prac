<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="22-26.aspx.cs" Inherits="Chap22._22_26" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            UserID : <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
            Password : <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox><br />
            Name : <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            Phone : <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <asp:Button ID="btnInsert" runat="server" Text="입력" OnClick="btnInsert_Click" /><br /><br />
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="UserID" OnRowEditing="GridView1_RowEditing"
                 OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating"
                 OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:CommandField ShowEditButton="true"  ShowDeleteButton="true"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
