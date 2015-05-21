<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateSQL.aspx.cs" Inherits="SQL_UpdateTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/style.css" media="all" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center; vertical-align: middle; margin-top: 50px">


            <asp:Button ID="btnFire" runat="server" Text="Fire All commands" CssClass="btn" ToolTip="Create Database and tables" OnClick="btnFire_Click" />
            <br />
            <br />
            <asp:Button ID="btnShow" runat="server" Text="Show Language" CssClass="btn" ToolTip="Show all tables" OnClick="btnShow_Click" />
            <asp:Button ID="btnShowC" runat="server" Text="Show Country" CssClass="btn" ToolTip="Show all tables" OnClick="btnShowC_Click" />

        </div>

        <br />
        <br />

        <div id="data">
            <table>
                <tr>
                    <td valign="top">
                        <div style="overflow: scroll;">
                            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                        </div>
                    </td>
                    <td>
                        <div style="overflow: scroll; height: 300px">
                            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

        <br />
        <br />
        <asp:Label ID="lble1" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="lble2" runat="server" Text="" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>

