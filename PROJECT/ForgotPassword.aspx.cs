using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class ForgotPassword : System.Web.UI.Page
{
    DataConnectivity dc = new DataConnectivity();
    EncryptDecrypt ed = new EncryptDecrypt();
    BusinessLogic buslog = new BusinessLogic();
    EmailConfig ec = new EmailConfig();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string email = txtemail.Text.Trim().ToString();

        if (email != "")
        {
            string query = "select Email,password from usermaster where email='" + email + "'";
            DataTable dt = new DataTable();
            dt = dc.GetDataTable(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                string pwd1 = dt.Rows[0]["Password"].ToString();
                string EnPwd = ed.Decrypt(pwd1);
                string email1 = dt.Rows[0]["Email"].ToString();
                string body = "Your password is <b>" + EnPwd + " </b>. Click to login here (<i>www.gnsonlinedemo.com</i>)";
                string subject = "Forgot Password(User)";
                bool result = ec.SendMail(email1, body, subject);
                if (result)
                {
                    Response.Write("<script>alert('Your request for retreive password is sent successfully. Check your email-id.')</script>");
                    txtemail.Text = string.Empty;

                }
                else
                {
                    Response.Write("<script>alert(Password  sending failed..')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('This email id(" + email + ") is not registered email id')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Fill the email id.')</script>");
        }
    }
}