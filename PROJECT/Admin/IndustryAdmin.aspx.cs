using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Admin_IndustryAdmin : System.Web.UI.Page
{
    DataConnectivity dc = new DataConnectivity();
    BusinessLogic buslog = new BusinessLogic();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        PanelGrid.Visible = true;
        ShowIndustry();
    }

    public void ShowIndustry()
    {
        try
        {
            DataTable dt = buslog.BindIndustry();
            if (dt != null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                PanelGrid.Visible = true;
            }
            else
            {
                PanelGrid.Visible = false;
                Response.Write("<script>alert('There is no Industry Name.')</script>");
            }
        }
        catch (Exception)
        {

            Response.Write("<script>alert('Error Found.')</script>");
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Through this method we can update the inserted language.

        string indus = txtIndustry.Text.Trim();
        if (indus != string.Empty)
        {
            DataTable dt = buslog.CheckIndustryDuplicate(indus);
            if (dt == null)
            {
                int count = buslog.UpdateIndustry(indus);
                if (count > 0)
                {

                    btnShow.Visible = true;
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    txtIndustry.Text = string.Empty;
                    ShowIndustry();
                    GlobVar.GLobal_LID = "";
                }
                else
                {
                    Response.Write("<script>alert('not updated')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('You are trying to enter duplicate industry.')</script>");
            }
        }

        else
        {
            Response.Write("<script>alert('Fill the Industry')</script>");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string indus = txtIndustry.Text.Trim();

            if (indus != string.Empty)
            {
                DataTable dt = buslog.CheckIndustryDuplicate(indus);
                if (dt == null)
                {
                    int i = buslog.InsertIndustry(indus);
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Industry Name is sucessfully inserted.')</script>");
                        txtIndustry.Text = string.Empty;
                        ShowIndustry();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error found and not inserted.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('You are trying to enter duplicate industry.')</script>");
                }
            }

            else
            {
                Response.Write("<script>alert('Fill the industry')</script>");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtIndustry.Text = string.Empty;
        btnShow.Visible = true;
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
        btnCancel.Visible = false;
    }


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton ButtonEdit = sender as LinkButton;
            GridViewRow gvrow = ButtonEdit.NamingContainer as GridViewRow;

            string iid = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
            GlobVar.GLobal_IID = iid;
            string query = "select Industry_Name from industry where Industry_ID=" + iid + "";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                txtIndustry.Text = dt.Rows[0]["Industry_Name"].ToString();
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

            string iid = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
            GlobVar.GLobal_IID = iid;
            string query = "select Industry_Name from industry where Industry_ID=" + iid + "";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                string indusName = dt.Rows[0]["Industry_Name"].ToString();
                string query1 = "delete from industry where Industry_ID=" + GlobVar.GLobal_IID + "";
                int i = dc.ExecuteQuery(query1);
                if (i > 0)
                {
                    btnShow.Visible = true;
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    txtIndustry.Text = string.Empty;
                    ShowIndustry();
                    GlobVar.GLobal_LID = "";
                    Response.Write("<script>alert('" + indusName + " indusry is deleted successfully.')</script>");
                }
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error found : - " + ex.Message.ToString() + "')</script>");
        }
    }

    protected void btnSyllabus_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/SyllabusAdmin.aspx");
    }
}