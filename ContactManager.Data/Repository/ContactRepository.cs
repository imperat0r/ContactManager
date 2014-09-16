using ContactManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Data.Repository
{
    public class ContactRepository:IDisposable
    {
        public ContactRepository()
        {
            db = new Context();
        }
        public IQueryable<Contact> GetAllContacts()
        {
            return db.Contacts;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Context db { get; set; }

        public bool DeleteContact(string id)
        {
            try
            {
                var idInt = Convert.ToInt32(id);
                var contact = db.Contacts.Where(x => x.Id == idInt).FirstOrDefault();
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void AddContact(Contact contactToAdd)
        {
            db.Contacts.Add(contactToAdd);
            db.SaveChanges();
        }
    }
}
