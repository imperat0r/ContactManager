ContactManager
==============
Simple application for managing your contacts list. It is SPA application built using Angular JS.
#####Start with initial data
To get started with initial data simply uncomment these lines from Global.asax.cs file:

           // Database.SetInitializer<Context>(new MigrateDatabaseToLatestVersion<ContactManager.Data.Context, ContactManager.Data.Migrations.Configuration>());
           // ContactManager.Data.Context.InitializeDatabase();
It will create database with some already pre-populated data.
#####Currently has  these features:
1. List of all contacts. User is able to see list of all contacts. It has sorting, pagination and searching features.User can search and sort by name, surname, address,date. It also can choose number of results shown per page.
2. Detail contact page. User can edit name, surname, address, tags, emails and telephones.
3. Add contact page. User can add new contact by providing name, surname, address and tags.User can add some custom tag or choose from autocomplete box tags already existing in the database.
4. User can search by tag on home page. If tag is choosen from dropdown search is made on server.
5. All pages are bookmarkable,page transitions are followed by some nice animations and all actions provide some nice feedback to user using loading bar and notifications.
