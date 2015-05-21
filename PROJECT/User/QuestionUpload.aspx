<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuestionUpload.aspx.cs" Inherits="QuestionUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create</title>
    <link rel="shortcut icon" href="../images/Fav.ico" />
    <link href="StyleSheet.css" rel="stylesheet" media="all" type="text/css" />

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
            <asp:Label ID="lblResponse" runat="server" Text="" ForeColor="Green"></asp:Label>
        </div>
        <div class="divQuestionUpload" align="center">
            <br />
            <span valign="top" style="font-size: 20px">Question :</span>

            <asp:TextBox ID="txtQues" runat="server" CssClass="txtbox" Width="300px" Height="30px" Font-Bold="False" Font-Size="20px"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQues" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>



            <br />
            <br />
            <div id="divImageUpload">


                <asp:Image ID="Img1" runat="server" Height="200px" Width="200px" CssClass="imgRadius" ImageUrl="~/img/nopic.png" />

                <br />
                <label>Preferred size is 200 X 200 pixel</label><br />
                <br />
                <br />

                <div>
                    Image :
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="180px" onchange="ShowpImagePreview(this);" />
                </div>
                <br />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="button-1" ToolTip="Click to upload image" OnClick="btnUpload_Click" Visible="false" />
                <br />
                <%-- This code is used to show an image when click on OK button of dialog box.--%>
                <script src="//code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
                <script type="text/javascript">
                    function ShowpImagePreview(input) {
                        if (input.files && input.files[0]) {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $('#Img1').attr('src', e.target.result);
                            }
                            reader.readAsDataURL(input.files[0]);
                        }
                    }
                </script>
            </div>

            <div style="clear: both;"></div>
            <br />

            <div id="divQuestion">
                <div>
                    Correct &nbsp;&nbsp;&nbsp;&nbsp;:
                    
                        <asp:TextBox ID="txtRight" runat="server" CssClass="txtbox"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Description : 
                    
                        <asp:TextBox ID="txtRightDetail" runat="server" CssClass="txtbox"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Mp3 :
                    <asp:FileUpload ID="FileUploadMp3Right" runat="server" /><br />
                    <asp:Label ID="lblUploadMsg1" runat="server" ForeColor="Red"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRight" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </div>
                <br />

                <div>
                    Distractor  :
                        <asp:TextBox ID="txtW1" runat="server" CssClass="txtbox"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Description :
                        <asp:TextBox ID="txtDistractor1" runat="server" CssClass="txtbox"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Mp3 :
                        <asp:FileUpload ID="FileUploadMp3Wrong1" runat="server" /><br />
                    <asp:Label ID="lblUploadMsg2" runat="server" ForeColor="Red"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtW1" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>


                <br />
                <div>
                    Distractor :
               
                    <asp:TextBox ID="txtW2" runat="server" CssClass="txtbox"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               Description :
              
                    <asp:TextBox ID="txtDistractor2" runat="server" CssClass="txtbox"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Mp3 : 
                
                    <asp:FileUpload ID="FileUploadMp3Wrong2" runat="server" /><br />
                    <asp:Label ID="lblUploadMsg3" runat="server" ForeColor="Red"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtW2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </div>

                <br />
                <div>
                    Distractor :
                
                <asp:TextBox ID="txtW3" runat="server" CssClass="txtbox"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Description : 
                    <asp:TextBox ID="txtDistractor3" runat="server" CssClass="txtbox"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Mp3 : 
                    <asp:FileUpload ID="FileUploadMp3Wrong3" runat="server" /><br />
                    <asp:Label ID="lblUploadMsg4" runat="server" ForeColor="Red"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtW3" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>

                </div>


            </div>

            <div align="center">
                <asp:Button ID="btnSave" runat="server" Text="Upload" CssClass="button-1" OnClick="btnSave_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="button-1" OnClick="btnClear_Click" />
                <br />
                <br />
                <asp:HyperLink ID="HyperExam" runat="server" NavigateUrl="~/User/Exam.aspx">Exam</asp:HyperLink>

            </div>
    </form>
</body>
</html>
