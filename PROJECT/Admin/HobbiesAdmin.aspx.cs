using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class HobbiesAdmin : System.Web.UI.Page
{
    DataConnectivity dc = new DataConnectivity();
    BusinessLogic buslog = new BusinessLogic();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void BtnLanguage_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/LanguageAdmin.aspx");
    }
    protected void btnHobbies_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/HobbiesAdmin.aspx");
    }
    protected void btnProfession_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/ProfessionAdmin.aspx");
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ShowHobby();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        // Through this method we can update the inserted hobbies.

        string hobby = txtHobby.Text.Trim();
        if (hobby != "")
        {
            DataTable dt = buslog.CheckHobbiesDuplicate(hobby);
            if (dt == null)
            {
                int count = buslog.UpdateHobby(hobby);
                if (count > 0)
                {

                    btnShow.Visible = true;
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    txtHobby.Text = string.Empty;
                    ShowHobby();
                    GlobVar.Global_HID = "";
                }
                else
                {
                    Response.Write("<script>alert('Not inserted. Please try again.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('You are trying to insert duplicate hobby .')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Fill the hobby.')</script>");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string hobbyName = txtHobby.Text.Trim();
            if (hobbyName != string.Empty)
            {
                DataTable dt = buslog.CheckHobbiesDuplicate(hobbyName);
                if (dt == null)
                {
                    int i = buslog.InsertHobby(hobbyName);
                    if (i > 0)
                    {
                        Response.Write("<script>alert('Hobby is inserted successfully.')</script>");
                        ShowHobby();
                        txtHobby.Text = string.Empty;
                    }
                    else
                    {
                        Response.Write("<script>alert('Error found and not inserted. Please try again.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('You are trying to enter duplicate hobby.')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Fill the hobby name')</script>");
            }
        }
        catch (Exception)
        {
            Response.Write("<script>alert('Error found')</script>");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtHobby.Text = "";
        btnShow.Visible = true;
        btnSubmit.Visible = true;
        btnUpdate.Visible = false;
        btnCancel.Visible = false;

    }

    public void ShowHobby()
    {
        try
        {
            DataTable dt = buslog.BindHobbyAdmin();
            if (dt != null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                PanelGrid.Visible = true;
            }
            else
            {
                Response.Write("<script>alert('There is no data in Hobby..')</script>");
            }
        }
        catch (Exception)
        {
            Response.Write("<script>alert('Sorry Error Found.')</script>");
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton ButtonEdit = sender as LinkButton;
            GridViewRow gvrow = ButtonEdit.NamingContainer as GridViewRow;
            // GlobVar.cid = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
            string hid = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
            GlobVar.Global_HID = hid;
            string query = "select Hobby_Name from Hobby where Hobby_ID=" + hid + "";
            DataTable dt = new DataTable();
            dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                txtHobby.Text = dt.Rows[0]["Hobby_Name"].ToString();
                btnShow.Visible = false;
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;

            }

        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton ButtonEdit = sender as LinkButton;
            GridViewRow gvrow = ButtonEdit.NamingContainer as GridViewRow;
            // GlobVar.cid = Convert.ToInt32(GridView1.DataKeys[gvrow.RowIndex].Value.ToString());
            string hid = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
            GlobVar.Global_HID = hid;

            string query = "select Hobby_Name from Hobby where Hobby_ID=" + hid + "";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                string hobby = dt.Rows[0]["Hobby_Name"].ToString();
                string query1 = "delete from Hobby where Hobby_ID=" + hid + "";
                int i = dc.ExecuteQuery(query1);
                if (i > 0)
                {
                    btnShow.Visible = true;
                    btnSubmit.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    GlobVar.Global_HID = string.Empty;
                    Response.Write("<script>alert('This hobby(" + hobby + ") is deleted now.')</script>");
                    ShowHobby();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error found : - " + ex.Message.ToString() + "')</script>");
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

    protected void btnSyllabus_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Admin/SyllabusAdmin.aspx");
    }
}