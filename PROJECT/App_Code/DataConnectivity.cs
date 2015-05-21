using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataConnectivity
/// </summary>
public class DataConnectivity
{

    // we create the objects of these classes.
    SqlConnection con = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter adp = new SqlDataAdapter();
    public DataConnectivity()
    {
        // this is default constructor.

    }

    // This method is used to open the connection of SQL Database.
    public void OpenCon()
    {
        string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString();
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = conStr;
                con.Open();
                cmd.Connection = con;

            }
        }
        catch (Exception ex)
        {
            ex.Message.ToString();
        }
    }


    // Through this method we close the connection which we have discussed above.
    public void CloseCon()
    {
        try
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        catch (Exception ex)
        {

            ex.Message.ToString();
        }
    }


    // Through this method we can execute the query.
    public int ExecuteQuery(string query)
    {
        int i;
        OpenCon();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = query;
        try
        {
            i = cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {

            return -1;
        }
        CloseCon();
        return i;
    }



    // for get the data from database via queries.
    public DataTable GetDataTable(string query)
    {
        try
        {
            OpenCon();
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            adp.SelectCommand = cmd;
            adp.Fill(dt);
            CloseCon();
            return dt;
        }

        catch (Exception ex)
        {
            ex.Message.ToString();
            return null;
        }
    }
}