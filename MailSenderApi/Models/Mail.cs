using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailSenderApi.Models
{
    /// <summary>
    /// Model of data representation of Mails table in DB
    /// </summary>
    public class Mail
    {
        public Mail()
        {
            SentMails = new HashSet<SentMail>();
        }
        [Key]
        public int MailId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendingDate { get; set; }
        public bool Result { get; set; }
        public string FailedMessage { get; set; }

        public virtual ICollection<SentMail> SentMails { get; set; }
    }
}