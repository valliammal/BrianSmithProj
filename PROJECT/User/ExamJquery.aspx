<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamJquery.aspx.cs" Inherits="ExamJquery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Online_Exam</title>
    <link rel="shortcut icon" href="../images/Fav.ico" />
    <link href="StyleSheet.css" rel="stylesheet" media="all" type="text/css" />
    <script src="../js/jquery.min.js"></script>
    <style>
        .imgdiv {
            float: left;
            width: 210px;
        }
    </style>
</head>
<body onload="abc(chk01);">
    <form id="form1" runat="server">
        <div class="header">


            <div class="crate-view">
                <a href="QuestionUpload.aspx" class="LoginL">CREATE</a>

                <a href="Exam.aspx" class="LoginL">VIEW</a>

            </div>

            <div style="float: right; padding: 20px;">
                <asp:Image ID="imgprofile" runat="server" ImageUrl="~/images/profile.png" Visible="false" Height="15px" Width="15px" />
                <asp:Label ID="lblUserName" runat="server" Text="" CssClass="LoginR"></asp:Label>
                | <a href="../Index.aspx" class="LoginR">LOGOUT</a>

            </div>
        </div>
        <style>
            #viewQuestion {
                text-align: center;
                width: 40%;
                margin-left: 400px;
            }
        </style>
        <div id="viewQuestion">
        </div>


        <script type="text/javascript">
            //load language fom database
            $(document).ready(function () {
                var quesID;
                var getQID = [];
                var countID;

                $.ajax({
                    type: "POST",
                    url: "Exam.aspx/GetQuesID",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (DataQuestID) {

                        var objQuesID = $.parseJSON(DataQuestID.d);
                        countID = objQuesID.length;
                        for (var b = 0; b < objQuesID.length; b++) {

                            getQID[b] = objQuesID[b].Ques_ID;
                            countID = objQuesID.length;
                            $('#viewQuestion').append("<div id='ques" + getQID[b] + "'></div>");

                            var id = getQID[b];
                            getQuestion(id);
                            getAnswer(id);
                        }
                    }
                });

                function getQuestion(quesIdSingle) {

                    $.ajax({
                        type: "POST",
                        url: "Exam.aspx/GetQuestions",
                        data: "{'QuesID':'" + quesIdSingle + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {

                            var obj = $.parseJSON(data.d);
                            for (var i = 0; i < obj.length; i++) {
                                $("#ques" + quesIdSingle).append("<br /><div class='imgdiv' id='quesPicBox" + quesIdSingle + "'><img src=" + obj[i].PicPath + " alt='Pic' height='200px' width='200px' onclick='alert('Rohit')' style='border-radius:30px' /></div><br/>");
                                $("#quesPicBox" + quesIdSingle).append("<div id='quesValue" + quesIdSingle + "'><p id='box" + [i] + "' ><b>" + obj[i].Question + "</b></p></div><br />");
                                $("#ques" + quesIdSingle).append("<br /><div id='quesOption" + quesIdSingle + "' style='text-align:left;display: table;'></div><br style='clear:both;' /><br/>");



                            }

                        }
                    });
                };

                function getAnswer(quesIDSingle) {

                    $.ajax({
                        type: "POST",
                        url: "Exam.aspx/GetAnswers",
                        data: "{'QuestionID':'" + quesIDSingle + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (DataAns) {


                            var objAns = $.parseJSON(DataAns.d);

                            for (var j = 0; j < objAns.length; j++) {
                                var chkid = "chk" + j + quesIDSingle;
                                var imgid = j + quesIDSingle;
                                $("#quesOption" + quesIDSingle).append("<br /><input  type='radio' class='AnsOpt' id='" + j + quesIDSingle + "' name='" + quesIDSingle + "'  value='" + objAns[j].Answer + "' style=' float: left;' /><div style='width:100px; text-align: left;  float: left;'>" + objAns[j].Answer + "</div><img src='../img/Mic.png' width='40px' height='40px' onClick='PlaySound('" + objAns[j].Mp3_Name + "')' alt='Mic' style='cursor: pointer' title='click to play a sound' /> <img id='img" + j + quesIDSingle + "' src='../img/right.png' alt='Smiley' width='80' height='30'  style='float: left; margin-top: -14px; margin-left: 20px;'><br />");

                            }

                        }
                    });

                };

            });
        </script>

        <script>
            $(document).ready(function () {
                $(document).on("click", ".AnsOpt", function () {
                    var questID = $(this).attr('name');
                    var chkAnswer = $(this).val();

                    $.ajax({
                        type: "POST",
                        url: "Exam.aspx/GetOptions",
                        data: "{'Q_ID':'" + questID + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (DataOpt) {
                            var obj = $.parseJSON(DataOpt.d);
                            var answer = obj[0].Answer;
                            if (answer == chkAnswer) {
                                alert('This is right answer.');
                            }
                            else {
                                alert('Wrong Answer.');
                            }
                        }
                    });
                });
            });
        </script>



        <script type="text/javascript">
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
    </form>

</body>
</html>
