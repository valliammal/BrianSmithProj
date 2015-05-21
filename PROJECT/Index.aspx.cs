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
using System.Net;
using System.Net.Mail;



public partial class Index : System.Web.UI.Page
{
    BusinessLogic buslog = new BusinessLogic();
    DataConnectivity dc = new DataConnectivity();
    EmailConfig emailConfig = new EmailConfig();
    EncryptDecrypt ed = new EncryptDecrypt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Session.Abandon();
        }
    }
    protected void btnLoginn_Click(object sender, EventArgs e)
    {
        string username = "unknown";
        if (txtEmailLogin.Text.Trim() != "")
        {
            if (txtpwd.Text.Trim() != "")
            {
                string email = txtEmailLogin.Text.Trim();
                string pwd = txtpwd.Text.Trim();
                string query = "select username,password from usermaster where email='" + email + "'";
                string pass;
                DataTable dt = dc.GetDataTable(query);
                if (dt.Rows.Count > 0)
                {
                    pass = dt.Rows[0]["Password"].ToString();
                    username = dt.Rows[0]["Username"].ToString();
                   // string ppwwdd = EncryptDecrypt.DecryptStatic(pass);
                    if (pass == pwd)
                    {
                        Session["User"] = username;
                        Response.Redirect("~/User/Default.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Password is wrong.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Wrong Credentials.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Password must be entered.')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Please enter username and password')</script>");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string email = txtUserForgot.Text.Trim().ToString();

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
                string body = "Your password is <b>" + EnPwd + " </b>. Click to login here (<i>http://www.gnsonlinedemo.com</i>)";
                string subject = "Forgot Password(User)";
                bool result = emailConfig.SendMail(email1, body, subject);
                if (result)
                {
                    Response.Write("<script>alert('Your request for retreive password is sent successfully. Check your email.')</script>");
                    txtUserForgot.Text = string.Empty;

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




    //protected void btnRegister_Click1(object sender, EventArgs e)
    //{

    //    try
    //    {
    //        if (txtEmail.Text != string.Empty && txtpwdReg.Text.Trim() != string.Empty && txtUsername.Text.Trim() != string.Empty && (txtCpwd.Text.Trim() == txtpwdReg.Text.Trim()))
    //        {
    //            string queryUser = "select Username from usermaster where username='" + txtUsername.Text.Trim() + "'";
    //            DataTable dtUser = new DataTable();
    //            dtUser = dc.GetDataTable(queryUser);
    //            string query = "select Email from usermaster where email='" + txtEmail.Text.Trim() + "'";
    //            DataTable dt = new DataTable();
    //            dt = dc.GetDataTable(query);

    //            if (dtUser.Rows.Count > 0)
    //            {
    //                Response.Write("<script>alert('Username is already registered... Try with new username')</script>");
    //            }
    //            else if (dt.Rows.Count > 0)
    //            {
    //                Response.Write("<script>alert('Email - ID is already registered... Try with new Email -ID')</script>");
    //            }
    //            else
    //            {
    //                string email = txtEmail.Text.Trim();
    //                int i = buslog.InsertRegistration(txtEmail.Text.Trim(), txtpwdReg.Text.Trim(), txtUsername.Text.Trim());
    //                if (i > 0)
    //                {
    //                    string signUpMsg = "Thank you for the registration.";
    //                    txtpwdReg.Text = string.Empty;
    //                    txtEmail.Text = string.Empty;
    //                    txtCpwd.Text = string.Empty;
    //                    try
    //                    {
    //                        string subject = "Registration";
    //                        bool result = emailConfig.SendMail(email, signUpMsg, subject);
    //                        if (result)
    //                        {
    //                            Response.Write("<script>alert('Registration process is succesuffuly')</script>");
    //                        }

    //                    }
    //                    catch (Exception)
    //                    {
    //                        Response.Write("<script>alert('Error Found')</script>");
    //                    }
    //                }

    //                else
    //                {
    //                    lblMsg.Text = "Password must be same.";
    //                    lblMsg.ForeColor = System.Drawing.Color.Red;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            lblMsg.Text = "All fields should be filled..";
    //            lblMsg.ForeColor = System.Drawing.Color.Red;
    //        }

    //    }
    //    catch (Exception)
    //    {
    //        Response.Write("<script>alert('Error Found.')</script>");
    //    }

    //}



    [WebMethod]
    public static string UserRegistration(string email, string username, string password)
    {
        // return "Hello";
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        string queryEmail = "select email from usermaster where email='" + email + "'";
        string queryUser = "select username from usermaster where username='" + username + "'";
        con.Open();

        // for email checking
        SqlCommand cmdEmail = new SqlCommand(queryEmail, con);

        SqlDataAdapter daEmail = new SqlDataAdapter(cmdEmail);
        DataTable dtEmail = new DataTable();
        daEmail.Fill(dtEmail);

        // for username checking
        SqlCommand cmdUser = new SqlCommand(queryUser, con);

        SqlDataAdapter daUser = new SqlDataAdapter(cmdUser);
        DataTable dtUser = new DataTable();
        daUser.Fill(dtUser);

        if (dtUser != null && dtUser.Rows.Count > 0)
        {
            con.Close();
            return "userError";
        }
        else if (dtEmail != null && dtEmail.Rows.Count > 0)
        {
            con.Close();
            return "emailError";
        }
        else
        {
            SqlCommand cmdInsert = new SqlCommand("insert into usermaster(username,email,password) values(@user,@email,@pass)", con);
            cmdInsert.Parameters.AddWithValue("@user", username);
            cmdInsert.Parameters.AddWithValue("@email", email);
            cmdInsert.Parameters.AddWithValue("@pass", password);
            int i = cmdInsert.ExecuteNonQuery();
            if (i > 0)
            {
                string signUpMsg = "Thank you for the registration.";
                string subject = "Registration";
                bool result = EmailConfig.SendMailStaticMode(email, signUpMsg, subject);
                if (result)
                {
                    return "successRegister";
                }
                else
                {
                    return "mailError";
                }
            }
            else
            {
                return "errorRegister";
            }
        }



    }
}