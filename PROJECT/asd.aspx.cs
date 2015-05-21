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

public partial class _Default : System.Web.UI.Page
{

    DataConnectivity dc = new DataConnectivity();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        string sp = " + ", dd = "";
        int count = myList.Items.Count;
        int[] myarr = new int[count];
        for (int i = 1; i < count; i++)
        {
            //myarr[i] = myList.
        }
        foreach (ListItem litem in myList.Items)
        {

            dd += litem.Text.ToString() + sp;
        }
        Response.Write("<script>alert('count is : " + count + " and values : " + dd + "')</script>");
        fetch();
    }


    public void fetch()
    {
//        string item = "";
        int count = myList.Items.Count;
        for (int i = 0; i < count; i++)
        {

            Label myLabel = new Label();
            myLabel.ID = "Labels" + i.ToString();
            myLabel.Text = myList.Items[i].ToString();

        }


    }



    [WebMethod]
    public static LangList[] GetData()
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        List<LangList> list = new List<LangList>();
        string query = "select Lang_Name from language";
        SqlCommand newCmd = new SqlCommand(query, con);
        con.Open();
        SqlDataReader rdr = newCmd.ExecuteReader();
        int i = 0;
        while (rdr.Read())
        {
            LangList ll = new LangList();
            ll.LangName = rdr.GetString(i);
            list.Add(ll);

        }
        i++;
        return list.ToArray();
    }


    [WebMethod]
    public static string GetData1()
    {
        string val = "mohit";
        return val;
    }
}
