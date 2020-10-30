using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.VisualBasic;
using System.Net;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Utility
{
    public class ShareMail
    {
        public string SendEmail(string toAddress)
        {


            Random rn = new Random();
            string no = rn.Next(100000).ToString();
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.UseDefaultCredentials = true;
            mail.From = new MailAddress("akmanagement112@gmail.com"); // From

            mail.To.Add(toAddress);//  To
            mail.Subject = "Registration Completed";
            mail.Body = "Thanks for Registering!! \n Your Password is:"+no;

           


            //mail.Attachments.Add(new Attachment(@attach));
            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment("Test.txt");
            //mail.Attachments.Add(attachment);


            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("akmanagement112@gmail.com", "@ak12345");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            return no;

        }
    }
}
