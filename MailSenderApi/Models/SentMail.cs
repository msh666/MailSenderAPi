using System.ComponentModel.DataAnnotations;

namespace MailSenderApi.Models
{
    /// <summary>
    /// Model of data representation of SentMails table in DB
    /// </summary>
    public class SentMail
    {
        [Key]
        public int SentId { get; set; }
        public string Recipient { get; set; }
        public int MailId { get; set; }

        public virtual Mail Mail { get; set; }
    }
}