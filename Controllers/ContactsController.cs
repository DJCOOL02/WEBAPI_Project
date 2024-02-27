using Microsoft.AspNetCore.Mvc;
using WEBAPI.Data;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactAPIsDbContext dbContext;
        public ContactsController(ContactAPIsDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(this.dbContext.Contacts.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody]AddContactRequest addContactRequest)
        {
            var contact = new Contacts
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email= addContactRequest.Email,
                FullName= addContactRequest.FullName,
                Number = addContactRequest.Number,
            };
            await this.dbContext.Contacts.AddAsync(contact);
            await this.dbContext.SaveChangesAsync();
            return Ok(contact);
        }

        [HttpPut]
        [Route("Update/{id:guid}")]
        public async Task<IActionResult> UpdateContact([FromBody] AddContactRequest contacts, Guid id)
        {
            var contact = await this.dbContext.Contacts.FindAsync(id);
            if(contact != null) { 
            contact.FullName = contacts.FullName;
                contact.Number = contacts.Number;
                contact.Address = contacts.Address;
                contact.Email = contacts.Email;
                await this.dbContext.SaveChangesAsync();

        return Ok(contact);
            }

            return NotFound();
        }
        [HttpDelete]
        [Route("Delete/{id:guid}")]

        public async Task<IActionResult>DeleteContact(Guid id)
        {
            var contacts = await dbContext.Contacts.FindAsync(id);

            if(contacts != null)
            {
                dbContext.Contacts.Remove(contacts);
                dbContext.SaveChangesAsync();
                return Ok(contacts);
            }
            return NotFound();
        }
    }
}
