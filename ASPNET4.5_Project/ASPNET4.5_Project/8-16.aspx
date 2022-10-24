<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="8-16.aspx.cs" Inherits="ASPNET4._5_Project._8_16" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            선택한 회원 : <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="UserID" 
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                <Columns>
                    <asp:CommandField ShowEditButton ="true" ShowDeleteButton="true" ShowSelectButton="true" HeaderText="명령" />
                    <asp:BoundField DataField="UserID" HeaderText="아이디" ReadOnly="true" />
                    <asp:BoundField DataField="Password" HeaderText="비밀번호" />
                    <asp:BoundField DataField="Name" HeaderText="이름" />
                    <asp:BoundField DataField="Phone" HeaderText="연락처" />
                </Columns>
                <SelectedRowStyle BackColor="Silver" />

            </asp:GridView>
        </div>
    </form>
</body>
</html>
