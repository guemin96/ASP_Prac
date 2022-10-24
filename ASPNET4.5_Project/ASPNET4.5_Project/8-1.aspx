<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="8-1.aspx.cs" Inherits="ASPNET4._5_Project._8_1" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html>

<script runat="server">
    protected void Page_Load(object sender,EventArgs e) {
        SqlConnection con = new SqlConnection("Server = localhost;database=MyDB; UID=sa;Pwd=1234;");
        string sql = "Select UserID, Password, Name, Phone From Member";
        SqlCommand cmd = new SqlCommand(sql, con);
        con.Open();
        SqlDataReader rd = cmd.ExecuteReader();

        while (rd.Read()) {
            Label1.Text += String.Format("{0},{1},{2},{3}<br/>", rd["UserID"], rd["Password"], rd["Name"], rd["Phone"]);
        }
        rd.Close();
        con.Close();
    }
</script>

<asp:Label ID="Label1" runat="server"></asp:Label>