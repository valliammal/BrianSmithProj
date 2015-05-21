using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class QuestionUpload : System.Web.UI.Page
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
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearAll();
    }

    protected bool FileUploader()
    {
        if (FileUpload1.HasFile)
        {
            string filename = Path.GetFileName(FileUpload1.FileName);
            if (filename != "")
            {
                // FileUpload1.SaveAs(Server.MapPath("~/QuestionImages/" + filename));
                FileUpload1.SaveAs(Server.MapPath("~/User/") + GlobVar.PPath);
                return true;
            }
            else
            {
                return false;
            }


        }
        else
        {
            return false;
        }

    }
    public bool QuesImageUpload()
    {
        string query = "select max(Ques_ID) as 'Count' from Questions";
        DataTable dt = new DataTable();
        dt = dc.GetDataTable(query);
        if (dt != null)
        {
            string maxID = dt.Rows[0]["Count"].ToString();
            if (maxID != "")
            {
                int count = Convert.ToInt32(maxID);
                count++;
                string fileName = "Question_" + count + ".jpeg";
                string foldname = "Question\\";
                string picpath = foldname + fileName;
                GlobVar.PPath = picpath;
                if (FileUploader())
                {
                    Img1.ImageUrl = picpath;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                string fileName = "Question_1" + ".jpeg";
                string foldname = "Question\\";
                string picpath = foldname + fileName;
                GlobVar.PPath = picpath;
                if (FileUploader())
                {
                    Img1.ImageUrl = picpath;
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        else
        {
            return false;
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

    }

    public void ClearAll()
    {
        txtQues.Text = string.Empty;
        txtRight.Text = string.Empty;
        txtW1.Text = string.Empty;
        txtW2.Text = string.Empty;
        txtW3.Text = string.Empty;
        //    chkView.Checked = false;
        Img1.ImageUrl = "";
        GlobVar.PPath = "";
        GlobVar.ques_ID = 0;
        GlobVar.gLobal_R = string.Empty;
        GlobVar.gLobal_W1 = string.Empty;
        GlobVar.gLobal_W2 = string.Empty;
        GlobVar.gLobal_W3 = string.Empty;
        lblUploadMsg1.Text = string.Empty;
        lblUploadMsg2.Text = string.Empty;
        lblUploadMsg3.Text = string.Empty;
        lblUploadMsg4.Text = string.Empty;
        txtDistractor1.Text = string.Empty;
        txtDistractor2.Text = string.Empty;
        txtDistractor3.Text = string.Empty;
        txtRightDetail.Text = string.Empty;


    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (QuesImageUpload())
        {
            if (RightUpload() && Wrong1Upload() && Wrong2Upload() && Wrong3Upload())
            {
                string postedBy = Session["User"].ToString();
                string query = "insert into Questions (Question,PicPath,PostedBy)values('" + txtQues.Text.Trim() + "','" + GlobVar.PPath + "','" + postedBy + "')";
                int i = dc.ExecuteQuery(query);
                if (i > 0)
                {

                    string answerQuery = "insert into Answers (Answer,Answer_Detail,Mp3_Name,Status,Ques_ID,PostedBy) values('" + txtRight.Text.Trim() + "','" + txtRightDetail.Text.Trim() + "','" + GlobVar.gLobal_R + "','R','" + GlobVar.ques_ID + "','" + postedBy + "'),('" + txtW1.Text.Trim() + "','" + txtDistractor1.Text.Trim() + "','" + GlobVar.gLobal_W1 + "','W','" + GlobVar.ques_ID + "','" + postedBy + "'),('" + txtW2.Text.Trim() + "','" + txtDistractor2.Text.Trim() + "','" + GlobVar.gLobal_W2 + "','W','" + GlobVar.ques_ID + "','" + postedBy + "'),('" + txtW3.Text.Trim() + "','" + txtDistractor3.Text.Trim() + "','" + GlobVar.gLobal_W3 + "','W','" + GlobVar.ques_ID + "','" + postedBy + "')";
                    int count = dc.ExecuteQuery(answerQuery);
                    if (count > 0)
                    {
                        lblResponse.ForeColor = System.Drawing.Color.Green;
                        lblResponse.Text = "Question is uploaded successfully.";
                        reset();

                    }
                    else
                    {
                        Response.Write("<script>alert('Question is not uploaded.')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Question is not uploaded. Try again.')</script>");
                }


            }
            else
            {
                Response.Write("<script>alert('Mp3 File options that Files should be in .mp3 format and less than 100Kb')</script>");
            }
        }
        else
        {
            lblResponse.Text = "First upload a image for question.";
            lblResponse.ForeColor = System.Drawing.Color.Red;
        }
    }


    public void reset()
    {
        Img1.ImageUrl = "~/img/nopic.png";
        txtRight.Text = "";
        txtW1.Text = "";
        txtW2.Text = "";
        txtW3.Text = "";
        txtRightDetail.Text = "";
        txtDistractor1.Text = "";
        txtDistractor2.Text = "";
        txtDistractor3.Text = "";
    }

    public bool RightUpload()
    {
        string query = "select max(Ques_ID) as 'Count' from Questions";
        DataTable dt = new DataTable();
        dt = dc.GetDataTable(query);
        if (dt != null)
        {
            string maxID = dt.Rows[0]["Count"].ToString();
            if (maxID != "")
            {
                int count = Convert.ToInt32(maxID);
                int ansCount = count + 1;
                GlobVar.ques_ID = ansCount;
                int ans_ID = 1;
                string fileName = "Ans_" + ansCount + ans_ID + ".mp3";
                string folderName = "Option\\";
                string rightOption = folderName + fileName;
                GlobVar.gLobal_R = rightOption;
                if (FileUploaderMp3Right())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            else
            {
                string fileName = "Ans_" + 11 + ".mp3";
                string foldername = "Option\\";
                string rightOption = foldername + fileName;
                GlobVar.ques_ID = 1;
                GlobVar.gLobal_R = rightOption;
                if (FileUploaderMp3Right())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }

    protected bool FileUploaderMp3Right()
    {

        if (FileUploadMp3Right.HasFile)
        {
            string filename = Path.GetFileName(FileUploadMp3Right.FileName);
            string fileExtension = Path.GetExtension(FileUploadMp3Right.FileName);
            if (fileExtension.ToLower() == ".mp3")
            {
                int fileSize = FileUploadMp3Right.PostedFile.ContentLength;
                if (fileSize < 102400)
                {
                    FileUploadMp3Right.SaveAs(Server.MapPath("~/User/") + GlobVar.gLobal_R);
                    //lblUploadMsg1.Text = "File is uploaded";
                    //lblUploadMsg1.ForeColor = System.Drawing.Color.Green;
                    return true;
                }
                else
                {
                    Response.Write("<script>alert('File size must be less than 100KB.')</script>");
                    return false;
                }
            }
            else
            {
                Response.Write("<script>alert('File must be in Mp3 format.')</script>");
                return false;
            }


        }
        else
        {
            return false;
        }
    }



    public bool Wrong1Upload()
    {
        string query = "select max(Ques_ID) as 'Count' from Questions";
        DataTable dt = new DataTable();
        dt = dc.GetDataTable(query);
        if (dt != null)
        {
            string maxID = dt.Rows[0]["Count"].ToString();
            if (maxID != "")
            {
                int count = Convert.ToInt32(maxID);
                int ansCount = count + 1;
                GlobVar.ques_ID = ansCount;
                int ans_ID = 2;
                string fileName = "Ans_" + ansCount + ans_ID + ".mp3";
                string folderName = "Option\\";
                string wrongOption = folderName + fileName;
                GlobVar.gLobal_W1 = wrongOption;
                if (FileUploaderMp3Wrong1())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                string fileName = "Ans_" + 12 + ".mp3";
                string foldername = "Option\\";
                string wrongOption = foldername + fileName;
                GlobVar.gLobal_W1 = wrongOption;
                if (FileUploaderMp3Wrong1())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
    }

    protected bool FileUploaderMp3Wrong1()
    {

        if (FileUploadMp3Wrong1.HasFile)
        {

            string filename = Path.GetFileName(FileUploadMp3Wrong1.FileName);
            string fileExtension = Path.GetExtension(FileUploadMp3Wrong1.FileName);
            if (fileExtension.ToLower() == ".mp3")
            {
                int fileSize = FileUploadMp3Wrong1.PostedFile.ContentLength;
                if (fileSize < 102400)
                {
                    FileUploadMp3Wrong1.SaveAs(Server.MapPath("~/User/") + GlobVar.gLobal_W1);
                    //lblUploadMsg2.Text = "File is uploaded";
                    //lblUploadMsg2.ForeColor = System.Drawing.Color.Green;
                    return true;
                }
                else
                {
                    Response.Write("<script>alert('File size must be less than 100KB.')</script>");
                    return false;
                }
            }
            else
            {
                Response.Write("<script>alert('File must be in Mp3 format.')</script>");
                return false;
            }
        }
        else
        {
            return false;
        }
    }


    public bool Wrong2Upload()
    {
        string query = "select max(Ques_ID) as 'Count' from Questions";
        DataTable dt = new DataTable();
        dt = dc.GetDataTable(query);
        if (dt != null)
        {
            string maxID = dt.Rows[0]["Count"].ToString();
            if (maxID != "")
            {
                int count = Convert.ToInt32(maxID);
                int ansCount = count + 1;
                GlobVar.ques_ID = ansCount;
                int ans_ID = 3;
                string fileName = "Ans_" + ansCount + ans_ID + ".mp3";
                string folderName = "Option\\";
                string wrongOption = folderName + fileName;
                GlobVar.gLobal_W2 = wrongOption;
                if (FileUploaderMp3Wrong2())
                { return true; }
                else { return false; }
            }


            else
            {
                string fileName = "Ans_" + 13 + ".mp3";
                string foldername = "Option\\";
                string wrongOption = foldername + fileName;
                GlobVar.gLobal_W2 = wrongOption;
                if (FileUploaderMp3Wrong2())
                { return true; }
                else { return false; }
            }
        }
        else
        { return false; }
    }

    protected bool FileUploaderMp3Wrong2()
    {

        if (FileUploadMp3Wrong2.HasFile)
        {
            string filename = Path.GetFileName(FileUploadMp3Wrong2.FileName);
            string fileExtension = Path.GetExtension(FileUploadMp3Wrong2.FileName);
            if (fileExtension.ToLower() == ".mp3")
            {
                int fileSize = FileUploadMp3Wrong2.PostedFile.ContentLength;
                if (fileSize < 102400)
                {
                    FileUploadMp3Wrong2.SaveAs(Server.MapPath("~/User/") + GlobVar.gLobal_W2);
                    //lblUploadMsg3.Text = "File is uploaded";
                    //lblUploadMsg3.ForeColor = System.Drawing.Color.Green;
                    return true;
                }
                else
                {
                    Response.Write("<script>alert('File size must be less than 100KB.')</script>");
                    return false;
                }
            }
            else
            {
                Response.Write("<script>alert('File must be in Mp3 format.')</script>");
                return false;
            }
        }
        else
        {
            return false;
        }
    }



    public bool Wrong3Upload()
    {
        string query = "select max(Ques_ID) as 'Count' from Questions";
        DataTable dt = new DataTable();
        dt = dc.GetDataTable(query);
        if (dt != null)
        {
            string maxID = dt.Rows[0]["Count"].ToString();
            if (maxID != "")
            {
                int count = Convert.ToInt32(maxID);
                int ansCount = count + 1;
                GlobVar.ques_ID = ansCount;
                int ans_ID = 4;
                string fileName = "Ans_" + ansCount + ans_ID + ".mp3";
                string folderName = "Option\\";
                string wrongOption = folderName + fileName;
                GlobVar.gLobal_W3 = wrongOption;
                if (FileUploaderMp3Wrong3())
                { return true; }
                else { return false; }
            }


            else
            {
                string fileName = "Ans_" + 14 + ".mp3";
                string foldername = "Option\\";
                string wrongOption = foldername + fileName;
                GlobVar.gLobal_W3 = wrongOption;
                if (FileUploaderMp3Wrong3())
                { return true; }
                else { return false; }
            }
        }
        else
        { return false; }
    }

    protected bool FileUploaderMp3Wrong3()
    {

        if (FileUploadMp3Wrong3.HasFile)
        {
            string filename = Path.GetFileName(FileUploadMp3Wrong3.FileName);
            string fileExtension = Path.GetExtension(FileUploadMp3Wrong3.FileName);
            if (fileExtension.ToLower() == ".mp3")
            {
                int fileSize = FileUploadMp3Wrong3.PostedFile.ContentLength;
                if (fileSize < 102400)
                {
                    FileUploadMp3Wrong3.SaveAs(Server.MapPath("~/User/") + GlobVar.gLobal_W3);
                    //lblUploadMsg4.Text = "File is uploaded";
                    //lblUploadMsg4.ForeColor = System.Drawing.Color.Green;
                    return true;
                }
                else
                {
                    Response.Write("<script>alert('File size must be less than 100KB.')</script>");
                    return false;
                }
            }
            else
            {
                Response.Write("<script>alert('File must be in Mp3 format.')</script>");
                return false;
            }

        }
        else
        {
            return false;
        }
    }

}