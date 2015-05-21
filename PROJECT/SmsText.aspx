<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="SmsText.aspx.cs" Inherits="SmsText" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script lang="javascript" type="text/javascript" src="js/jquery.maskedinput.js"></script>
    <script lang="javascript" type="text/javascript" src="js/jquery.maskedinput.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.3.14/angular.min.js"></script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="man-div">
        <div class="box1">

            <div class="img">
                <a href="Language.aspx" class="opct">
                    <img src="images/img1.png" alt="Language"></a>
            </div>
            <p>Language</p>
        </div>
        <div class="box1">
            <span>
                <br />
                <br />
                <br />
                <img src="images/Untitled-2.png"></span>
        </div>

        <div class="box1">

            <div class="img">
                <a href="Privacy.aspx" class="opct">
                    <img src="images/img2.png" alt="Privacy"></a>
            </div>
            <p>Privacy</p>
        </div>
        <div class="box1">
            <span>
                <br />
                <br />
                <br />
                <img src="images/Untitled-2.png"></span>
        </div>


        <div class="box1">

            <div class="img">
                <a href="SmsText.aspx">
                    <img src="images/img3.png"></a>
            </div>
            <p>
                SMS/Text Authentication<br>
                (Optional)

            </p>
        </div>
        <div class="box1">
            <span>
                <br />
                <br />
                <br />
                <img src="images/Untitled-2.png"></span>
        </div>


        <div class="box1">

            <div class="img">
                <a href="Address.aspx" class="opct">
                    <img src="images/img4.png"></a>
            </div>
            <p>
                Addresses<br>
                (Optional)
            </p>
        </div>
        <div class="box1">
            <span>
                <br />
                <br />
                <br />
                <img src="images/Untitled-2.png"></span>
        </div>

        <div class="box1">

            <div class="img">
                <a href="Hobbies.aspx" class="opct">
                    <img src="images/img5.png"></a>
            </div>
            <p>
                Hobbies<br>
                (Optional)
            </p>
        </div>

        <div class="box1">
            <span>
                <br />
                <br />
                <br />
                <img src="images/Untitled-2.png"></span>
        </div>

        <div class="box1">

            <div class="img">
                <a href="Industry.aspx" class="opct">
                    <img src="images/img6.png"></a>
            </div>
            <p>
                Industry<br>
                (Optional)
            </p>
        </div>
        <div class="box1">
            <span>
                <br />
                <br />
                <br />
                <img src="images/Untitled-2.png"></span>
        </div>

        <div class="box1">

            <div class="img">
                <a href="Profession.aspx" class="opct">
                    <img src="images/img7.png"></a>
            </div>
            <p>
                Profession<br>
                (Optional)
            </p>
        </div>

        <br style="clear: both;">
    </div>






    <div class="action-div">

        <br />
        <br />


        <br />


        <div class="l-2">
            Please enter your number for the authentication.
                   <br />
            We will not share your number anywhere.
        </div>
        <div class="l-1" style="margin-left: 10px;">

            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="s-lan-c" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
            </asp:DropDownList>
            <br />

            <br />

            <asp:TextBox ID="txtCode" runat="server" CssClass="DdlCode" placeholder="Code" Enabled="False" ClientIDMode="Static"></asp:TextBox>
            <asp:TextBox ID="txtMobileNo" ClientIDMode="Static" runat="server" CssClass="DdlMobile" placeholder="Enter your mobile number"></asp:TextBox>

            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCombinedMobile" runat="server" CssClass="DdlMobileCom" Enabled="false" ClientIDMode="static"></asp:TextBox>

        </div>

        <script type="text/javascript">
            $(document).ready(function () {
                $("#txtCombinedMobile").val($("#txtCode").val());

                $("#txtMobileNo").keyup(function () {
                    var contactNo = "", tempString = "", k = 0;
                    var textMobile = $("#txtMobileNo").val();


                    contactNo = $("#txtCode").val();
                    var mobileStr = textMobile.replace(/[\D.]/g, '');

                    if (mobileStr.substr(0, 1) == "0") {
                        contactNo += mobileStr.substr(1);
                        $("#txtCombinedMobile").val(contactNo);
                    }
                    else {
                        contactNo += mobileStr.substr(0);
                        $("#txtCombinedMobile").val(contactNo);
                    }




                });
            });

        </script>



        <div class="l-3" align="right">
            <asp:Button ID="btnSubmit" runat="server" Text="Proceed" CssClass="btn" CausesValidation="False" />

            <br />
            <br />

            <asp:Button ID="btnSkip" runat="server" Text="Skip" CssClass="btnSkip" OnClick="btnSkip_Click" CausesValidation="False" />

        </div>

        <div align="center">
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <br style="clear: both;">
    </div>
</asp:Content>

