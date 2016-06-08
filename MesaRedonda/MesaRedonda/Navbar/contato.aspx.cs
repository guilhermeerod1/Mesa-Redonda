using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesaRedonda.Navbar
{
    public partial class contato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEnviar_OnCLick(object sender, EventArgs e)
        {
            EnviarEmail(txtAssunto.Text, txtConteudo.InnerHtml);
        }

        private void EnviarEmail(string assunto, string conteudo)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "adsreges@gmail.com";
            string password = ConfigurationManager.AppSettings["senhaEmail"];
            string emailTo = "adsreges@gmail.com";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = assunto;
                mail.Body = conteudo;
                mail.IsBodyHtml = true;
                
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}