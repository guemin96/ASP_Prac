<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.Master"%>

<script runat="server">

    protected void Button1_Click(object sender, EventArgs e) {
        Label masterLabel = (Label)Master.FindControl("Label1");
        masterLabel.Text = "콘텐츠 페이지에서 수정함";
    }
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_Click"/>
</asp:Content>
