<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Profession.aspx.cs" Inherits="Profession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                <img src="images/Untitled-2.png" /></span>
        </div>

        <div class="box1">

            <div class="img">
                <a href="Privacy.aspx" class="opct">
                    <img src="images/img2.png" alt="Privacy" /></a>
            </div>
            <p>Privacy</p>
        </div>
        <div class="box1">
            <span>
                <br />
                <br />
                <br />
                <img src="images/Untitled-2.png" /></span>
        </div>


        <div class="box1">

            <div class="img">
                <a href="SmsText.aspx" class="opct">
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
                <img src="images/Untitled-2.png" /></span>
        </div>


        <div class="box1">

            <div class="img">
                <a href="Address.aspx" class="opct">
                    <img src="images/img4.png" /></a>
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
                    <img src="images/img5.png" /></a>
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
                <img src="images/Untitled-2.png" /></span>
        </div>

        <div class="box1">

            <div class="img">
                <a href="Industry.aspx" class="opct">
                    <img src="images/img6.png" /></a>
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
                <a href="Profession.aspx">
                    <img src="images/img7.png" /></a>
            </div>
            <p>
                Profession<br>
                (Optional)
            </p>
        </div>

        <br style="clear: both;">
    </div>






    <div class="">

        <br />

        <div style="margin-left: 250px">
            <p style="width: 100%; text-align: center; padding-right: 0px">
                <span style="margin-left: 70px;">Select Your Profession </span>
                <span style="margin-left: 80px;">Country :-</span>
                <asp:DropDownList ID="ddlSelectProf" runat="server" OnSelectedIndexChanged="ddlSelectProf_SelectedIndexChanged" ClientIDMode="Static">
                    <asp:ListItem>------Select Country------</asp:ListItem>
                    <asp:ListItem>UK</asp:ListItem>
                    <asp:ListItem>USA</asp:ListItem>
                    <asp:ListItem>India</asp:ListItem>
                </asp:DropDownList>

            </p>

            <script type="text/javascript">

                //load profession fom database
                $(document).ready(function () {

                    $("#ddlSelectProf").change(function () {
                        var selectCountry = $("#ddlSelectProf").val();


                        $.ajax({
                            type: "POST",
                            url: "Profession.aspx/jsonstring",
                            data: "{'country':'" + selectCountry + "'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                $("#RightDiv").children().remove();
                                var obj = $.parseJSON(data.d);
                                for (var i = 0; i < obj.length; i++) {
                                    $("#RightDiv").append("<p id='box" + [i] + "' class='draggable-item'>" + obj[i].Prof_Name + "</p>");


                                }
                            }

                        });
                    });

                });

            </script>

            <div align="right" style="width: 855px">
            </div>
            <br />
            <span class="divSpanProfLeft">Association in which I am qualified  </span>
            <span class="divSpanProfCenter">Association which I am learning</span>
            <span class="divSpanProfRight">List of all Associations</span>
            <br />
            <br />
            <div class="container">

                <div id="LeftDiv" class="draggable-list" style="overflow: scroll; float: left;">
                </div>

                <div id="CenterDiv" class="draggable-list" style="overflow: scroll; float: left; margin-left: 20px;">
                </div>

                <div id="RightDiv" class="draggable-list" style="overflow: scroll; float: left; margin-left: 20px;">
                </div>
            </div>



            <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
            <script src="http://code.jquery.com/ui/1.8.24/jquery-ui.min.js" type="text/javascript"></script>

            <script type="text/javascript">
                $(document).ready(function () {
                    $('.container .draggable-list').sortable({
                        connectWith: '.container .draggable-list'
                    });
                });

            </script>


        </div>
        <br style="clear: both;" />
        <br />
        <div id="divHobbiesButton">
            <asp:Button ID="btnSubmit" runat="server" Text="Proceed" CssClass="btn btnMargin" OnClick="btnSubmit_Click" CausesValidation="False"></asp:Button>
            <br />

            <br />
            <asp:Button ID="btnSkip" runat="server" Text="Skip" CssClass="btn" OnClick="btnSkip_Click" CausesValidation="False"></asp:Button>

        </div>
        <br style="clear: both;" />
    </div>

</asp:Content>

