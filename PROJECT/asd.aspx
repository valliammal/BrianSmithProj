<%@ Page Language="C#" AutoEventWireup="true" CodeFile="asd.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script lang="javascript" type="text/javascript" src="js/jquery.maskedinput.js"></script>
    <script lang="javascript" type="text/javascript" src="js/jquery.maskedinput.min.js"></script>
    <script type="text/javascript">
        jQuery(function ($) {

            $("#txtmobile").mask("(999) 999-9999");

        });
    </script>

    <%--<script type="text/javascript">

        $(document).ready(function () {

            $.ajax({
                type: "POST",
                url: "asd.aspx/GetData1",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    alert(data.d);
                }
            });

        });
    </script>--%>


    <script type="text/javascript">

        $(document).ready(function () {

            $.ajax({
                type: "POST",
                url: "asd.aspx/GetData",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response($.map(data.d, function (item) {
                        var rows = "<p>" + item.LangName + "</p>";
                        $('#mydiv').append(rows);
                    }))
                }
            });

        });





    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="myList" runat="server" Height="200px" Width="200px">
                <asp:ListItem>cat</asp:ListItem>
                <asp:ListItem>dog</asp:ListItem>
                <asp:ListItem>lion</asp:ListItem>
                <asp:ListItem>elephant</asp:ListItem>
                <asp:ListItem>tiger</asp:ListItem>
                <asp:ListItem>Cow</asp:ListItem>
                <asp:ListItem>Ox</asp:ListItem>
            </asp:ListBox>
            <br />
            <br />
            <asp:Button ID="btnOk" runat="server" Text="Button" OnClick="btnOk_Click" />
            <br />
            <br />
            <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
            <br />
            <br />


            <div style="border-color: purple; border-radius: 30px; border-style: dotted; width: 300px">
                <%--<object type="application/x-shockwave-flash" data="dewplayer-vol.swf?mp3=User/Option/Ans_11.mp3"
                    width="240" height="20" id="dewplayer">
                    <param name="wmode" value="transparent" />
                    <param name="movie" value="dewplayer-vol.swf?mp3=mp3/test1.mp3" />
                </object>--%>

                <audio controls="controls" style="width: 45px">
                    <source src="Slider/img/Sound.mp3" type="audio/mp3" />
                    <source src="Slider/img/Sound.mp3" type="audio/ogg" />
                </audio>

            </div>
            <br />


            <div id="mydiv" style="border: solid; border-color: red; width: 50%; height: 300px" align="center">
                <p>Rohit Choudhary</p>
            </div>
        </div>





    </form>
</body>
</html>
