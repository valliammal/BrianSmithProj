using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_ForgotAdmin : System.Web.UI.Page
{
    DataConnectivity dc = new DataConnectivity();
    EmailConfig em = new EmailConfig();
    EncryptDecrypt ed = new EncryptDecrypt();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string email = txtemail.Text.Trim().ToString();
        string user = txtuser.Text.Trim().ToString();

        if (email != "" && user != "")
        {
            string query = "select Name,Password,Email from adminmaster where email='" + email + "'";
            DataTable dt = new DataTable();
            dt = dc.GetDataTable(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                string name = dt.Rows[0]["Name"].ToString();
                string pwd1 = dt.Rows[0]["Password"].ToString();
                string EnPwd = ed.Decrypt(pwd1);
                string email1 = dt.Rows[0]["Email"].ToString();
                if (user == name)
                {
                    string body = "Your password is <b>" + EnPwd + " </b>.  Click to login here (<i>www.gnsonlinedemo.com/Admin/Index.aspx</i>)";
                    string subject = "Forgot Password(Admin)";
                    bool result = em.SendMail(email1, body, subject);
                    if (result)
                    {
                        Response.Write("<script>alert('Your request for retreive password is sent successfully. Check your email-id.')</script>");
                        txtemail.Text = string.Empty;
                        txtuser.Text = string.Empty;

                    }
                    else
                    {
                        Response.Write("<script>alert('Email sending failed..')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Username is not matched..')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Email-ID is not registered.')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Fill both the fields.')</script>");
        }

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}