<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="15-1_ChangePassword.aspx.cs" Inherits="Chap15.Secured._15_1_ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ChangePassword ID="ChangePassword1" runat="server" 
        ContinueDestinationPageUrl="~/15-1_Default.aspx"
        CancelDestinationPageUrl="~/15-1_Default.aspx">

    </asp:ChangePassword>
</asp:Content>
