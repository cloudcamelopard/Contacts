using ContactsServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsServer.Data
{
    public interface IContactsServerContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Contact> Contacts { get; set; }
    }


    public class ContactsServerContext: DbContext, IContactsServerContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public ContactsServerContext(DbContextOptions<ContactsServerContext> options): base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).HasMaxLength(32).IsRequired();
                entity.Property(e => e.UseRole).HasMaxLength(32).IsRequired();
                entity.Property(e => e.UserName).IsRequired();
                entity.Property(e => e.Salt).IsRequired();
                entity.Property(e => e.Hash).IsRequired();
            });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1, 
                    FullName = "Ronny Andersson", 
                    UseRole = "Admin", 
                    UserName="roan", 
                    Salt= "Iy1rku0NDw+fuprai0A6MWHcS5Xhi7OJDeHu7JptRyHNxHEmfIY+QQ/zV/oqMAFRkvZFVEyyrS9Bn+r1mcGomQ==", 
                    Hash= "MaQmTTsyNkDc5jm35Uy5y/lRYbrRo3tdgnH2/6F25mZ3umaMOAancIVyMCMgHlTcfijIGWxyYXSC7r7KjClNCIV2U0dQ3nDYxKxIhiXvtmyuciU8kODJzyg7msqE9OFCBYzSNrPhzrMl7tKpgV4Y3w7qgSpwHwnydaiKIEr0BrIuCOuqn35KzEcnK8iW89Ne5Ir9whnxFdHQbfIt7yU4+zqREq8M3Nc8CrkGg0KwMPMZ3r0Sm9E5VvRcRNVHqRQIlcPZivMyupK5Li1Uq9lQqIG+3HeGo1vf6oNiKJ+Qe/EzMEU9gPjCguDP6vuucS6GUg/4HM/EmgEoZDkauuL+lA=="
                }
            );

            modelBuilder.Entity<Contact>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.Email);
            });

            //modelBuilder.Entity<Contact>().HasData(
            //    new Contact
            //    {
            //        Id = 1,
            //        FirstName = "Ronny",
            //        LastName = "Andersson",
            //        Email = "ronny@ronny.com"
            //    },
            //    new Contact
            //    {
            //        Id = 2,
            //        FirstName = "Lars",
            //        LastName = "Anderzon",
            //        Email = "lars@ronny.com"
            //    }
            //);
        }
    }
}