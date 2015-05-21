using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GlobVar
/// </summary>
public class GlobVar
{
    public GlobVar()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string PPath = "";
    public static int counter;
    public static int cc = 1;


    public static string GLobal_LID = "";
    public static string Global_HID = "";
    public static string Global_PID = "";
    public static string GLobal_IID = "";
    public static string GLobal_SID = "";
    public static string getDate()
    {
        //string dd = DateTime.Now.Day.ToString();
        //string mm = DateTime.Now.Month.ToString();
        //string yy = DateTime.Now.Year.ToString();
        //string date = mm + "/" + dd + "/" + yy;
        string sdate = DateTime.Now.Date.ToString("dd'/'MM'/'yyyy");
        return sdate;
    }

    public static int ques_ID = 0;
    public static string gLobal_R = "";
    public static string gLobal_W1 = "";
    public static string gLobal_W2 = "";
    public static string gLobal_W3 = "";



    public static string rightOption = "";

}




