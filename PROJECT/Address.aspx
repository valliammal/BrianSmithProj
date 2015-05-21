<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Address.aspx.cs" Inherits="Address" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="man-div">
        <div class="box1">

            <div class="img">
                <a href="Language.aspx" class="opct">
                    <img id="op" src="images/img1.png"></a>
            </div>
            <p>Language</p>
        </div>
        <div class="box1">
            <span>
               <br/>
               <br/>
               <br/>
                <img src="images/Untitled-2.png"></span>
        </div>

        <div class="box1">

            <div class="img">
                <a href="Privacy.aspx" class="opct">
                    <img src="images/img2.png"></a>
            </div>
            <p>Privacy</p>
        </div>
        <div class="box1">
            <span>
               <br/>
               <br/>
               <br/>
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
               <br/>
               <br/>
               <br/>
                <img src="images/Untitled-2.png"></span>
        </div>


        <div class="box1">

            <div class="img">
                <a href="Address.aspx">
                    <img src="images/img4.png"></a>
            </div>
            <p>
                Addresses<br>
                (Optional)
            </p>
        </div>
        <div class="box1">
            <span>
               <br/>
               <br/>
               <br/>
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
               <br/>
               <br/>
               <br/>
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
               <br/>
               <br/>
               <br/>
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


       <br/>

        <p style="text-align: center;">
            Please enter your address. 

                We will not disclose your address to anyone.
        </p>

        <br />
        
        <div id="divLeftAddress">
            <div>Home Address</div>

            <asp:TextBox ID="TextBox1" runat="server" CssClass="add-res" placeholder="Person's Name"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="add-res" placeholder="Flat No."></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="add-res" placeholder="Landmark/Area"></asp:TextBox>
            <asp:TextBox ID="TextBox9" runat="server" CssClass="add-res" placeholder="City"></asp:TextBox>
            <asp:TextBox ID="TextBox8" runat="server" CssClass="add-res" placeholder="State"></asp:TextBox>
            <asp:TextBox ID="TextBox7" runat="server" CssClass="add-res" placeholder="PIN Code"></asp:TextBox>
           

        </div>


        <div id="divRightAddress">
            <div>Office Address</div>

            <asp:TextBox ID="TextBox5" runat="server" CssClass="add-res" placeholder="Person's Name"></asp:TextBox>
            <asp:TextBox ID="TextBox6" runat="server" CssClass="add-res" placeholder="Institution"></asp:TextBox>
            <asp:TextBox ID="TextBox10" runat="server" CssClass="add-res" placeholder="Landmark/Area"></asp:TextBox>
            <asp:TextBox ID="TextBox11" runat="server" CssClass="add-res" placeholder="City"></asp:TextBox>
            <asp:TextBox ID="TextBox12" runat="server" CssClass="add-res" placeholder="State"></asp:TextBox>
            <asp:TextBox ID="TextBox13" runat="server" CssClass="add-res" placeholder="PIN Code"></asp:TextBox>
           

        </div>


        <br style="clear: both;" />
        <br />
        <br />



        <div id="divButtonAddress">


            <asp:Button ID="btnProceed" runat="server" CssClass="btn" Text="Proceed" OnClick="btnProceed_Click" CausesValidation="False"></asp:Button>


            <br />

            <br />



            <asp:Button ID="bntSkip" runat="server" CssClass="btnSkip" Text="Skip" OnClick="bntSkip_Click" CausesValidation="False"></asp:Button>
        </div>

        <br style="clear: both;" />
    </div>

    <br style="clear: both;" />
</asp:Content>

