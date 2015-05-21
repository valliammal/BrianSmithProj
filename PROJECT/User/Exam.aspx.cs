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

public partial class Exam : System.Web.UI.Page
{
    DataConnectivity dc = new DataConnectivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("../Index.aspx");
        }
        else
        {
            string user = Session["User"].ToString();
            lblUserName.Text = user;
            imgprofile.Visible = true;
            if (!IsPostBack)
            {
                //string queryStringID = Request.QueryString["id"].ToString();

                //int QuesID = Convert.ToInt16(Request.QueryString["id"].ToString());
                LoadQuestion(1);



            }
        }
    }

    public void LoadQuestion(int no)
    {
        try
        {
            string queryQuestion = "select Ques_ID,Question,PicPath from Questions where Ques_ID =" + no + "";
            //string queryAnswer = "select Answer,mp3_Name,Status from answers where Ques_ID=" + no + "";
            string queryAnswer = "SELECT TOP 4 Answer,Mp3_Name,Status FROM Answers where ques_id=" + no + " order BY NEWID()";
            DataTable dtQuestion = dc.GetDataTable(queryQuestion);
            DataTable dtAnswer = dc.GetDataTable(queryAnswer);
            if (dtQuestion.Rows.Count > 0)
            {


                for (int i = 0; i < dtQuestion.Rows.Count; i++)
                {
                    lblQuestionID.Text = dtQuestion.Rows[i]["Ques_ID"].ToString();
                    Image1.ImageUrl = dtQuestion.Rows[i]["PicPath"].ToString();
                    lblQues.Text = dtQuestion.Rows[i]["Question"].ToString();
                    GlobVar.rightOption = opt1.Text.Trim();

                    opt1.Text = dtAnswer.Rows[0][0].ToString();
                    opt2.Text = dtAnswer.Rows[1][0].ToString();
                    opt3.Text = dtAnswer.Rows[2][0].ToString();
                    opt4.Text = dtAnswer.Rows[3][0].ToString();

                    lblSound2.Text = dtAnswer.Rows[0][1].ToString();
                    lblSound1.Text = dtAnswer.Rows[1][1].ToString();
                    lblSound3.Text = dtAnswer.Rows[2][1].ToString();
                    lblSound4.Text = dtAnswer.Rows[3][1].ToString();
                    string statusRight = dtAnswer.Rows[0][2].ToString();
                    string statusWrong1 = dtAnswer.Rows[1][2].ToString();
                    string statusWrong2 = dtAnswer.Rows[2][2].ToString();
                    string statusWrong3 = dtAnswer.Rows[3][2].ToString();

                }


                GlobVar.counter = no;
                GlobVar.cc = no;
            }
            else
            {
                Response.Redirect("NoQuestion.aspx");

            }
        }
        catch (Exception)
        {
            Response.Write("<script>alert('Error Found')</script>");
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        //Random r = new Random();
        //int no = r.Next(1, 11);

        //LoadQuestion(no);
        GlobVar.cc = GlobVar.cc + 1; ;
        LoadQuestion(GlobVar.cc);

        imgMessage1.Visible = false;
        imgMessage2.Visible = false;
        imgMessage3.Visible = false;
        imgMessage4.Visible = false;
        EnabledOpt();

    }



    protected void logout()
    {
        Response.Redirect("Login.aspx");
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {

        Session.Abandon();
        Session.Clear();
        Response.Redirect("Login.aspx");
    }


    protected void btnPrev_Click(object sender, EventArgs e)
    {
        GlobVar.cc = GlobVar.cc - 1; ;
        LoadQuestion(GlobVar.cc);
        imgMessage1.Visible = false;
        imgMessage2.Visible = false;
        imgMessage3.Visible = false;
        imgMessage4.Visible = false;
        EnabledOpt();
    }

    public void DisabledOpt()
    {
        opt1.Enabled = false;
        opt2.Enabled = false;
        opt3.Enabled = false;
        opt4.Enabled = false;
        imgMessage4.Visible = false;
        imgMessage1.Visible = false;
        imgMessage2.Visible = false;
        imgMessage3.Visible = false;


    }

    public void EnabledOpt()
    {
        opt1.Enabled = true;
        opt2.Enabled = true;
        opt3.Enabled = true;
        opt4.Enabled = true;
        opt1.Checked = false;
        opt2.Checked = false;
        opt3.Checked = false;
        opt4.Checked = false;

        //imgMessageW1.Visible = true;
        //imgMessageW2.Visible = true;
        //imgMessageW3.Visible = true;
        //imgMessageR1.Visible = true;
    }


    protected void optWrong1_CheckedChanged(object sender, EventArgs e)
    {

        if (opt1.Text.Trim() != GlobVar.rightOption)
        {
            DisabledOpt();
            imgMessage1.Visible = true;
            imgMessage2.Visible = true;
            btnTryAgain.Visible = true;
        }
        else
        {
            DisabledOpt();
            imgMessage1.Visible = true;
        }
    }
    protected void optRight_CheckedChanged(object sender, EventArgs e)
    {

        if (opt1.Text.Trim() != GlobVar.rightOption)
        {
            DisabledOpt();
            imgMessage1.Visible = true;
            btnTryAgain.Visible = false;
        }
        else
        {
            DisabledOpt();
            imgMessage1.Visible = true;
        }
    }
    protected void optWrong2_CheckedChanged(object sender, EventArgs e)
    {
        if (opt2.Text.Trim() != GlobVar.rightOption)
        {
            DisabledOpt();
            imgMessage1.Visible = true;
            imgMessage2.Visible = true;
            btnTryAgain.Visible = true;
        }
        else
        {
            DisabledOpt();
            imgMessage1.Visible = true;
        }
    }
    protected void optWrong3_CheckedChanged(object sender, EventArgs e)
    {
        if (opt3.Text.Trim() != GlobVar.rightOption)
        {
            DisabledOpt();
            imgMessage1.Visible = true;
            imgMessage3.Visible = true;
            btnTryAgain.Visible = true;
        }
        else
        {
            DisabledOpt();
            imgMessage1.Visible = true;
        }
    }
    protected void btnTryAgain_Click(object sender, EventArgs e)
    {
        EnabledOpt();
        imgMessage4.Visible = false;
        imgMessage1.Visible = false;
        imgMessage2.Visible = false;
        imgMessage3.Visible = false;
    }






    [WebMethod]
    public static string GetResult(string QID, string option)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        try
        {

            string query = "Select Status,Answer_Detail,Answer from answers where Ques_ID='" + QID + "' and Answer='" + option + "'";
            // string query = "Select Status from answers where answer='" + option + "'";
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