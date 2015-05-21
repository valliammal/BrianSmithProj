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


public partial class Hobbies : System.Web.UI.Page
{
    BusinessLogic buslog = new BusinessLogic();
    DataConnectivity dc = new DataConnectivity();
    EncryptDecrypt ed = new EncryptDecrypt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // BindHobbies();
        }
    }

    protected void BindHobbies()
    {
        try
        {
            DataTable dt = buslog.BindHobby();
            if (dt != null)
            {
                int count = dt.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    //lstHobbyRight.Items.Add(dt.Rows[i]["Hobby_Name"].ToString());
                }
            }
            else
            {
                Response.Write("<script>alert('There is no data in Hobby')</script>");
            }
        }
        catch (Exception)
        {

            Response.Write("<script>alert('Error Found during get the data of hobby.')</script>");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Industry.aspx");
    }
    protected void btnSkip_Click(object sender, EventArgs e)
    {
        Response.Redirect("Industry.aspx");
    }

    [WebMethod]
    public static string jsonstring()
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        // int i = 1;

        try
        {
            string query = "select Hobby_Name from Hobby";
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