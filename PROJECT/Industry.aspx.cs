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

public partial class Industry : System.Web.UI.Page
{
    BusinessLogic buslog = new BusinessLogic();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        //    BindIndustry();
        }
    }

    public void BindIndustry()
    {
        try
        {
            DataTable dt = buslog.BindIndusData();
            if (dt != null)
            {
                int count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                   // lstIndusRight.Items.Add(dt.Rows[i]["Industry_Name"].ToString());
                }
            }
            else
            {
                Response.Write("<script>alert('There is no data in Industry')</script>");
            }
        }
        catch (Exception)
        {

            Response.Write("<script>alert('Error Found during get the data of Industry.')</script>");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Profession.aspx");
    }
    protected void btnSkip_Click(object sender, EventArgs e)
    {
        Response.Redirect("Profession.aspx");
    }

    [WebMethod]
    public static string jsonstring()
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        // int i = 1;

        try
        {

            string query = "select Industry_Name from Industry";
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
}