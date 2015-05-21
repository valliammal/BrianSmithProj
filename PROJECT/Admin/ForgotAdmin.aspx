<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotAdmin.aspx.cs" Inherits="Admin_ForgotAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Forgot Password Admin</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" media="all" />
</head>
<body>

    <form id="form1" runat="server">




        <div class="" style="">

            <div class="popup-c">


                <div class="log-had" style="">Forgot Passowrd</div>

                <br />

                <br />

                <asp:TextBox ID="txtuser" runat="server" CssClass="login-box" placeholder="Enter your username"></asp:TextBox>

                <br />

                <asp:TextBox ID="txtemail" runat="server" CssClass="login-box" placeholder="Enter your registered email ID"></asp:TextBox>




                <div align="center" style="padding-top: 7px;">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btns" OnClick="btnLogin_Click"></asp:Button>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btns" OnClick="btnSubmit_Click"></asp:Button>

                </div>


                <br />
                <asp:Label ID="lblerr" runat="server" Text="" ForeColor="Red"></asp:Label>
                <br />
            </div>
        </div>
    </form>
</body>

</html>
