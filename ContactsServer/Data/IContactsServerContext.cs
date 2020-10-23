using ContactsServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsServer.Data
{
    public interface IContactsServerContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Contact> Contacts { get; set; }

        int SaveChanges();
    }
}
