using System;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Wizard.Infrastructures
{
    public class EmailHelper
    {
        #region field

        private readonly string _serverProdiver;
        private readonly string _userName;
        private readonly string password;
        private readonly string _from;
        private readonly int _port;
        private readonly ILogger<EmailHelper> _logger;

        public EmailHelper(string serverProdiver, string userName, string password, string @from, int port, ILogger<EmailHelper> logger)
        {
            _serverProdiver = serverProdiver;
            _userName = userName;
            this.password = password;
            _from = @from;
            _port = port;
            _logger = logger;
        }

        #endregion field

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sender">发送人</param>
        /// <param name="to">收件人邮箱地址</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="attachments">附件</param>
        public void Send(MailAddress sender, string to, string subject, string body, params Attachment[] attachments)
        {
            SmtpClient mailClient = new SmtpClient(_serverProdiver);
            if (_port > 0)
                mailClient.Port = _port;

            mailClient.UseDefaultCredentials = true;
            mailClient.Credentials = new System.Net.NetworkCredential(_userName, password);

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
                _logger?.LogError("发送邮件出错了", ex);
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
        public void Send(MailAddress sender, string to, string subject, AlternateView body, params Attachment[] attachments)
        {
            SmtpClient mailClient = new SmtpClient(_serverProdiver);
            if (_port > 0)
                mailClient.Port = _port;

            mailClient.UseDefaultCredentials = true;
            mailClient.Credentials = new System.Net.NetworkCredential(_userName, password);

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
                _logger?.LogError("发送邮件出错了", ex);
            }
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="to">收件人邮箱地址</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="attachments">附件</param>
        public void Send(string to, string subject, string body, params Attachment[] attachments)
        {
            SmtpClient mailClient = new SmtpClient(_serverProdiver);
            if (_port > 0)
                mailClient.Port = _port;

            mailClient.UseDefaultCredentials = true;
            mailClient.Credentials = new System.Net.NetworkCredential(_userName, password);

            try
            {
                using (var mailMessage = new MailMessage(_from, to, subject, body))
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
                _logger?.LogError("发送邮件出错了", ex);
            }
        }
    }
}
