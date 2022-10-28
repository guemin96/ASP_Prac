<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="22-28.aspx.cs" Inherits="Chap22._22_28" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px"
                AutoGenerateRows="False" DataKeyNames="UserID" 
                DataSourceID="EntityDataSource1">
                <Fields>
                    <asp:BoundField DataField="UserID" HeaderText="UserID"
                         ReadOnly="true" SortExpression="UserID" />
                    <asp:BoundField DataField="Password" HeaderText="Password"
                         SortExpression="Password" />
                    <asp:BoundField DataField="Name" HeaderText="Name"
                         SortExpression="Name" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone"
                         SortExpression="Phone" />
                    <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" ShowInsertButton="true" />
                </Fields>
            </asp:DetailsView>
            <asp:EntityDataSource runat="server" ID="EntityDataSource1" 
                DefaultContainerName="MyDBEntities1" ConnectionString="name=MyDBEntities1" 
                EnableFlattening="False" EnableDelete="True" EnableInsert="True" EnableUpdate="True" 
                EntitySetName="Members"></asp:EntityDataSource>
        </div>
    </form>
</body>
</html>
