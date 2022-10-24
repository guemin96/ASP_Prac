<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="8-17.aspx.cs" Inherits="ASPNET4._5_Project._8_17" %>
<%@ import Namespace="System.Data.SqlClient" %>
<%@ import Namespace="System.Data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                DataKeyNames="UserID" OnRowEditing="GridView1_RowEditing" 
                OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText ="명령">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text ="편집" CommandName ="Edit" />
                            <asp:Button ID="btnDelete" runat="server" Text ="삭제" CommandName ="Delete" OnClientClick="return confirm('삭제하시겠습니까?');" />
                            <asp:Button ID="btnSelect" runat="server" Text ="선택" CommandName ="Select" />
                                
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" Text="업데이트" CommandName="Update" />
                            <asp:Button ID="btnCanel" runat="server" Text="취소" CommandName="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText ="아이디">
                        <ItemTemplate>
                            <%# Eval("UserID") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="비밀번호">
                        <ItemTemplate>
                            <%# Eval("Password") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID ="txtPassword" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText ="물품">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ItemName") %>' ForeColor="Blue"></asp:Label>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText ="수량">
                        <ItemTemplate>
                            <%# Eval("Qty") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText ="단가">
                        <ItemTemplate>
                            <%# Eval("Price") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText ="합계">
                        <ItemTemplate>
                            <%# GetAmount((int)Eval("Qty"),(int)Eval("Price")) %>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
