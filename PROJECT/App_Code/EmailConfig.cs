using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;

/// <summary>
/// Summary description for EmailConfig
/// </summary>
public class EmailConfig
{
    public EmailConfig()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool SendMail(string emailid, string body, string subject)
    {
        MailMessage mail = new MailMessage();
        try
        {
            SmtpClient smtp = new SmtpClient("192.185.6.230");
            mail.From = new MailAddress("ab78727@gnsonlinedemo.com", "NooLearn");
            mail.To.Add(emailid);

            mail.Subject = subject;
            mail.Body = body;

            smtp.Port = 25;

            //smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"]);
            smtp.Credentials = new System.Net.NetworkCredential("ab78727@gnsonlinedemo.com", "Noolearn@123");
            mail.IsBodyHtml = true;
            smtp.EnableSsl = false;
            smtp.Send(mail);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }



    public static bool SendMailStaticMode(string emailid, string body, string subject)
    {
        MailMessage mail = new MailMessage();
        try
        {
            SmtpClient smtp = new SmtpClient("192.185.6.230");
            mail.From = new MailAddress("ab78727@gnsonlinedemo.com", "NooLearn");
            mail.To.Add(emailid);

            mail.Subject = subject;
            mail.Body = body;

            smtp.Port = 25;

            //smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["smtpUser"], ConfigurationManager.AppSettings["smtpPass"]);
            smtp.Credentials = new System.Net.NetworkCredential("ab78727@gnsonlinedemo.com", "Noolearn@123");
            mail.IsBodyHtml = true;
            smtp.EnableSsl = false;
            smtp.Send(mail);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}