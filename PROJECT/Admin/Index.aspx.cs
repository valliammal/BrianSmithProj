using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


public partial class Admin_Index : System.Web.UI.Page
{
    DataConnectivity dc = new DataConnectivity();
    EncryptDecrypt ed = new EncryptDecrypt();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string user = txtuser.Text.Trim();
        string pwd = txtpwd.Text.Trim();

        if (txtpwd.Text.Trim() != "" || txtuser.Text.Trim() != "")
        {
            string query = "select Name,Password,Email from adminmaster where Email='" + user + "'";
            DataTable dt = new DataTable();
            dt = dc.GetDataTable(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                string name = dt.Rows[0]["Name"].ToString();
                string pwd1 = dt.Rows[0]["Password"].ToString();
                string email = dt.Rows[0]["Email"].ToString();
                string DecPwd = ed.Decrypt(pwd1);
                if (pwd == DecPwd)
                {
                    Session["Admin"] = name;
                    Response.Redirect("LanguageAdmin.aspx?" + name);
                }
                else
                {
                    Response.Write("<script>alert('Password not matched')</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Wrong Credentials.')</script>");

            }
        }
        else
        {
            Response.Write("<script>alert('Fill both the fields.')</script>");

        }

    }
}
