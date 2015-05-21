<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Privacy.aspx.cs" Inherits="Privacy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <%--  <script src="http://code.jquery.com/jquery-1.8.0.min.js"></script>--%>
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
                <br />
                <br />
                <br />
                <img src="images/Untitled-2.png"></span>
        </div>

        <div class="box1">

            <div class="img">
                <a href="Privacy.aspx">
                    <img src="images/img2.png"></a>
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

        <div class="l-2">
            <br />
            <br />
            <br />
            <br />
            Please Select our privacy level
        </div>
        <div class="l-1">
            <div>
                <div class="divLeftPrivacy">
                    <img id="img1" class="imgPrivacy" src="images/imgPublicSearch.png" alt="Public Searchable & Contactable" height="100px" width="100px" title="Public Searchable" />
                </div>
                <div class="divLeftMarginPrivacy">
                    <img id="img2" class="imgPrivacy" src="images/imgMedium.png" alt="Medium" height="100px" width="100px" title="Medium" />
                </div>
            </div>
            <div>
                <div class="divLeftPrivacy">
                    <img id="img3" class="imgPrivacy" src="images/imgPrivate.png" alt="Private" height="100px" width="100px" title="Private" />
                </div>
                <div class="divRightPrivacy">
                    <img id="img4" class="imgPrivacy" src="images/imgPublic.png" alt="Public Searchable" height="100px" width="100px" title="Public Searchable & Contactable" />
                </div>
            </div>
            <script type="text/javascript">
                $(document).ready(function () {
                    //$("#img1").click(function () {
                    //    $(this).animate({
                    //        'height': '+=100px',
                    //        'width':'-=25px'
                    //    }, 1000, function () {
                    //        $("#img2").animate({
                    //            'width':'-=20px'
                    //        },1000);
                    //    });
                    //});
                    $("#img1").click(function () {
                        $("#img1").css({ "outline": "2px solid #d533c6" });
                        $("#img1").css({ "opacity": "1.0" });
                        $("#img2").css({ "outline": "" });
                        $("#img2").css({ "opacity": "" });
                        $("#img3").css({ "outline": "" });
                        $("#img3").css({ "opacity": "" });
                        $("#img4").css({ "outline": "" });
                        $("#img4").css({ "opacity": "" });
                    });
                    $("#img2").click(function () {
                        $("#img2").css({ "outline": "2px solid #d533c6" });
                        $("#img2").css({ "opacity": "1.0" });
                        $("#img3").css({ "outline": "" });
                        $("#img3").css({ "opacity": "" });
                        $("#img4").css({ "outline": "" });
                        $("#img4").css({ "opacity": "" });
                        $("#img1").css({ "outline": "" });
                        $("#img1").css({ "opacity": "" });
                    });
                    $("#img3").click(function () {
                        $("#img3").css({ "outline": "2px solid #d533c6" });
                        $("#img3").css({ "opacity": "1.0" });
                        $("#img4").css({ "outline": "" });
                        $("#img4").css({ "opacity": "" });
                        $("#img1").css({ "outline": "" });
                        $("#img1").css({ "opacity": "" });
                        $("#img2").css({ "outline": "" });
                        $("#img2").css({ "opacity": "" });
                    });
                    $("#img4").click(function () {
                        $("#img4").css({ "outline": "2px solid #d533c6" });
                        $("#img4").css({ "opacity": "1.0" });
                        $("#img1").css({ "outline": "" });
                        $("#img1").css({ "opacity": "" });
                        $("#img2").css({ "outline": "" });
                        $("#img2").css({ "opacity": "" });
                        $("#img3").css({ "outline": "" });
                        $("#img3").css({ "opacity": "" });
                    });
                });
            </script>

        </div>


        <div class="l-3" style="text-align: right">
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnproceed" runat="server" Text="Proceed" CssClass="btn" OnClick="btnproceed_Click" CausesValidation="False" />

        </div>



        <br style="clear: both;">
    </div>


</asp:Content>

