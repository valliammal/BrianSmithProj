using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Services;

public partial class Profession : System.Web.UI.Page
{
    BusinessLogic buslog = new BusinessLogic();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindProfession();
        }

    }

    protected void BindProfession()
    {
        try
        {
            DataTable dt = buslog.BindProf();
            if (dt != null)
            {
                int count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    //  lstProfRight.Items.Add(dt.Rows[i]["Prof_Name"].ToString());
                }
            }
            else
            {
                Response.Write("<script>alert('There is no data in Profession')</script>");
            }
        }
        catch (Exception)
        {

            Response.Write("<script>alert('Error Found during get the data of Profession.')</script>");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserRegistration.aspx");
    }
    protected void btnSkip_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserRegistration.aspx");
    }
    [WebMethod]
    public static string jsonstring(string country)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        // int i = 1;

        try
        {

            string query = "select Prof_Name from Profession where Prof_country='" + country + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);


            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        catch (Exception)
        {
            con.Close();
            return "error";
        }


    }

    protected void ddlSelectProf_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}