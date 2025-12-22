using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        // GET: api/<QualificationController>
        private readonly IQualificationService _service;
        public QualificationController(IQualificationService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
            => Ok(await _service.GetAsync(ct));

        // GET api/<QualificationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QualificationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QualificationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QualificationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
