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

public partial class ExamJquery : System.Web.UI.Page
{
    DataConnectivity dc = new DataConnectivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            string user = Session["User"].ToString();
            lblUserName.Text = user;
            imgprofile.Visible = true;

        }
    }


    [WebMethod]
    public static string GetQuestions(string QuesID)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        // int i = 1;

        try
        {

            string query = "Select Question,PicPath from Questions where Ques_ID=" + QuesID + "";
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

    [WebMethod]
    public static string GetAnswers(string QuestionID)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        // int i = 1;

        try
        {

            string query = "select Answer,Status,Mp3_Name  from Answers where Ques_ID= " + QuestionID + "";
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

    [WebMethod]
    public static string GetQuesID()
    {

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        // int i = 1;

        try
        {

            string query = "select Ques_ID from Questions";
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

    [WebMethod]
    public static string CountID()
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        // int i = 1;

        try
        {

            string query = "Select count(Ques_ID) as 'Count' from Questions";
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

    [WebMethod]
    public static string GetOptions(string Q_ID)
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        // int i = 1;

        try
        {

            string query = "select Answer,Status  from Answers where Ques_ID= " + Q_ID + " and status='R'";
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