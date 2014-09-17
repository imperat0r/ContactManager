using ContactManager.CustomActions;
using ContactManager.Data.Repository;
using ContactManager.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {
        public ContactController()
        {
            _contactRepository = new ContactRepository();
        }
        public JsonResult GetAllContacts()
        {

            List<Contact> contacts = _contactRepository.GetAllContacts().ToList();
            return Json(contacts);
        }
        [HttpPost, ActionName("DeleteContacts")]
        public HttpResponseMessage Delete(string[] arrayOfContacts)
        {
            var numberOfDeletes=0;
            foreach (var id in arrayOfContacts)
            {
                _contactRepository.DeleteContact(id);
                numberOfDeletes++;
            }
            if (numberOfDeletes == arrayOfContacts.Count())
                return new HttpResponseMessage(System.Net.HttpStatusCode.NoContent);
            return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
        }

        public void AddContact(Contact contactToAdd)
        {
            contactToAdd.DateUpdated = DateTime.Now;
            _contactRepository.AddContact(contactToAdd);
        }

        public ActionResult GetContact(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = _contactRepository.GetContactFullGraph(id);
            if (contact == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return new JsonNetResult(contact);
        }
        public void UpdateContact(Contact contact)
        {
            contact.DateUpdated = DateTime.Now;
            _contactRepository.UpdateContact(contact);
        }
        public JsonResult GetTags()
        {

            var tags = _contactRepository.GetTags().Select(x => new
            {
                x.text
            }); ;
            return Json(tags);
        }
        public JsonResult getAllContactsWithTags(string[] arrayOfTags)
        {
            var contacts = _contactRepository.GetContactsWithTag(arrayOfTags);
            return Json(contacts);
        }
        

        public ContactRepository _contactRepository { get; set; }
    }
}