using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


public partial class ProfessionAdmin : System.Web.UI.Page
{

    BusinessLogic buslog = new BusinessLogic();
    DataConnectivity dc = new DataConnectivity();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSyllabus_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/SyllabusAdmin.aspx");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton ButtonEdit = sender as LinkButton;
            GridViewRow gvrow = ButtonEdit.NamingContainer as GridViewRow;
            // GlobVar.cid = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
            string pid = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
            GlobVar.Global_PID = pid;

            string query = "select Prof_Name from Profession where Prof_ID=" + pid + "";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                string proff = dt.Rows[0]["Prof_Name"].ToString();
                string query1 = "delete from Profession where Prof_ID=" + pid + "";
                int i = dc.ExecuteQuery(query1);
                if (i > 0)
                {
                    btnShow.Visible = true;
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    GlobVar.Global_HID = string.Empty;
                    Response.Write("<script>alert('This profession(" + proff + ") is deleted now.')</script>");
                    ShowProf();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error found : - " + ex.Message.ToString() + "')</script>");
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton ButtonEdit = sender as LinkButton;
            GridViewRow gvrow = ButtonEdit.NamingContainer as GridViewRow;

            string pid = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
            GlobVar.Global_PID = pid;
            string query = "select Prof_Name from Profession where Prof_ID=" + pid + "";
            DataTable dt = new DataTable();
            dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                txtProf.Text = dt.Rows[0]["Prof_Name"].ToString();
                btnShow.Visible = false;
                btnSubmit.Visible = false;
                ddlCountry.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;

            }

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }
    protected void btnProfession_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ProfessionAdmin.aspx");
    }
    protected void btnHobbies_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/HobbiesAdmin.aspx");
    }
    protected void BtnLanguage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/LanguageAdmin.aspx");
    }


    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedItem.Text.Trim() == "---Select---")
        {
            ShowProf();
        }
        else if (ddlCountry.SelectedItem.Text.Trim() == "UK")
        {
            ShowProf("UK");
        }
        else if (ddlCountry.SelectedItem.Text.Trim() == "USA")
        {
            ShowProf("USA");
        }
        else if (ddlCountry.SelectedItem.Text.Trim() == "India")
        {
            ShowProf("India");
        }
        else
        {

        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Through this method we can update the inserted Profession.

        string prof = txtProf.Text.Trim();
        if (prof != "")
        {
            DataTable dt = buslog.CheckProfessionDuplicate(prof);
            if (dt == null)
            {
                int count = buslog.UpdateProfession(prof);
                if (count > 0)
                {

                    btnShow.Visible = true;
                    btnSubmit.Visible = true;
                    ddlCountry.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    txtProf.Text = string.Empty;
                    ShowProf();
                    GlobVar.Global_HID = "";
                }
                else
                {
                    Response.Write("<script>alert('Not updated.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('You are trying to enter duplicate profession.')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Fill the profession.')</script>");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedItem.Text.Trim() != "---Select---")
        {
            try
            {
                string prof = txtProf.Text.Trim();
                string country = ddlCountry.SelectedItem.Text.Trim();
                if (prof != string.Empty)
                {
                    DataTable dt = buslog.CheckProfessionDuplicate(prof);
                    if (dt == null)
                    {
                        int i = buslog.InsertProf(prof, country);
                        if (i > 0)
                        {
                            Response.Write("<script>alert('Profession is inserted successfully.')</script>");
                            ShowProf();
                            txtProf.Text = string.Empty;
                        }
                        else
                        {
                            Response.Write("<script>alert('Not inserted.')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('You are trying to enter duplicate profession.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Fill the profession name')</script>");
                }

            }
            catch (Exception)
            {
                Response.Write("<script>alert('Error found ')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('First select country name')</script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtProf.Text = "";
        btnShow.Visible = true;
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
        btnCancel.Visible = false;
    }


    public void ShowProf()
    {
        try
        {

            string query = "select Prof_ID, Prof_Name,Prof_Country from Profession";
            DataTable dt = new DataTable();
            dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                PanelGrid.Visible = true;
            }
            else
            {
                Response.Write("<script>alert(' There is no data in profession.')</script>");
            }
        }
        catch (Exception)
        {
            Response.Write("<script>alert('Sorry Error Found.')</script>");
        }
    }


    public void ShowProf(string country)
    {
        try
        {

            string query = "select Prof_ID, Prof_Name,Prof_Country from Profession where Prof_Country='" + country + "'";
            DataTable dt = new DataTable();
            dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                PanelGrid.Visible = true;
            }
            else
            {
                Response.Write("<script>alert(' There is no data in profession.')</script>");
            }
        }
        catch (Exception)
        {
            Response.Write("<script>alert('Sorry Error Found.')</script>");
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/Index.aspx");
    }
    protected void btnIndustry_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/IndustryAdmin.aspx");
    }
}