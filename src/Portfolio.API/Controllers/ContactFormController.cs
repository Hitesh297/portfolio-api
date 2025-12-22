using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        // GET: api/<ContactFormController>
        private readonly IContactFormService _service;
        public ContactFormController(IContactFormService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
            => Ok(await _service.GetAsync(ct));

        // GET api/<ContactFormController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactFormController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContactFormController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactFormController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
