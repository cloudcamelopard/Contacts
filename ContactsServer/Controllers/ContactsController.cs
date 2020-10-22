﻿using ContactsServer.Data;
using ContactsServer.DTOs;
using ContactsServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ContactsServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController: ControllerBase
    {
        private readonly ContactsServerContext _data;

        public ContactsController(ContactsServerContext data)
        {
            _data = data;
        }

        [HttpGet]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult GetAllContacts()
        {
            var contacts = _data.Contacts;
            return Ok(contacts.Select(c => new ContactDTO() { 
                Id = c.Id, 
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email
            }).ToArray());
            //return Ok("This is a response from Admin method");
        }

        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult AddContact([FromBody] ContactDTO newContact)
        {
            try { 
                var res = _data.Contacts.Add(new Contact { FirstName = newContact.FirstName, LastName = newContact.LastName, Email = newContact.Email });
                _data.SaveChanges();
                return Ok(new { Id = res.Entity.Id });
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}