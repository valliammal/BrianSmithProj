using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_NoQuestion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("../Index.aspx");
        }
        else
        {
            string user = Session["User"].ToString();
            lblUserName.Text = user;
            imgprofile.Visible = true;
            if (!IsPostBack)
            {
                //string queryStringID = Request.QueryString["id"].ToString();

                //int QuesID = Convert.ToInt16(Request.QueryString["id"].ToString());




            }
        }
    }
}