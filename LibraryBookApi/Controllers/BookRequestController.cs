using LibraryBookApi.Entity;
using LibraryBookApi.Entity.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookRequestController : ControllerBase
    {
        private readonly Model _DbContext;
        public BookRequestController(Model DbContext)
        {
            _DbContext = DbContext;
        }
        [HttpGet]
        public IEnumerable /*перечисляемый*/ <InquiryClass> Get(string search = "")
        {
            return _DbContext.Inquiries.Where(
                i => i.classTrainess.ToString().Contains(search.ToLower()) ||
                i.firstName.ToLower().Contains(search.ToLower()) ||
                i.lastName.ToLower().Contains(search.ToLower()) ||
                i.middleName.ToLower().Contains(search.ToLower()) ||
                i.inquiry.ToLower().Contains(search.ToLower()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(InquiryClass inquiry)
        {
            _DbContext.Inquiries.Add(inquiry);
            await _DbContext.SaveChangesAsync();
            return Accepted();
        }

        [HttpGet("{id}")]
        public async Task<InquiryClass> Get(int id)
        {
            return await _DbContext.Inquiries.FindAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            InquiryClass Select = await _DbContext.Inquiries.FindAsync(Id);
            if (Select == null)
                return NotFound();

            _DbContext.Inquiries.Remove(Select);
            await _DbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, InquiryClass inquiry)
        {
            if (id != inquiry.id)
                return BadRequest();

            InquiryClass Select = await _DbContext.Inquiries.FindAsync(inquiry.id);
            if (Select == null)
                return NotFound();

            Select.date = inquiry.date;
            Select.classTrainess = inquiry.classTrainess;
            Select.firstName = inquiry.firstName;
            Select.lastName = inquiry.lastName;
            Select.middleName = inquiry.middleName;
            Select.inquiry = inquiry.inquiry;
            Select.status = inquiry.status;

            await _DbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
