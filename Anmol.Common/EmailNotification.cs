using System;
using System.Configuration;
using System.Net.Mail;

namespace _Anmol.Common
{
    public class EmailNotification
    {

        /// <summary>
        /// Sends the mail message.
        /// </summary>
        /// <param name="recipient">The recipient.</param>
        /// <param name="bcc">The BCC.</param>
        /// <param name="cc">The cc.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="emailSetting">The email setting.</param>
        /// <param name="attachment"></param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        ///  public static bool SendMailMessage(string recipient, string bcc, string cc, string subject, LoginModel model, string attachment)
        ///  

        public static bool SendMailMessage(string recipient, string subject, EmailSetting emailSetting, string HTMLString, string attachment = "", string bcc = "", string cc = "")
        {
            if (string.IsNullOrEmpty(emailSetting.FromEmail))
            {
                return true;
            }

            // Instantiate a new instance of MailMessage 
            MailMessage mailMessage = new MailMessage();

            // Set the sender address of the mail message 
            mailMessage.From = new MailAddress(emailSetting.FromEmail, emailSetting.FromName);

            // Set the recipient address of the mail message 
            // mailMessage.To.Add(new MailAddress(recipient));
            if (!string.IsNullOrEmpty(recipient))
            {
                string[] strRecipient = recipient.Replace(";", ",").TrimEnd(',').Split(new char[] { ',' });

                // Set the Bcc address of the mail message 
                for (int intCount = 0; intCount < strRecipient.Length; intCount++)
                {
                    mailMessage.To.Add(new MailAddress(strRecipient[intCount]));
                }
            }

            // Check if the bcc value is nothing or an empty string 
            if (!string.IsNullOrEmpty(bcc))
            {
                string[] strBCC = bcc.Split(new char[] { ',' });

                // Set the Bcc address of the mail message 
                for (int intCount = 0; intCount < strBCC.Length; intCount++)
                {
                    mailMessage.Bcc.Add(new MailAddress(strBCC[intCount]));
                }
            }

            // Check if the cc value is nothing or an empty value 
            if (!string.IsNullOrEmpty(cc))
            {
                // Set the CC address of the mail message 
                string[] strCC = cc.Split(new char[] { ',' });
                for (int intCount = 0; intCount < strCC.Length; intCount++)
                {
                    mailMessage.CC.Add(new MailAddress(strCC[intCount]));
                }
            }

            // Set the subject of the mail message 
            mailMessage.Subject = subject;

            // Set the body of the mail message 
            mailMessage.Body = HTMLString; // gettemplatebody() ;

            // Set the format of the mail message body as HTML 
            mailMessage.IsBodyHtml = true;

            // Set the priority of the mail message to normal 
            mailMessage.Priority = MailPriority.Normal;

            // Instantiate a new instance of SmtpClient 
            var smtpClient = new SmtpClient();

            if (attachment != null && attachment != "")
                mailMessage.Attachments.Add(new Attachment(attachment));
            try
            {
                smtpClient.EnableSsl = true;
                smtpClient.Host = emailSetting.EmailHostName;
                smtpClient.Port = emailSetting.EmailPort;
                smtpClient.Credentials = new System.Net.NetworkCredential(emailSetting.FromEmail, emailSetting.EmailPassword);

                // Send the mail message 
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        /// <summary>
        /// Class EmailSetting.
        /// </summary>
        public class EmailSetting
        { /// <summary>
          /// Gets or sets from email.
          /// </summary>
          /// <value>From email.</value>
            public string FromEmail
            {
                get
                {
                    return ConfigurationManager.AppSettings["Email"];
                }
                set
                {
                    value = ConfigurationManager.AppSettings["Email"];
                }
            }

            /// <summary>
            /// Gets or sets the name of the email host.
            /// </summary>
            /// <value>The name of the email host.</value>
            public string EmailHostName
            {
                get
                {
                    return ConfigurationManager.AppSettings["HostName"];
                }
                set
                {
                    value = ConfigurationManager.AppSettings["HostName"];
                }
            }

            /// <summary>
            /// Gets or sets the email port.
            /// </summary>
            /// <value>The email port.</value>
            public int EmailPort
            {
                get
                {
                    return Convert.ToInt32(ConfigurationManager.AppSettings["PortNumber"]);
                }
                set
                {
                    value = Convert.ToInt32(ConfigurationManager.AppSettings["PortNumber"]);
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether [email enable SSL].
            /// </summary>
            /// <value><c>true</c> if [email enable SSL]; otherwise, <c>false</c>.</value>
            public bool EmailEnableSsl { get; set; }

            /// <summary>
            /// Gets or sets the email user-name.
            /// </summary>
            /// <value>The email user name.</value>
            public string EmailUsername
            {
                get
                {
                    return ConfigurationManager.AppSettings["EmailUsername"];
                }
                set
                {
                    value = ConfigurationManager.AppSettings["EmailUsername"];
                }
            }

            /// <summary>
            /// Gets or sets the email password.
            /// </summary>
            /// <value>The email password.</value>
            public string EmailPassword
            {
                get { return ConfigurationManager.AppSettings["Passsword"]; }
                set { value = ConfigurationManager.AppSettings["Passsword"]; }
            }

            /// <summary>
            /// Gets or sets from name.
            /// </summary>
            /// <value>From Name</value>
            public string FromName
            {
                get { return ConfigurationManager.AppSettings["FromName"]; }
                set { value = ConfigurationManager.AppSettings["FromName"]; }
            }
        }

    }
}

