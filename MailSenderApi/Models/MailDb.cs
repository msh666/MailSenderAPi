using System.Data.Entity;

namespace MailSenderApi.Models
{
    public class MailDb : DbContext
    {
        public MailDb()
            : base("name=MailDb")
        {
        }

        public DbSet<Mail> Mails { get; set; }
        public DbSet<SentMail> SentMails { get; set; }
    }
}