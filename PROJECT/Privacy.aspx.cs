using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Services;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;

public partial class Privacy : System.Web.UI.Page
{
    BusinessLogic buslog = new BusinessLogic();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnproceed_Click(object sender, EventArgs e)
    {
        Response.Redirect("SmsText.aspx");
    }

    public void emailCh()
    {

    }

    public static bool isEmail(string inputEmail)
    {
        inputEmail = Convert.ToString(inputEmail);
        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(inputEmail))
            return (true);
        else
            return (false);
    }
}