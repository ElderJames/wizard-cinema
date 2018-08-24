using System;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Wizard.Infrastructures
{
    public class EmailHelper
    {
        #region field

        private readonly string serverProdiver = null;
        private readonly string userName = null;
        private readonly string password = null;
        private readonly string from = null;
        private readonly int port = 0;
        private readonly ILogger<EmailHelper> logger = null;

        #endregion field

        #region ctor

        static EmailHelper()
        {
        }

        #endregion ctor

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sender">发送人</param>
        /// <param name="to">收件人邮箱地址</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="attachments">附件</param>
        public static void Send(MailAddress sender, string to, string subject, string body, params Attachment[] attachments)
        {
            SmtpClient mailClient = new SmtpClient(serverProdiver);
            if (port > 0)
                mailClient.Port = port;

            mailClient.UseDefaultCredentials = true;
            mailClient.Credentials = new System.Net.NetworkCredential(userName, password);

            try
            {
                using (var mailMessage = new MailMessage(sender, new MailAddress(to)))
                {
                    mailMessage.IsBodyHtml = true;
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;

                    foreach (var attachment in attachments)
                    {
                        mailMessage.Attachments.Add(attachment);
                    }

                    mailClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                logger?.Error("发送邮件出错了", ex);
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sender">发送人</param>
        /// <param name="to">收件人邮箱地址</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="attachments">附件</param>
        public static void Send(MailAddress sender, string to, string subject, AlternateView body, params Attachment[] attachments)
        {
            SmtpClient mailClient = new SmtpClient(serverProdiver);
            if (port > 0)
                mailClient.Port = port;

            mailClient.UseDefaultCredentials = true;
            mailClient.Credentials = new System.Net.NetworkCredential(userName, password);

            try
            {
                using (var mailMessage = new MailMessage(sender, new MailAddress(to)))
                {
                    mailMessage.IsBodyHtml = true;
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.Subject = subject;
                    mailMessage.AlternateViews.Add(body);

                    foreach (var attachment in attachments)
                    {
                        mailMessage.Attachments.Add(attachment);
                    }

                    mailClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                logger?.Error("发送邮件出错了", ex);
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">收件人邮箱地址</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="attachments">附件</param>
        public static void Send(string to, string subject, string body, params Attachment[] attachments)
        {
            SmtpClient mailClient = new SmtpClient(serverProdiver);
            if (port > 0)
                mailClient.Port = port;

            mailClient.UseDefaultCredentials = true;
            mailClient.Credentials = new System.Net.NetworkCredential(userName, password);

            try
            {
                using (var mailMessage = new MailMessage(from, to, subject, body))
                {
                    mailMessage.IsBodyHtml = true;
                    mailMessage.BodyEncoding = Encoding.UTF8;

                    foreach (var attachment in attachments)
                    {
                        mailMessage.Attachments.Add(attachment);
                    }

                    mailClient.Send(mailMessage);
                }
            }
            catch (Exception ex)
            {
                logger?.Error("发送邮件出错了", ex);
            }
        }
    }
}
