<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="8-2.aspx.cs" Inherits="ASPNET4._5_Project._8_2" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <script runat="server">
// protected void Button1_Click(object sender, EventArgs e) {
//    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString);
//    string sql = "SELECT UserID,Password,Name,Phone From Member Where UserID = @UserID";
//    SqlCommand cmd = new SqlCommand(sql, con);
//    cmd.Parameters.AddWithValue("@UserID", TextBox1.Text);

//    con.Open();

//    SqlDataReader rd = cmd.ExecuteReader();

//    if (rd.Read()) {
//        Label1.Text += String.Format("{0},{1},{2},{3}<br/>", rd["UserID"], rd["Password"], rd["Name"], rd["Phone"]);
//    }

//    rd.Close();
//    con.Close();

//}

    </script>
    <form runat="server">
         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="조회" OnClick="Button1_Click" />
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
   


</body>
</html>
