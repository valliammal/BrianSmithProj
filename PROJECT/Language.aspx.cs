using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web.Services;


public partial class Language : System.Web.UI.Page
{
    static BusinessLogic buslog = new BusinessLogic();
    DataConnectivity dc = new DataConnectivity();
    EncryptDecrypt ed = new EncryptDecrypt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

           // BindD();
        }
    }

    public void BindD()
    {
        DataTable dt = buslog.bindLangIndex();
        if (dt != null)
        {

            for (int a = 0; a <= dt.Rows.Count - 1; a++)
            {
               // lstRight.Items.Add(dt.Rows[a]["Lang_Name"].ToString());
                //lblLang.Text = dt.Rows[a]["Lang"].ToString();
            }
        }
        else
        {
            Response.Write("<script>alert('There is no language in list')</script>");
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("Privacy.aspx");
    }



    [WebMethod]
    public static string jsonstring()
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        // int i = 1;

        try
        {

            string query = "select Lang_Name from language";
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