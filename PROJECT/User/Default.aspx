<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Home</title>
    <link rel="shortcut icon" href="../images/Fav.ico" />
    <link href="StyleSheet.css" rel="stylesheet" media="all" type="text/css" />
    <script src="../js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
                <div id="divProfile">
                    <asp:Image ID="imgprofile" runat="server" ImageUrl="~/images/profile.png" Visible="false" Height="15px" Width="15px" />
                    <asp:Label ID="lblUserName" runat="server" Text="" CssClass="LoginR"></asp:Label>
                    | <a href="../Index.aspx" class="LoginR">LOGOUT</a>

                </div>


            </div>
            <div align="center" style="padding-top: 50px">
                <div align="left" style="margin-left: 350px">
                    <%-- <asp:DropDownList ID="ddlSyllabus" runat="server" CssClass="ddlSyl" ClientIDMode="Static">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem>English</asp:ListItem>
                    </asp:DropDownList>--%>
                    <h3>
                        <asp:Label ID="lblSyllabus" runat="server" Text="English"></asp:Label></h3>
                  
                </div>
                <div id="Ques" class="divDefault">

                    <a href="Home.aspx" style="text-decoration: none;">
                        <%-- <p>» English & Old English (Anglo-Saxon)</p>
                        <p>» Writing system, phonology, phonetics of standard English</p>
                        <p>» Etymology of standard English</p>
                        <p>» Dictionaries of standard English</p>
                        <p>» No longer used—formerly English thesauruses</p>
                        <p>» Grammar of standard English</p>
                        <p>» No longer used—formerly English prosodies</p>
                        <p>» Historical & geographical variations, modern nongeographic variations of English</p>
                        <p>» Standard English usage (Prescriptive linguistics)</p>
                        <p>» Old English (Anglo-Saxon)</p>--%>
                    </a>
                </div>

            </div>
            <script type="text/javascript">

                //load syllabus fom database
                $(document).ready(function () {
                    // $("#ddlSyllabus").change(function () {
                    var syllabusName = $("#lblSyllabus").text();

                    $.ajax({
                        type: "POST",
                        url: "Default.aspx/GetSyllabus",
                        data: "{'syllabus':'" + syllabusName + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            $("#Ques").children().remove();
                            var obj = $.parseJSON(data.d);
                            for (var i = 0; i < obj.length; i++)
                                $('#Ques').append("<p id='Syllabus_" + [i] + "'><a href='Exam.aspx' style='text-decoration: none;'> " + obj[i].Syllabus_Detail + "</a></p>");
                        }
                    });
                });



            </script>

        </div>
    </form>
</body>
</html>
