<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Admin_Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Admin</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" media="all" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="" style="">

            <div class="popup-c" height="500px">


                <div class="log-had" style="" height="500px">Login</div>

                <br />

                <br />

                <asp:TextBox ID="txtuser" runat="server" CssClass="login-box" placeholder="abc@xyz.com"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtuser"> </asp:RequiredFieldValidator>
                <br />

                <asp:TextBox ID="txtpwd" runat="server" CssClass="login-box" placeholder="Password" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" CssClass="reqField" ForeColor="Red" ControlToValidate="txtpwd"> </asp:RequiredFieldValidator><br />


                <asp:HyperLink ID="HyperLink1" runat="server" ToolTip="Click to retrieve password" NavigateUrl="~/Admin/ForgotAdmin.aspx">Forgot Password</asp:HyperLink>
                <br />
                <br />
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />

                <br /><br /><br />
                <%--
                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                <br />--%>
            </div>
        </div>


    </form>
</body>
</html>
