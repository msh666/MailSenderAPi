using System.Web.Mvc;

namespace MailSenderApi.Controllers
{
    /// <summary>
    /// Controller that show particular View
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Show Create Mail view
        /// </summary>
        /// <returns>View</returns>
        public ActionResult CreateMail()
        {
            return View();
        }
        /// <summary>
        /// Show Sended Mails View
        /// </summary>
        /// <returns>View</returns>
        public ActionResult SendedMails()
        {
            return View();
        }
    }
}
