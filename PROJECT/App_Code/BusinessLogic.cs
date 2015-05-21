using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


/// <summary>
/// Summary description for BusinessLogic
/// </summary>
public class BusinessLogic
{
    //public static string rohit = System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString();
    //public static string mohit = System.Configuration.ConfigurationManager.ConnectionStrings["Mohit"].ToString();

    DataConnectivity dc = new DataConnectivity();
    Connection MyConn = new Connection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Rohit"].ToString());
    EncryptDecrypt ed = new EncryptDecrypt();


    public BusinessLogic()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    // This method is used to get the country name from database.
    public DataTable FetchCountry()
    {
        string query = "select CountryName,CountryCode from Country";
        DataTable dt = dc.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {

            return dt;
        }

        return null;
    }


    // This method is used to get the country code from database.
    public string FetchCoutryCode(string ddlitem)
    {
        string query = "select CountryCode from Country where CountryName='" + ddlitem + "'";
        DataTable dt = dc.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            return (dt.Rows[0]["CountryCode"].ToString());
        }
        return "No Code";
    }


    // Through this method bind the data on Index page in ListBox.
    public DataTable BindDataIndex()
    {
        try
        {

            con.Close();
            SqlCommand cmd = new SqlCommand("L_Select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "L_Select";
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            con.Open();
            adp.SelectCommand = cmd;
            int i = adp.Fill(dt);
            if (i > 0)
            {
                con.Close();
                return dt;

            }
        }
        catch (Exception)
        {
            throw;
        }
        return null;
    }


    // For bind the data on Admin page in GridView.
    public DataTable BindDataAdmin()
    {
        try
        {

            con.Close();
            SqlCommand cmd = new SqlCommand("L_Select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "L_Select";
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            con.Open();
            adp.SelectCommand = cmd;
            int i = adp.Fill(dt);
            if (i > 0)
            {
                con.Close();
                return dt;
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    // This method is used to update the language on Admin Page.
    public int UpdateLang(string lang)
    {
        string query = "update language set Lang_Name='" + lang + "' where Lang_ID=" + GlobVar.GLobal_LID + "";
        int i = dc.ExecuteQuery(query);
        if (i > 0)
        {
            return i;
        }
        else
        {
            return 0;
        }
    }



    // This method is used to update the syllabus on Admin Page.
    public int UpdateSyllabus(string syllabus, string syllabusDetail)
    {
        string query = "update syllabus set Syllabus_Name='" + syllabus + "', Syllabus_Detail='" + syllabusDetail + "' where Syllabus_ID=" + GlobVar.GLobal_SID + "";
        int i = dc.ExecuteQuery(query);
        if (i > 0)
        {
            return i;
        }
        else
        {
            return 0;
        }
    }


    // This method is used to insert the new language into database by admin.
    public int InsertAdmin(string lang)
    {
        string query = "insert into Language (Lang_Name) values(N'" + lang + "')";
        int i = dc.ExecuteQuery(query);


        if (i > 0)
        {
            return i;
        }
        else
        {
            return 0;
        }
    }

    // Bind the language on admin page
    public DataTable BindLangAdmin()
    {
        try
        {
            string query = "select Lang_ID, Lang_Name from Language";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

    // Check the duplicay in language
    public DataTable CheckLanguageDuplicate(string langName)
    {
        try
        {
            string query = "select * from Language  where Lang_Name='" + langName + "'";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

    // Check the duplicay in Hobbies
    public DataTable CheckHobbiesDuplicate(string hobby)
    {
        try
        {
            string query = "select * from Hobby  where Hobby_Name='" + hobby + "'";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

    // Check the duplicay in Industry
    public DataTable CheckIndustryDuplicate(string indus)
    {
        try
        {
            string query = "select * from Industry  where Industry_Name='" + indus + "'";
            DataTable dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {

            throw;
        }

    }

    // Check the duplicay in Profession
    public DataTable CheckProfessionDuplicate(string prof)
    {
        string query = "select * from Profession  where Prof_Name='" + prof + "'";
        DataTable dt = dc.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            return dt;
        }
        else
        {
            return null;
        }
    }

    // check sylbaus details in database that is there any exist any duplicate value or not.

    public DataTable CheckSyllabusDuplicate(string syllDetail)
    {

        string querySyllDetail = "select * from Syllabus where Syllabus_Detail='" + syllDetail + "'";

        DataTable dtSylDet = dc.GetDataTable(querySyllDetail);
        if (dtSylDet.Rows.Count > 0)
        {
            return dtSylDet;
        }
        else
        {
            return null;
        }
    }

    public DataTable bindLangIndex()
    {
        try
        {
            string query = "select Lang_Name from Language";
            DataTable dt = new DataTable();
            dt = dc.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        finally
        {
        }

    }


    // This method is used to update the hobby on Admin Page.
    public int UpdateHobby(string hoby)
    {
        string query = "update hobby set Hobby_Name='" + hoby + "' where Hobby_ID=" + GlobVar.Global_HID + "";
        int i = dc.ExecuteQuery(query);
        if (i > 0)
        {
            return i;
        }
        else
        {
            return 0;
        }
    }


    // This method is used to update the profession on Admin Page.
    public int UpdateProfession(string proff)
    {
        string query = "update profession set Prof_Name='" + proff + "' where Prof_ID=" + GlobVar.Global_PID + "";
        int i = dc.ExecuteQuery(query);
        if (i > 0)
        {
            return i;
        }
        else
        {
            return 0;
        }

    }


    // This method is used to bind the data of hobby in user page.
    public DataTable BindHobby()
    {
        string query = "select Hobby_Name from hobby";
        DataTable dt = new DataTable();
        dt = dc.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            return dt;
        }
        else
        {
            return null;
        }
    }

    // This method is used to bind the data of profession.
    public DataTable BindProf()
    {
        string query = "select Prof_Name from Profession";
        DataTable dt = new DataTable();
        dt = dc.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            return dt;
        }
        else
        {
            return null;
        }
    }

    // This method is used to bind the data of Industry in admin portal.
    public DataTable BindIndustry()
    {
        string query = "select Industry_ID,Industry_Name from Industry";
        DataTable dt = new DataTable();
        dt = dc.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            return dt;
        }
        else
        {
            return null;
        }
    }

    // This method is used to bind the data of Syllabus in admin portal.
    public DataTable BindSyllabus()
    {
        string query = "select Syllabus_ID,Syllabus_Name,Syllabus_Detail from Syllabus";
        DataTable dt = new DataTable();
        dt = dc.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            return dt;
        }
        else
        {
            return null;
        }
    }


    // This method is used to insert the new industry into database by admin.
    public int InsertIndustry(string indus)
    {
        SqlCommand insert = new SqlCommand("insert into industry (Industry_Name) values(@indus)", con);
        insert.Parameters.AddWithValue("@indus", indus);
        try
        {
            con.Open();
            insert.ExecuteNonQuery();
            return 1;
        }
        catch (Exception)
        {
            con.Close();
            return 0;
        }
    }



    // This method is used to update the industry on Admin Page.
    public int UpdateIndustry(string indus)
    {
        string query = "update industry set Industry_Name='" + indus + "' where Industry_ID=" + GlobVar.GLobal_IID + "";
        int i = dc.ExecuteQuery(query);
        if (i > 0)
        {
            return i;
        }
        else
        {
            return 0;
        }
    }

    // This method is used to bind the industry data on user page.
    public DataTable BindIndusData()
    {
        string query = "select Industry_Name from Industry";
        DataTable dt = new DataTable();
        dt = dc.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            return dt;
        }
        else
        {
            return null;
        }
    }


    // for bind the data of hobby on admin page
    public DataTable BindHobbyAdmin()
    {
        string query = "select Hobby_ID, Hobby_Name from Hobby";
        DataTable dt = new DataTable();
        dt = dc.GetDataTable(query);
        if (dt.Rows.Count > 0)
        {
            return dt;
        }
        else
        {
            return null;
        }
    }


    // for insert the data of profession on admin page.
    public int InsertProf(string prof, string country)
    {
        SqlCommand insert = new SqlCommand("insert into profession (Prof_Name,Prof_Country) values (@prof,@country)", con);
        insert.Parameters.AddWithValue("@prof", prof);
        insert.Parameters.AddWithValue("@country", country);
        try
        {
            con.Open();
            insert.ExecuteNonQuery();
            return 1;
        }
        catch (Exception)
        {
            con.Close();
            return 0;
        }

    }


    // for insert the data of resgistration details of user.
    public int InsertRegistration(string email, string pwd, string username)
    {
        try
        {
            string enpwd = ed.Encrypt(pwd);
            SqlCommand insert = new SqlCommand("insert into UserMaster (Username,Email,Password) values(@user, @mail, @pwd)", con);
            insert.Parameters.AddWithValue("@user", username);
            insert.Parameters.AddWithValue("@mail", email);
            insert.Parameters.AddWithValue("@pwd", enpwd);
            try
            {
                con.Open();
                insert.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                con.Close();
                return 0;
            }
        }

        catch (Exception)
        {
            return 0;
        }
    }



    // for insert the data of hobbies on admin page.
    public int InsertHobby(string hobby)
    {

        SqlCommand insert = new SqlCommand("insert into Hobby (Hobby_Name) values(@hobby)", con);
        insert.Parameters.AddWithValue("@hobby", hobby);
        try
        {
            con.Open();
            insert.ExecuteNonQuery();
            return 1;
        }
        catch (Exception)
        {
            con.Close();
            return 0;
        }


    }


    // for insert the data of hobbies on admin page.
    public int InsertSyllabus(string syllabus, string syllabusDetail)
    {


        SqlCommand insSyllabus = new SqlCommand("insert into Syllabus (Syllabus_Name,Syllabus_Detail) values(@Syllabus,@SyllabusDetail)", con);
        insSyllabus.Parameters.AddWithValue("@Syllabus", syllabus);
        insSyllabus.Parameters.AddWithValue("@SyllabusDetail", syllabusDetail);
        con.Open();
        try
        {
            insSyllabus.ExecuteNonQuery();
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
        finally
        {
            con.Close();
        }
    }

}


