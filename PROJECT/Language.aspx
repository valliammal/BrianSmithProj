<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Language.aspx.cs" Inherits="Language" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="man-div">
        <div class="box1">

            <div class="img">
                <a href="Language.aspx">
                    <img src="images/img1.png"></a>
            </div>
            <p>Language</p>
        </div>
        <div class="box1">
            <span>
               <br/>
               <br/>
               <br/>
                <img src="images/Untitled-2.png" /></span>
        </div>

        <div class="box1">

            <div class="img">
                <a href="Privacy.aspx" class="opct">
                    <img src="images/img2.png"></a>
            </div>
            <p>Privacy</p>
        </div>
        <div class="box1">
            <span>
               <br/>
               <br/>
               <br/>
                <img src="images/Untitled-2.png"></span>
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
               <br/>
               <br/>
               <br/>
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
               <br/>
               <br/>
               <br/>
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
               <br/>
               <br/>
               <br/>
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
               <br/>
               <br/>
               <br/>
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



    <script type="text/javascript">

        //load language fom database
        $(document).ready(function () {


            $.ajax({
                type: "POST",
                url: "Language.aspx/jsonstring",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    var obj = $.parseJSON(data.d);

                    for (var i = 0; i < obj.length; i++) {
                        $('#RightDiv').append("<p id='box" + [i] + "'class='draggable-item'>" + obj[i].Lang_Name + "</p>");
                    }
                }
            });
        });

    </script>
    <div class="action-div" style="width: 70%;">

        <p>Please drag the Language that you like from the right column over to the left.</p>

        <br />

        <div style="float: left; margin-left:90px;">

            <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
            <script src="http://code.jquery.com/ui/1.8.24/jquery-ui.min.js" type="text/javascript"></script>


            <script type="text/javascript">
                $(document).ready(function () {
                    $('.container .draggable-list').sortable({
                        connectWith: '.container .draggable-list'
                    });
                });

            </script>
            <style>
                .container {
                    width: 600px;
                    height: auto;
                    border: 0px solid #003366;
                }

                .draggable-list {
                    background: #fff;
                    list-style: none;
                    border: 1px solid #ccc;
                    margin: 0;
                    width: 250px;
                    height: 180px;
                    padding: 10px;
                    overflow: scroll;
                }

                .draggable-item {
                    font-family: Arial;
                    font-weight: normal;
                    cursor: move;
                    display: block;
                    color: #444;
                    margin: 5px;
                }
            </style>


            <div class="container">
                <div class="draggable-list" id="LeftDiv" style="float: left;">
                </div>



                <div class="draggable-list" id="RightDiv" style="float: right">
                </div>

                <br style="clear: both" />
            </div>


















            


        </div>


        <div class="l-33" style="float: left;">
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Proceed" CssClass="btn" CausesValidation="False" OnClick="btnSubmit_Click" />

        </div>
    </div>

</asp:Content>

