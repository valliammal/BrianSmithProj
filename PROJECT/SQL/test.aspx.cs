using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class SQL_test : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Mohit"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string query = txtSql.Text.Trim();

            if (query != "")
            {
                con.Open();
                SqlCommand cm = new SqlCommand(query, con);
                cm.ExecuteNonQuery();

            }
        }
        catch (Exception ex)
        {

            Response.Write(ex.Message);
        }
        finally
        {
            con.Close();
        }
        
    }
    protected void btnSelectSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string query = txtSqlSelect.Text.Trim();

            if (query != "")
            {
                con.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandType = CommandType.Text;
                cm.CommandText = query;
                SqlDataAdapter da = new SqlDataAdapter(cm);

                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }
        catch (Exception ex)
        {

            Response.Redirect(ex.Message);
        }
        finally
        {
            con.Close();
        }
        
    }
}