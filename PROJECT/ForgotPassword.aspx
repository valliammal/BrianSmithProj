<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password User</title>
    <link href="css/style.css" type="text/css" rel="stylesheet" media="all" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="popup-c">


                <div class="log-had" style="">Forgot Password</div>

                <br />

                <br />

                <asp:TextBox ID="txtemail" runat="server" placeholder="Enter your registered email ID" CssClass="login-box"></asp:TextBox>


                <br />
                <div align="center" style="padding-top: 7px;">

                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btns" OnClick="btnSubmit_Click"></asp:Button>
                </div>
                <br />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
