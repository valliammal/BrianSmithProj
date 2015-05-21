using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class SmsText : System.Web.UI.Page
{
    DataConnectivity dc = new DataConnectivity();
    BusinessLogic buslog = new BusinessLogic();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fetchC();
        }
    }

    public void fetchC()
    {
        DataTable dt = buslog.FetchCountry();
        if (dt.Rows.Count > 0)
        {
            int cc = dt.Rows.Count;
            for (int i = 0; i < cc; i++)
            {
                ddlCountry.Items.Add(dt.Rows[i]["CountryName"].ToString());
                //+ "" +dt.Rows[i]["CountryCode"].ToString()
            }
        }
        else
        {
            Response.Write("<script>alert('No Country Name Found.')</script>");
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCode.Text = buslog.FetchCoutryCode(ddlCountry.SelectedItem.Text.Trim());
        lblError.Text = string.Empty;
    }

    protected void btnSkip_Click(object sender, EventArgs e)
    {
        Response.Redirect("Address.aspx");
    }
}