<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProfessionAdmin.aspx.cs" Inherits="ProfessionAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin(Profession)</title>
    <link href="../css/style.css" type="text/css" rel="stylesheet" media="all" />

    <style>
        
    </style>
    <script type="text/javascript">
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
        <div align="center">
            <h2>Here you can add your profession</h2>
            <br />
            <div style="width:600px;">
                
                        Profession &nbsp;:  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                            <asp:TextBox ID="txtProf" runat="server" onKeyPress="return ValidateAlpha(event);" Width="400px"></asp:TextBox>
                        <br />
                <br />

                <div class="btnProfession">
                    <asp:DropDownList ID="ddlCountry" runat="server" Height="28px" Style="cursor: pointer" CssClass="ddlLangbtn">

                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem>UK</asp:ListItem>
                        <asp:ListItem>USA</asp:ListItem>
                        <asp:ListItem>India</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnShow" runat="server" Text="Show All" ToolTip="Click to show all profession" CssClass="Langbtn" OnClick="btnShow_Click" /></td>
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
                <h2>Professions List
                </h2>
                <div id="gridAdminProf">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="Prof_ID">
                        <Columns>
                            <asp:TemplateField HeaderText="ID" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Wheat">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Prof_ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Country" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Wheat">
                                <ItemTemplate>
                                    <asp:Label ID="LabelCountry" runat="server" Text='<%#Eval("Prof_Country") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Profession" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="Wheat">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Prof_Name") %>'></asp:Label>
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
