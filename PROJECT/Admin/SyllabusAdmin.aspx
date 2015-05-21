<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SyllabusAdmin.aspx.cs" Inherits="Admin_SyllabusAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Syllabus(Admin)</title>
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
    <form id="form1" runat="server">
        <div>
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

            <div style="flex-align: center; margin-left: 500px">
                <h2>Here you can add your Syllabus</h2>
                <br />
                <div style="width: 460px;">
                    <div width="400px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Syllabus &nbsp;: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="txtSyllabus" runat="server"></asp:TextBox>

                        <br />
                        <br />
                    </div>
                    <div width="400px">
                        Syllabus-Detail &nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="txtSylDetail" runat="server" Width="300px"></asp:TextBox>

                    </div>

                    <br />
                    <div id="btnSyllabusWidth" align="right">
                        <asp:Button ID="btnShow" runat="server" Text="Show All" ToolTip="Click to show all profession" CssClass="Langbtn" OnClick="btnShow_Click" />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" CssClass="Langbtn" OnClick="btnUpdate_Click" />
                        &nbsp;&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="Click to add this profession" CssClass="Langbtn" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" CssClass="Langbtn" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>

            <div align="center">

                <asp:Panel ID="PanelGrid" runat="server" Width="800px" Visible="false">
                    <h2>Syllabus List
                    </h2>
                    <div id="gridSyllabus">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="Syllabus_ID" Width="800px">
                            <Columns>
                                <asp:TemplateField HeaderText="ID" HeaderStyle-Width="2px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Wheat">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Syllabus_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Syllabus" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Wheat">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("Syllabus_Name") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Syllabus Detail" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Left" HeaderStyle-BackColor="Wheat">
                                    <ItemTemplate>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Eval("Syllabus_Detail") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Wheat">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server" OnClick="btnEdit_Click1">Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Wheat">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server" OnClick="btnDelete_Click">Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>

            </div>


        </div>
    </form>
</body>
</html>
