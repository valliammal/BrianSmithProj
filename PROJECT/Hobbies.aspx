<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Hobbies.aspx.cs" Inherits="Hobbies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="man-div">
        <div class="box1">

            <div class="img">
                <a href="Language.aspx" class="opct">
                    <img src="images/img1.png"></a>
            </div>
            <p>Language</p>
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
                <a href="Hobbies.aspx">
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
                <br />
                <br />
                <br />
                <img src="images/Untitled-2.png" /></span>
        </div>

        <div class="box1">

            <div class="img">
                <a href="Profession.aspx" class="opct">
                    <img src="images/img7.png" /></a>
            </div>
            <p>
                Profession<br />
                (Optional)
            </p>
        </div>

        <br style="clear: both;" />
    </div>



    <script type="text/javascript">

        //load hobbies fom database
        $(document).ready(function () {


            $.ajax({
                type: "POST",
                url: "Hobbies.aspx/jsonstring",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {

                    var obj = $.parseJSON(data.d);

                    for (var i = 0; i < obj.length; i++) {
                        //       alert(obj[i].Lang_Name);
                        $('#RightDiv').append("<p id='box" + [i] + "' class='draggable-item'>" + obj[i].Hobby_Name + "</p>");


                    }
                }

            });
        });

    </script>



    <div class="">

        <br />
        <style>
            
        </style>
        <div id="divMainHobbyIndustry">
            <p id="divHobbyIndustryP">Select Your Hobby</p>
            <br />

            <br />

            <span class="divHobbySpanLeft">I am in proficient</span>
            <span class="divHobbySpanCenter">I would like to learn</span>
            <span class="divHobbySpanRight">List of all Hobbies</span>
            <br />
            <br />
            <div class="container">

                <div id="LeftDiv" class="draggable-list" style="overflow: scroll; scroll; float: left;">
                </div>

                <div id="CenterDiv" class="draggable-list" style="overflow: scroll; scroll; float: left; margin-left: 20px;">
                </div>

                <div id="RightDiv" class="draggable-list" style="overflow: scroll; scroll; float: left; margin-left: 20px;">
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

