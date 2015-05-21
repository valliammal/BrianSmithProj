<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadImages.aspx.cs" Inherits="User_UploadImages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UploadImages</title>
    <script src="//code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function ShowpImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#ImgPrv').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
                <div align="center">
                    <asp:Image ID="ImgPrv" Height="150px" Width="240px" runat="server" /><br />
                    <asp:FileUpload ID="flupImage" runat="server" onchange="ShowpImagePreview(this);" />
                </div>
            
        </div>
    </form>
</body>
</html>
