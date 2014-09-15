using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ContactManager.Model
{
   public class Contact
    {
        public Contact()
        {
            Emails = new List<Email>();
            Telephones = new List<Telephone>();
            Tags = new List<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        [ScriptIgnore]
        public DateTime DateUpdated { get; set; }
        [NotMapped]
        public string FormatedDay { get { return DateUpdated.ToString("yyyy.M.d"); } }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Telephone> Telephones { get; set; }
    }
}
