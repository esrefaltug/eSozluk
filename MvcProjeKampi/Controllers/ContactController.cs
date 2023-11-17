using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult ContactPartial()
        {
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = messageManager.GetListSendbox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = messageManager.GetListInbox().Count();
            ViewBag.receiverMail = receiverMail;

            var readMessage = messageManager.GetListInbox().Where(m => m.IsRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = messageManager.GetListInbox().Where(m => m.IsRead == false).Count();
            ViewBag.unreadMessage = unreadMessage;

            return PartialView();
        }
    }
}