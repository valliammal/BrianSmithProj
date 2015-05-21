using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Master : System.Web.UI.MasterPage
{
    BusinessLogic buslog = new BusinessLogic();
    DataConnectivity dc = new DataConnectivity();
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //protected void btnLoginn_Click(object sender, EventArgs e)
    //{
    //    string email = txtEmailLogin.Text.Trim();
    //    string pwd = txtpwd.Text.Trim();
    //    string query = "select password from usermaster where email='" + email + "'";
    //    string pass;
    //    DataTable dt = dc.GetDataTable(query);
    //    if (dt.Rows.Count > 0)
    //    {
    //        pass = dt.Rows[0]["Password"].ToString();
    //        string ppwwdd = EncryptDecrypt.DecryptStatic(pass);
    //        if (ppwwdd == pwd)
    //        {
    //            Response.Redirect("~/User/Default.aspx?" + email);
    //        }
    //    }
    //    else
    //    {
    //        Response.Write("<script>alert('Wrong Credentials.')</script>");
    //    }
    //}

    //protected void btnRegister_Click1(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (txtEmail.Text != "")
    //        {
    //            int i = buslog.InsertRegistration(txtEmail.Text.Trim(), txtpwdReg.Text.Trim());
    //            if (i > 0)
    //            {
    //                txtpwdReg.Text = string.Empty;
    //                txtEmail.Text = string.Empty;
    //                txtCpwd.Text = string.Empty;
    //                lblError.Text = "Resgistration is completed. Now you can Login In.";
    //                Response.Write("<script>alert('Registration process is succesuffuly')</script>");

    //            }
    //            else
    //            {
    //                lblError.Text = "Email-ID is already registered...";
    //                lblError.ForeColor = System.Drawing.Color.Red;
    //                Response.Write("<script>alert('Email-ID is already registered....')</script>");
    //            }
    //        }

    //    }
    //    catch (Exception)
    //    {
    //        Response.Write("<script>alert('Error Found.')</script>");
    //    }

    //}

}
