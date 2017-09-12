using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using MailSenderApi.Models;
using Simplify.Mail;
using System.Net.Mail;

namespace MailSenderApi.Controllers
{
    /// <summary>
    /// Main API controller. Contains all the logic of callse to the database
    /// </summary>
    public class MailsController : ApiController
    {
        MailDb db = new MailDb();
        /// <summary>
        /// GET Request method which send data with mails in json form
        /// </summary>
        /// <returns>All sent mails from DB</returns>
        // GET: api/Mails
        public List<SentMail> GetMails()
        {
            return db.SentMails.ToList();
        }

        /// <summary>
        /// POST Request method. Form new created mail and all recipient and put it into database
        /// </summary>
        /// <param name="mails">Object that come from ui and contain recipients, subject and body</param>
        /// <returns>Message if sending was success or not</returns>
        // POST: api/Mails
        [ResponseType(typeof(MailData))]
        public string PostMails(MailData mails)
        {
            var result = true;
            var failedMessage = "";
            try
            {
                MailSender.Default.Send("***YOUR MAIL***@gmail.com", mails.Recipients, mails.Subject, mails.Body);
            }
            catch (SmtpException e)
            {
                result = false;
                failedMessage = e.Message;
            }
            Mail mail = new Mail() { Body = mails.Body, Subject = mails.Subject, SendingDate = DateTime.Now, Result = result, FailedMessage = failedMessage};
            db.Mails.Add(mail);
            foreach (var recipient in mails.Recipients)
            {
                db.SentMails.Add(new SentMail() {Recipient = recipient, Mail = mail});
            }

            db.SaveChanges();
            if (result)
                return "Message successfully sended";           
            return "Message not sended. " + failedMessage;
        }       
    }
}