using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Admin_AdminRegistration : System.Web.UI.Page
{
    DataConnectivity dc = new DataConnectivity();
    BusinessLogic buslog = new BusinessLogic();
    EncryptDecrypt ed = new EncryptDecrypt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtuser.Text = "ADM" + DateTime.Now.Ticks.GetHashCode().ToString("X");

        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        InsertAdminData();
    }

    protected void InsertAdminData()
    {
        string EnPwd = ed.Encrypt(txtpwd.Text);
        //string gen = "";
        //if (optFemale.Checked == true)
        //    gen = "Female";
        //else
        //    gen = "Male";
        //string query = "insert into AdminMaster (Name,Username,Password,Gender,Email,Contact,Address,Pincode) values ('" + txtname.Text.Trim() + "','" + txtuser.Text.Trim() + "','" + EnPwd + "','" + gen + "','" + txtemail.Text.Trim() + "','" + txtcontact.Text.Trim() + "','" + txtadd.Text.Trim() + "'," + txtpin.Text.Trim() + ")";
        string query = "insert into AdminMaster (Name,Password,Email) values ('" + txtname.Text.Trim() + "','" + EnPwd + "','" + txtemail.Text.Trim() + "')";
        int i = dc.ExecuteQuery(query);
        if (i > 0)
        {
            Response.Write("<script>alert('Registration is done.')</script>");
            ClearAll();
        }
        else
        {
            Response.Write("<script>alert('Not registered.')</script>");
        }
    }

    protected void ClearAll()
    {
        txtcpwd.Text = string.Empty;
        txtemail.Text = string.Empty;
        txtname.Text = string.Empty;
        txtpwd.Text = string.Empty;

    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearAll();
    }
    protected void bntLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Index.aspx");
    }
}