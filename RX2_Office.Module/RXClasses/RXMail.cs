

using System;

using System.Net;
using System.Net.Mail;
using DevExpress.ExpressApp;


namespace RX2_Office.Module.rxClasses
{
    class RxMail
    {

 
        public string Body { get; set; }
        public string MailTo { get; set; }
        public string MailFrom { get; set; }
        public string Subject { get; set; }


        public SmtpException sendmail()
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(MailFrom);
            message.To.Add(MailTo);                         //ConfigurationSettings.AppSettings["RequesEmail"].ToString());
            message.Subject = Subject;
            message.IsBodyHtml = true;
            message.Body = Body;

            SmtpClient smtpClient = new SmtpClient();
            //smtpClient.UseDefaultCredentials = true;

            //smtpClient.Host = ConfigurationSettings.AppSettings["SMTP"].ToString();
            //smtpClient.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["PORT"].ToString());
            //smtpClient.Host = "mex09.emailsrvr.com";
            smtpClient.Host = "192.168.100.33";

            // smtpClient.Host = "ra.atlanticbiologicals.com";
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Port = 25;
            smtpClient.EnableSsl = false;
      
            // smtpClient.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["USERNAME"].ToString(), ConfigurationSettings.AppSettings["PASSWORD"].ToString());
            //smtpClient.Credentials = new System.Net.NetworkCredential("officerx@atlanticbiologicals.com","@tlantic123");
            //smtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;
            // smtpClient.Credentials();

            try
            {
                smtpClient.Send(message);
            }

            catch(SmtpException ex)
            {
                return ex;
            }
            SmtpException ex1 = new SmtpException();
            ex1 = null;
           return ex1; 
                   

           

        }
    }
}
