﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

public partial class Home : System.Web.UI.Page
{
    DataConnectivity dc = new DataConnectivity();

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
        }
    }
}