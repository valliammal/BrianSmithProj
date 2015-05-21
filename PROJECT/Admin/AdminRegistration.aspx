<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminRegistration.aspx.cs" Inherits="Admin_AdminRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Registration</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" media="all" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script lang="javascript" type="text/javascript" src="js/jquery.maskedinput.js"></script>
    <script lang="javascript" type="text/javascript" src="js/jquery.maskedinput.min.js"></script>
    <script>
        jQuery(function ($) {

            $("#txtcontact").mask("(999) 999-9999");


        });
    </script>
    <script>
        function ValidateAlpha(evt) {
            var keyCode = (evt.which) ? evt.which : evt.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32 && keyCode == 8 && keyCode == 46)

                return false;
            return true;
        }

        function isNumber(evt, phn) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            else {
                return true;

            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center" style="margin-top: 100px">
            <h1 style="color: #a8a0a0">Admin Registration</h1>
            <table style="border: thick solid #a8a0a0; border-spacing: 10px">
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="txtname" runat="server" onkeypress="return ValidateAlpha(event);"></asp:TextBox>

                    </td>

                </tr>

                <tr>
                    <td>Email ID</td>

                    <td>
                        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Confirm Password</td>
                    <td>
                        <asp:TextBox ID="txtcpwd" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToCompare="txtpwd" ControlToValidate="txtcpwd" ForeColor="Red"></asp:CompareValidator>

                    </td>
                </tr>


            </table>
            <br />
            <br />
            <div align="center">
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btns" OnClick="btnRegister_Click" />

                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btns" OnClick="btnClear_Click" />

                <asp:Button ID="bntLogin" runat="server" Text="Login" CssClass="btns" OnClick="bntLogin_Click" />

            </div>
        </div>
    </form>
</body>
</html>
