# Contacts

To set up the server follow these simple steps.

1. Create a directory somewhere and move to it
  
  C:\...>mkdir code
  C:\...>cd code
  
2. Initialize git for the directory

  C:\...\code>git init
 
3. Pull the project from Github
  
  C:\...\code>git pull https://github.com/cloudcamelopard/Contacts.git
  
4.Change folder

  C:\...\code>cd ContactServer

5. Open the project folder in VS code or other editor

  C:\...\code\ContactServer>code .
  
6. Edit the database connectionstring in appSettings.Development.json or appSettings.json 

  "ConnectionStrings": {
	  "contactsDb": "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = EmailContacts2; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"
  }
  
7. Install entitity framework tools.

C:\...\code\ContactServer>dotnet tool install --global dotnet-ef
  
8. Update (or create database)

  C:\...\code\ContactServer>dotnet ef database update
  
9. Start server

  C:\...\code\ContactServer>dotnet watch run
  
10. Check the line 
  
  Now listening on: https://localhost:44394

11. Open http://localhost:44394 it in a browser

12: Log in using
  
  Username: 'roan'
  Password: 'secret'

  
  



