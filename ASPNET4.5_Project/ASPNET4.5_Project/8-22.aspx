<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="8-22.aspx.cs" Inherits="ASPNET4._5_Project._8_22" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            선택한 회원 : <asp:Label ID="Label1" runat="server"></asp:Label><br />
            <asp:ListView ID ="ListView1" runat="server"
                 DataKeyNames="UserID" InsertItemPosition ="LastItem"
                 OnItemEditing ="ListView1_ItemEditing"
                 OnItemUpdating ="ListView1_ItemUpdating"
                 OnItemCanceling ="ListView1_ItemCanceling"
                 OnItemDeleting ="ListView1_ItemDeleting"
                 OnSelectedIndexChanging ="ListView1_SelectedIndexChanging"
                 OnItemInserting ="ListView1_ItemInserting">
                <LayoutTemplate>
                    <table border="1">
                        <tr>
                            <td>명령</td>
                            <td>아이디</td>
                            <td>암호</td>
                            <td>이름</td>
                            <td>연락처</td>
                        </tr>
                        <tr id="itemPlaceholder" runat="server"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Button ID="btnEdit" runat="server" Text="편집" CommandName="Edit" />
                            <asp:Button ID="btnDelete" runat="server" Text ="삭제" CommandName ="Delete" OnClientClick="return confirm('삭제하시겠습니까?');" />
                            <asp:Button ID="btnSelect" runat="server" Text ="선택" CommandName ="Select" />
                                
                        </td>
                        <td>
                            <%# Eval("UserID") %>
                        </td>
                        <td>
                            <%# Eval("Password") %>
                        </td>
                        <td>
                            <%# Eval("Name") %>
                        </td>
                        <td>
                            <%# Eval("Phone") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:Button ID="btnUpdate" runat="server" Text="업데이트" CommandName="Update" />
                            <asp:Button ID="btnCancel" runat="server" Text="취소" CommandName="Cancel" />
                        </td>
                        <td>
                            <%# Eval("UserID") %>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>"
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>"
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" Text='<%# Bind("Phone") %>'></asp:TextBox>"
                        </td>
                    </tr>
                </EditItemTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color:silver">
                        <td>
                            <asp:Button ID="btnEdit" runat="server" Text="편집" CommandName="Edit" />
                            <asp:Button ID="btnDelete" runat="server" Text ="삭제" CommandName ="Delete" OnClientClick="return confirm('삭제하시겠습니까?');" />
                            <asp:Button ID="btnSelect" runat="server" Text ="선택" CommandName ="Select" />
                        </td>
                        <td>
                            <%# Eval("UserID") %>
                        </td>
                        <td>
                            <%# Eval("Password") %>
                        </td>
                        <td>
                            <%# Eval("Name") %>
                        </td>
                        <td>
                            <%# Eval("Phone") %>
                        </td>
                    </tr>
                </SelectedItemTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:Button ID="btnInsert" runat="server" Text="저장" CommandName="Insert" />
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserID" runat="server" Text='<%# Bind("UserID") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("Password") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" Text='<%# Bind("Phone") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
            </asp:ListView>
        </div>
    </form>
</body>
</html>
