using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Admin_SyllabusAdmin : System.Web.UI.Page
{

    DataConnectivity dc = new DataConnectivity();
    BusinessLogic buslog = new BusinessLogic();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void ShowData()
    {
        try
        {
            DataTable dt = buslog.BindSyllabus();
            if (dt != null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                PanelGrid.Visible = true;
            }
            else
            {
                PanelGrid.Visible = false;
                Response.Write("<script>alert('There is no Syllabus Detail.')</script>");
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void BtnLanguage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/LanguageAdmin.aspx");
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
        Response.Redirect("~/Admin/Index.aspx");
    }
    protected void btnIndustry_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/IndustryAdmin.aspx");
    }
    protected void btnSyllabus_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/SyllabusAdmin.aspx");
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        try
        {
            string syllDetails = txtSylDetail.Text.Trim();
            string syllabus = txtSyllabus.Text.Trim();
            if (syllabus != "" && syllDetails != "")
            {
                DataTable dt = buslog.CheckSyllabusDuplicate(syllDetails);
                if (dt == null)
                {
                    int i = buslog.InsertSyllabus(syllabus, syllDetails);
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Syllabus is sucessfully inserted.')</script>");
                        ClearAll();
                        ShowData();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error found and not inserted. Please try again.')</script>");
                    }

                }
                else
                {
                    Response.Write("<script>alert('You are trying to enter duplicate Syllabus.')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Fill the Syllabus and Syllabus Detail.')</script>");
            }

        }
        catch (Exception)
        {
            Response.Write("<script>alert('Error found.')</script>");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearAll();
        btnShow.Visible = true;
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
        btnCancel.Visible = false;
    }

    protected void ClearAll()
    {
        txtSyllabus.Text = string.Empty;
        txtSylDetail.Text = string.Empty;
    }

    protected void btnEdit_Click1(object sender, EventArgs e)
    {
        try
        {
            LinkButton ButtonEdit = sender as LinkButton;
            GridViewRow gvrow = ButtonEdit.NamingContainer as GridViewRow;
            // GlobVar.cid = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
            string sid = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
            GlobVar.GLobal_SID = sid;
            string query = "select Syllabus_Name,Syllabus_Detail from Syllabus where Syllabus_ID=" + sid + "";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                txtSyllabus.Text = dt.Rows[0]["Syllabus_Name"].ToString();
                txtSylDetail.Text = dt.Rows[0]["Syllabus_Detail"].ToString();
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton ButtonDelete = sender as LinkButton;
            GridViewRow gvrow = ButtonDelete.NamingContainer as GridViewRow;

            string sid = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
            GlobVar.GLobal_SID = sid;
            string query = "select Syllabus_Name,Syllabus_Detail from Syllabus where Syllabus_ID=" + sid + "";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                string syllabusName = dt.Rows[0]["Syllabus_Name"].ToString();
                string query1 = "delete from Syllabus where Syllabus_ID=" + GlobVar.GLobal_SID + "";
                int i = dc.ExecuteQuery(query1);
                if (i > 0)
                {
                    btnShow.Visible = true;
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    txtSylDetail.Text = string.Empty;
                    txtSyllabus.Text = string.Empty;
                    ShowData();
                    GlobVar.GLobal_SID = "";
                    Response.Write("<script>alert('" + syllabusName + " syllabus is deleted successfully.')</script>");
                }
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error found : - " + ex.Message.ToString() + "')</script>");
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        ShowData();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Through this method we can update the inserted language.
        string syllabus = txtSyllabus.Text.Trim();
        string syllDetail = txtSylDetail.Text.Trim();
        if (syllabus != "" && syllDetail != "")
        {
            DataTable dt = buslog.CheckSyllabusDuplicate(syllDetail);
            if (dt == null)
            {
                int count = buslog.UpdateSyllabus(syllabus, syllDetail);
                if (count > 0)
                {

                    btnShow.Visible = true;
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    txtSyllabus.Text = string.Empty;
                    txtSylDetail.Text = string.Empty;
                    ShowData();
                    GlobVar.GLobal_SID = "";
                }
                else
                {
                    Response.Write("<script>alert('Not updated.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('You are trying to enter duplicate syllabus.')</script>");
            }

        }
        else
        {
            Response.Write("<script>alert('Fill the Syllabus.')</script>");
        }

    }
}