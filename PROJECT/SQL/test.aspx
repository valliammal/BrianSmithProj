<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="SQL_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtSql" runat="server"></asp:TextBox><br />
        <asp:Button ID="BtnSubmit" runat="server" Text="Button" OnClick="BtnSubmit_Click" /><br />

        Select
         <asp:TextBox ID="txtSqlSelect" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnSelectSubmit" runat="server" Text="Button" OnClick="btnSelectSubmit_Click" /><br />

        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
