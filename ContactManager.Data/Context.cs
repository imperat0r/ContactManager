using ContactManager.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Data
{
    public class Context:DbContext
    {
        public Context()
            : base("DefaultConnection")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Telephone> Telephones { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public ObjectContext ObjectContext
        {
            get
            {
                //With EF 6.0.2 this would throw an exception if the DB didn't exist.
                //With EF 6.1.0 this creates the database, but doesn't seed the DB.
                return ((IObjectContextAdapter)this).ObjectContext;
            }
        }

        private static readonly Object syncObj = new Object();
        public static bool InitializeDatabase()
        {
            lock (syncObj)
            {
                using (var temp = new Context())
                {
                    if (temp.Database.Exists()) return true;

                    var initializer = new MigrateDatabaseToLatestVersion<Context, ContactManager.Data.Migrations.Configuration>();
                    Database.SetInitializer(initializer);
                    try
                    {
                        temp.Database.Initialize(true);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        //Handle Error in some way
                        return false;
                    }
                }
            }
        }

   
    }
}
