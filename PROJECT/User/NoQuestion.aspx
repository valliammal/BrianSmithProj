<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NoQuestion.aspx.cs" Inherits="User_NoQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" href="../images/Fav.ico" />
    <link href="StyleSheet.css" rel="stylesheet" media="all" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">

            <div class="crate-view">
                <a href="QuestionUpload.aspx" class="LoginL">CREATE</a>
                <a href="Exam.aspx" class="LoginL">VIEW</a>
            </div>
            <div id="divProfile">
                <asp:Image ID="imgprofile" runat="server" ImageUrl="~/images/profile.png" Visible="false" Height="15px" Width="15px" />
                <asp:Label ID="lblUserName" runat="server" Text="" CssClass="LoginR"></asp:Label>
                | <a href="../Index.aspx" class="LoginR">LOGOUT</a>
            </div>
        </div>
        <div style="text-align: center; margin: 100px;">
            <img src="../images/NoQu.jpg" alt="No Question Available" height="20%" width="40%" />
        </div>
    </form>
</body>
</html>
