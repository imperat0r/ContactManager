namespace ContactManager.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ContactManager.Model;

    public sealed class Configuration : DbMigrationsConfiguration<ContactManager.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        
        }

        protected override void Seed(ContactManager.Data.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Contacts.AddOrUpdate(
            p => p.Id,
            new Contact { Name = "Vlado", Surname = "Pandžić", Address = "Alkarska 4", DateUpdated = DateTime.Now },
            new Contact { Name = "Ante", Surname = "Antić", Address = "Mihanovićeva 5", DateUpdated = DateTime.Now },
            new Contact { Name = "Petra", Surname = "Petrić", Address = "Vukovarska 7", DateUpdated = DateTime.Now },
            new Contact { Name = "Josip", Surname = "Matić", Address = "Vinkovačka 118", DateUpdated = DateTime.Now }
          );
            context.Emails.AddOrUpdate(
            p => p.Id,
            new Email { ContactId = 1, Name = "pandzic.vlado@gmail.com" },
            new Email { ContactId = 1, Name = "pandzic.vlado@outlook.com" },
            new Email { ContactId = 2, Name = "ante.antic@gmail.com" },
            new Email { ContactId = 3, Name = "josip.matic@outlook.com" }
          );
            context.Telephones.AddOrUpdate(
           p => p.Id,
           new Telephone { ContactId = 1, Number = "098668337" },
           new Telephone { ContactId = 1, Number = "021325664" },
           new Telephone { ContactId = 2, Number = "021123456" },
           new Telephone { ContactId = 3, Number = "098123456" }
         );
            context.Tags.AddOrUpdate(
           p => p.Id,
           new Tag { ContactId = 1, text = "Ja" },
           new Tag { ContactId = 2, text = "Prijatelj" },
           new Tag { ContactId = 2, text = "Obitelj" },
           new Tag { ContactId = 3, text = "Rodbina" }
         );
            context.SaveChanges();
        }
    }
}
