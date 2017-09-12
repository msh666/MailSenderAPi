using System.Collections.Generic;

namespace MailSenderApi.Models
{
    /// <summary>
    /// Class which make possible to return custom data from UI whe you send a mail
    /// </summary>
    public class MailData
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> Recipients { get; set; }
    }
}