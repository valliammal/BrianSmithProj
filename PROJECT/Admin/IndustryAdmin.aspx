<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IndustryAdmin.aspx.cs" Inherits="Admin_IndustryAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Industry(Admin)</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" media="all" />
    <script>
        function ValidateAlpha(evt) {
            var keyCode = (evt.which) ? evt.which : evt.keyCode
            if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32)

                return false;
            return true;
        }
    </script>
    <style>
        .header {
            width: 100%;
            height: 60px;
            border: 0px solid;
            box-shadow: 0px 0px 40px #ccc;
            margin-bottom: 40px;
            background: #fff;
        }

        ul.menu-admin li {
            float: left;
            margin-left: 0px;
            margin-top: 20px;
            list-style: none;
        }

            ul.menu-admin li a:hover {
                background: #ff910e;
                color: #fff;
            }

            ul.menu-admin li a {
                text-decoration: none;
                padding: 10px 20px;
                color: #000;
                background:;
            }

        .admin-text {
            float: right;
            font-weight: bold;
            font-size: 20px;
            padding: 20px;
        }

            .admin-text:hover {
                color: orange;
            }
    </style>

</head>
<body>
    <div class="header">

        <ul class="menu-admin">
            <li><a href="LanguageAdmin.aspx">Language</a></li>
            <li><a href="HobbiesAdmin.aspx">Hobbies</a></li>
            <li><a href="ProfessionAdmin.aspx">Profession</a></li>
            <li><a href="IndustryAdmin.aspx">Industry</a></li>
            <li><a href="SyllabusAdmin.aspx">Syllabus</a></li>
            <li><a href="#">Logout</a></li>


        </ul>

        <div class="admin-text">Admin</div>
    </div>
    <form id="form1" runat="server">

        <div align="center">
            <h2>Here you can add your Industry</h2>
            <br />
            <div style="width: 280px">
                Industry &nbsp;:  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="txtIndustry" runat="server" onKeyPress="return ValidateAlpha(event);"></asp:TextBox>
                <br />
                <br />
                <div id="btnIndustryWidth">
                    <asp:Button ID="btnShow" runat="server" Text="Show All" ToolTip="Click to show all profession" CssClass="Langbtn" OnClick="btnShow_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" CssClass="Langbtn" OnClick="btnUpdate_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Click to add this profession" CssClass="Langbtn" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" CssClass="Langbtn" OnClick="btnCancel_Click" />
                </div>
            </div>
        </div>
        <br />

        <div align="center">
            <asp:Panel ID="PanelGrid" runat="server" Width="1000px" Visible="false">
                <h2>Industry List
                </h2>
                <div id="gridAdmin">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="Industry_ID">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Wheat">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Industry_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Industry" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Wheat">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Industry_Name") %>'></asp:Label>
                                </ItemTemplate>

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Wheat">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Wheat">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>

        </div>

    </form>
</body>
</html>
