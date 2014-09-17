using ContactManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public Contact GetContactFullGraph(int? id)
        {
            return db.Contacts.Where(x => x.Id == id).Include("Emails").Include("Telephones").Include("Tags").FirstOrDefault();
        }

        public void UpdateContact(Contact contact)
        {

            var contactFromDb = db.Contacts.Where(x => x.Id == contact.Id).Include("Emails").Include("Tags").Include("Telephones").FirstOrDefault();

            contactFromDb.Address = contact.Address;
            contactFromDb.Name = contact.Name;
            contactFromDb.Surname = contact.Surname;
            UpdateEmailChildCollection(contact, contactFromDb);
            UpdateTelephonesChildCollection(contact, contactFromDb);
            UpdateTagsChildCollection(contact, contactFromDb);

            contactFromDb.DateUpdated = contact.DateUpdated;
            ///   contactFromDb.Tags = contact.Tags;

            db.SaveChanges();
        }

        private void UpdateTagsChildCollection(Contact contact, Contact contactFromDb)
        {
            var tagsToDelete = (from tag in contactFromDb.Tags
                                let item = contact.Tags.SingleOrDefault(i => i.Id == tag.Id)
                                where item == null
                                select tag).ToList();
            if (tagsToDelete.Any())
            {
                foreach (var tag in tagsToDelete)
                {
                    db.Entry(tag).State = EntityState.Deleted;
                }
            }
            foreach (var tag in contact.Tags)
            {
                if (tag.Id > 0)
                {
                    var tagInDb = contactFromDb.Tags.Single(e => e.Id == tag.Id);
                    db.Entry(tagInDb).CurrentValues.SetValues(tag);
                    db.Entry(tagInDb).State = EntityState.Modified;
                }
                else
                {
                    tag.ContactId = contact.Id;
                    db.Tags.Add(tag);
                }
            }
        }

        private void UpdateTelephonesChildCollection(Contact contact, Contact contactFromDb)
        {
            var telephonesToDelete = (from telephone in contactFromDb.Telephones
                                      let item = contact.Telephones.SingleOrDefault(i => i.Id == telephone.Id)
                                      where item == null
                                      select telephone).ToList();
            if (telephonesToDelete.Any())
            {
                foreach (var telephone in telephonesToDelete)
                {
                    db.Entry(telephone).State = EntityState.Deleted;
                }
            }
            foreach (var telephone in contact.Telephones)
            {
                if (telephone.Id > 0)
                {
                    var telephoneInDb = contactFromDb.Telephones.Single(e => e.Id == telephone.Id);
                    db.Entry(telephoneInDb).CurrentValues.SetValues(telephone);
                    db.Entry(telephoneInDb).State = EntityState.Modified;
                }
                else
                {
                    telephone.ContactId = contact.Id;
                    db.Telephones.Add(telephone);
                }
            }
        }

        private void UpdateEmailChildCollection(Contact contact, Contact contactFromDb)
        {
            var emailsToDelete = (from email in contactFromDb.Emails
                                  let item = contact.Emails.SingleOrDefault(i => i.Id == email.Id)
                                  where item == null
                                  select email).ToList();
            if (emailsToDelete.Any())
            {
                foreach (var email in emailsToDelete)
                {
                    db.Entry(email).State = EntityState.Deleted;
                }
            }
            foreach (var email in contact.Emails)
            {
                if (email.Id > 0)
                {
                    var emailInDb = contactFromDb.Emails.Single(e => e.Id == email.Id);
                    db.Entry(emailInDb).CurrentValues.SetValues(email);
                    db.Entry(emailInDb).State = EntityState.Modified;
                }
                else
                {
                    email.ContactId = contact.Id;
                    db.Emails.Add(email);
                }
            }
        }


        public IQueryable<Tag> GetTags()
        {
            return db.Tags.GroupBy(x => x.text).Select(x => x.FirstOrDefault());
        }

        public List<Contact> GetContactsWithTag(string[] tags)
        {
            if (tags!=null)
            {
                var tagss = tags.ToList();
                var contacts = new List<Contact>();
                foreach (var tag in tags)
                {
                    var matchedContacts = db.Contacts.Where(x => x.Tags.Any(y => y.text == tag)).ToList(); ;
                    if (matchedContacts != null)
                        contacts.AddRange(matchedContacts);
                }
                return contacts;
            }
            return db.Contacts.ToList();

        }
    }
}
