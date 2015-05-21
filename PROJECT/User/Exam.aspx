<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exam.aspx.cs" Inherits="Exam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online_Exam</title>
    <link rel="shortcut icon" href="../images/Fav.ico" />
    <link href="StyleSheet.css" rel="stylesheet" media="all" type="text/css" />
    <script src="../js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="crate-view">
                <a href="QuestionUpload.aspx" class="LoginL">CREATE</a>

                <a href="Exam.aspx" class="LoginL">VIEW</a>

            </div>

            <div id="divProfile">
                <asp:Image ID="imgprofile" runat="server" ImageUrl="~/images/profile.png" Visible="false" Height="15px" Width="15px" />
                <asp:Label ID="lblUserName" runat="server" Text="" CssClass="LoginR"></asp:Label>
                | <a href="../Index.aspx" class="LoginR">LOGOUT</a>

            </div>
        </div>
        <div align="center">
            <h1>Question List</h1>
        </div>
        <div id="questionBox">
            <br />
            <br />
            <div id="questionImage">
                <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" CssClass="imgRadius" />
                <br />
                <asp:Label ID="lblQues" runat="server" Font-Size="X-Large" Width="73%"></asp:Label>
                <br />
            </div>

            <div id="questionOption">
                <br />
                <br />

                <div id="soundImage1">
                    <asp:RadioButton ID="opt1" CssClass="opttext" runat="server" OnCheckedChanged="optWrong1_CheckedChanged" GroupName="a" />
                    <asp:Image ID="img1" CssClass="imgone" runat="server" onclick="PlaySound(lblSound2.textContent)" ImageUrl="~/img/Mic.png" Height="30px" Width="30px" Style="cursor: pointer" ToolTip="Click to play sound" />

                    <div class="imgRW" style="float: left;">
                        <asp:Image ID="imgMessage1" runat="server" ImageUrl="~/img/wrong.png" Height="30px" Width="80px" Visible="false" />
                    </div>
                </div>
                <div style="clear: both"></div>

                <div id="soundImage2">
                    <asp:RadioButton ID="opt2" CssClass="opttext" runat="server" OnCheckedChanged="optRight_CheckedChanged" GroupName="a" />
                    <asp:Image ID="img2" CssClass="imgone" runat="server" onclick="PlaySound(lblSound1.textContent)" ImageUrl="~/img/Mic.png" Style="cursor: pointer" Height="30px" Width="30px" ToolTip="Click to play sound" />

                    <div class="imgRW">
                        <asp:Image ID="imgMessage2" runat="server" ImageUrl="~/img/right.png" Height="30px" Width="80px" Visible="False" />
                    </div>
                </div>
                <div style="clear: both"></div>

                <div id="soundImage3">
                    <asp:RadioButton ID="opt3" CssClass="opttext" runat="server" OnCheckedChanged="optWrong2_CheckedChanged" GroupName="a" />
                    <asp:Image ID="img3" CssClass="imgone" runat="server" onclick="PlaySound(lblSound3.textContent)" Style="cursor: pointer" ImageUrl="~/img/Mic.png" Height="30px" Width="30px" ToolTip="Click to play sound" />

                    <div class="imgRW">
                        <asp:Image ID="imgMessage3" runat="server" ImageUrl="~/img/wrong.png" Height="30px" Width="80px" Visible="False" />
                    </div>
                </div>
                <div style="clear: both"></div>

                <div id="soundImage4">
                    <asp:RadioButton ID="opt4" CssClass="opttext" runat="server" OnCheckedChanged="optWrong3_CheckedChanged" GroupName="a" />
                    <asp:Image ID="img4" CssClass="imgone" runat="server" onclick="PlaySound(lblSound4.textContent)" Style="cursor: pointer" ImageUrl="~/img/Mic.png" Height="30px" Width="30px" ToolTip="Click to play sound" />

                    <div class="imgRW">
                        <asp:Image ID="imgMessage4" runat="server" ImageUrl="~/img/wrong.png" Height="30px" Width="80px" Visible="False" />
                    </div>
                </div>
                <div style="clear: both">
                    <br />
                    <br />
                </div>
                <div style="clear: both"></div>

                <div style="padding-left: 80px;">
                    <asp:Button ID="btnTryAgain" runat="server" Text="Try Again" CssClass="button-1" OnClick="btnTryAgain_Click" />

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="button-1" OnClick="btnNext_Click" />
                </div>
            </div>
            <div style="clear: both"></div>


        </div>
        <br />


        <script type="text/javascript">
            // This method is used to show the option that this is correct or not.
            // It is basically to check the options.
            $(document).ready(function () {
                $("input[type='radio']").change(function () {
                    var optParentTr = $(this).parent().parent().attr('id');
                    var optSelect = $(this).parent().find('label').text();
                    var quesID = $("#HideData").parent().find("#lblQuestionID").text();

                    $.ajax({
                        type: "POST",
                        url: "Exam.aspx/GetResult",
                        data: "{'QID':'" + quesID + "','option':'" + optSelect + "' }",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (DataOpt) {
                            var obj = $.parseJSON(DataOpt.d);
                            // var answer = obj[0].Status;
                            $(".imgRW").html("");
                            var answer = obj[0].Status;
                            if (answer == 'R') {

                                //alert('This is right answer.');
                                $("#" + optParentTr + " div.imgRW").append("<img src='../img/right.png' style=' float:left;  margin-left: 20px;' Height='30px' Width='80px'/>");
                                $("#" + optParentTr + " div.imgRW").append("<label style='width:auto;padding-left:10px;  line-height: 28px;'>" + obj[0].Answer_Detail + "</label>");
                            }
                            else {
                                // alert('Wrong Answer.');
                                $("#" + optParentTr + " div.imgRW").append("<img src='../img/wrong.png' style=' float:left; margin-left: 20px;' Height='30px' Width='80px'/>");
                                $("#" + optParentTr + " div.imgRW").append("<label style='width:auto;padding-left:10px;  line-height: 28px;'>" + obj[0].Answer_Detail + "</label>");

                            }


                        }
                    });
                });
            });

        </script>


        <script type="text/javascript">
            // This javascript code is used to play the sound online
            // when we click on an image
            var soundObject = null;
            function PlaySound(sound) {
                var mp3 = sound;
                if (soundObject != null) {
                    document.body.removeChild(soundObject);
                    soundObject.removed = true;
                    soundObject = null;
                }
                soundObject = document.createElement("embed");
                soundObject.setAttribute("src", mp3);
                soundObject.setAttribute("hidden", true);
                soundObject.setAttribute("autostart", true);
                document.body.appendChild(soundObject);
            }
        </script>
        <style>
            .lblFore {
                color: White;
            }
        </style>
        <div style="display: none" id="HideData">
            <asp:Label ID="lblSound1" runat="server" Text="" Visible="true" ClientIDMode="Static" CssClass="lblFore"></asp:Label>
            <asp:Label ID="lblSound2" runat="server" Text="" Visible="true" ClientIDMode="Static" CssClass="lblFore"></asp:Label>
            <asp:Label ID="lblSound3" runat="server" Text="" Visible="true" ClientIDMode="Static" CssClass="lblFore"></asp:Label>
            <asp:Label ID="lblSound4" runat="server" Text="" Visible="true" ClientIDMode="Static" CssClass="lblFore"></asp:Label>
            <asp:Label ID="lblQuestionID" runat="server" Text="" Visible="true" ClientIDMode="Static" CssClass="lblFore"></asp:Label>
        </div>


        <br />
        <div style="clear: both;"></div>

        



        <br />
        <br />

    </form>
</body>
</html>
