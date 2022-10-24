<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="8-20.aspx.cs" Inherits="ASPNET4._5_Project._8_20" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListView1" runat="server">
                <LayoutTemplate>
                    <table border="1">
                        <tr>
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
            </asp:ListView>
            <asp:DataPager ID="DataPager1" runat="server" PageSize="2" PagedControlID="ListView1" OnPreRender="DataPager1_PreRender">
                <Fields>
                    <asp:TemplatePagerField>
                        <PagerTemplate>
                            <%# Container.TotalRowCount>0 ?(Container.StartRowIndex/Container.PageSize) + 1 : 0 %> Page(총 <%# Container.TotalRowCount %>회원)
                        </PagerTemplate>
                    </asp:TemplatePagerField>
                    <asp:NextPreviousPagerField ShowPreviousPageButton ="true" ShowNextPageButton ="false" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowPreviousPageButton="false" ShowNextPageButton="true" />
                </Fields>
            </asp:DataPager>
        </div>
    </form>
</body>
</html>
