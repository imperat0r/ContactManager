using ContactManager.Data.Repository;
using ContactManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ContactRepository _contactRepository { get; set; }
    }
}