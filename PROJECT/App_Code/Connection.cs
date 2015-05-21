using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Connection
/// </summary>
public class Connection
{

    public static SqlConnection MyCon()
    {

        // string conn = "";

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
        return con;
    }
}