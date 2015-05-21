using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;



public partial class LanguageAdmin : System.Web.UI.Page
{
    DataConnectivity dc = new DataConnectivity();
    BusinessLogic buslog = new BusinessLogic();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Admin"] != null)
        {

        }
        else
        {
            Response.Redirect("Index.aspx");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }

    protected void btnSyllabus_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/SyllabusAdmin.aspx");
    }

    // This method is used to show the data in GridView on click event.
    public void ShowData()
    {
        try
        {
            DataTable dt = buslog.BindLangAdmin();
            if (dt != null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                PanelGrid.Visible = true;
            }
            else
            {
                PanelGrid.Visible = false;
                Response.Write("<script>alert('There is no language.')</script>");
            }
        }
        catch (Exception)
        {

            throw;
        }
    }


    // For insert the new language in database
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        try
        {
            string langg = txtLang.Text.Trim();
            if (langg != "")
            {
                DataTable dt = buslog.CheckLanguageDuplicate(langg);
                if (dt == null)
                {
                    int i = buslog.InsertAdmin(langg);
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Language is sucessfully inserted.')</script>");
                        txtLang.Text = string.Empty;
                        ShowData();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error found and not inserted. Please try again.')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('You are trying to enter duplicate language.')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Fill the language.')</script>");
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        PanelGrid.Visible = true;
        ShowData();
    }
    protected void BtnLanguage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/LanguageAdmin.aspx");
    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Through this method we can update the inserted language.
        string lang = txtLang.Text.Trim();
        if (lang != "")
        {
            DataTable dt = buslog.CheckLanguageDuplicate(lang);
            if (dt == null)
            {
                int count = buslog.UpdateLang(lang);
                if (count > 0)
                {

                    btnShow.Visible = true;
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    txtLang.Text = string.Empty;
                    ShowData();
                    GlobVar.GLobal_LID = "";
                }
                else
                {
                    Response.Write("<script>alert('Not updated.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('You are trying to enter duplicate language.')</script>");
            }

        }
        else
        {
            Response.Write("<script>alert('Fill the language.')</script>");
        }

    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtLang.Text = "";
        btnShow.Visible = true;
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
        btnCancel.Visible = false;
    }

    // Through this method we can edit the inserted data(language).
    protected void btnEdit_Click1(object sender, EventArgs e)
    {
        try
        {
            LinkButton ButtonEdit = sender as LinkButton;
            GridViewRow gvrow = ButtonEdit.NamingContainer as GridViewRow;
            // GlobVar.cid = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
            string lid = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
            GlobVar.GLobal_LID = lid;
            string query = "select Lang_Name from Language where Lang_ID=" + lid + "";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                txtLang.Text = dt.Rows[0]["Lang_Name"].ToString();
                btnShow.Visible = false;
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error found : - " + ex.Message.ToString() + "')</script>");
        }
    }




    // this code for delete the language which is inserted by admin and also shown in Index page.
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton ButtonDelete = sender as LinkButton;
            GridViewRow gvrow = ButtonDelete.NamingContainer as GridViewRow;

            string lid = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
            GlobVar.GLobal_LID = lid;
            string query = "select Lang_Name from Language where Lang_ID=" + lid + "";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                string langName = dt.Rows[0]["Lang_Name"].ToString();
                string query1 = "delete from language where Lang_ID=" + GlobVar.GLobal_LID + "";
                int i = dc.ExecuteQuery(query1);
                if (i > 0)
                {
                    btnShow.Visible = true;
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    txtLang.Text = string.Empty;
                    ShowData();
                    GlobVar.GLobal_LID = "";
                    Response.Write("<script>alert('" + langName + " langauge is deleted successfully.')</script>");
                }
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error found : - " + ex.Message.ToString() + "')</script>");
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
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();

        Response.Redirect("~/Admin/Index.aspx");
    }
    protected void btnIndustry_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/IndustryAdmin.aspx");
    }
}