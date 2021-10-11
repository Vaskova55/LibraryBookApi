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
    }
}
