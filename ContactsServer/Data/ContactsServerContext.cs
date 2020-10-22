using ContactsServer.Models;
using ContactsServer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsServer.Data
{
    


    public class ContactsServerContext: DbContext, IContactsServerContext
    {
        private readonly IAuthService _authService;

        public DbSet<User> Users { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public ContactsServerContext(DbContextOptions<ContactsServerContext> options, IAuthService authService): base(options)
        {
            _authService = authService;
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

            var (hash,salt) = _authService.GetSaltAndHash("secret");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1, 
                    FullName = "Ronnie Andersson", 
                    UseRole = "Admin", 
                    UserName="roan", 
                    Salt= salt,
                    Hash= hash 
                }
            );

            modelBuilder.Entity<Contact>(entity => 
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).HasMaxLength(32);
                entity.Property(e => e.LastName).HasMaxLength(32);
                entity.Property(e => e.Email).HasMaxLength(128);
            });
        }
    }
}