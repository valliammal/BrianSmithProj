<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Manage</title>
    <link rel="shortcut icon" href="../images/Fav.ico" />
    <link href="StyleSheet.css" rel="stylesheet" media="all" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">

            <div class="crate-view">
                <a href="QuestionUpload.aspx" class="LoginL">CREATE</a>

                <a href="Exam.aspx" class="LoginL">VIEW</a></td>

            </div>

            <div style="float: right; padding: 20px;">
                <asp:Image ID="imgprofile" runat="server" ImageUrl="~/images/profile.png" Visible="false" Height="15px" Width="15px" />
                <asp:Label ID="lblUserName" runat="server" Text="" CssClass="LoginR"></asp:Label>
                | <a href="../Index.aspx" class="LoginR">LOGOUT</a>

            </div>


        </div>

    </form>
</body>
</html>
