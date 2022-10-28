<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="15-1_PasswordRecovery.aspx.cs" Inherits="Chap15._15_1_PasswordRecovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
        <MailDefinition Subject="암호 찾기 결과입니다."></MailDefinition>
    </asp:PasswordRecovery>
</asp:Content>
