using Crudapi.Data;
using Crudapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crudapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly CrudAPIDbContext dbContext;

        public ContactsController(CrudAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
            // return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContacts(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
               // id = addContactRequest.id,
                empcode = addContactRequest.empcode,
                empname = addContactRequest.empname,
                doj = addContactRequest.doj
            };
            await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return Ok(contact);
            // return View();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateContacts([FromRoute] int id, UpdateContactRequest updateContactsRequest)
        {
          var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                string tokens = "632ea828-d4f1-449d-bd7f-cee8888b1706";
                if (tokens == updateContactsRequest.token) {
                    contact.empcode = updateContactsRequest.empcode;
                    contact.empname = updateContactsRequest.empname;
                    contact.doj = updateContactsRequest.doj;
                    await dbContext.SaveChangesAsync();
                    return Ok(contact);
                }
                else
                {
                    return NotFound("token required or invalid token");
                }
            }
            else
            {
                return NotFound();
            }
//            RE
            
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteContacts([FromRoute] int id, DeleteContactRequest deleteContactsRequest)
        {
            var contact = await dbContext.Contacts.FindAsync(id);
            if (contact != null)
            {
                string tokens = "632ea828-d4f1-449d-bd7f-cee8888b1706";
                if (tokens == deleteContactsRequest.token)
                {
                    dbContext.Remove(contact);
                    await dbContext.SaveChangesAsync();
                    return Ok(contact);
                }
                else
                {
                    return NotFound("token required or invalid token");
                }
            }
            else
            {
                //            RE
                return NotFound();
            }
        }

    }
}
