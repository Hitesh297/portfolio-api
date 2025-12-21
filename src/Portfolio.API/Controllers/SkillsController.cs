using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _service;
        public SkillsController(ISkillService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
            => Ok(await _service.GetAsync(ct));


        // GET api/<PublicSkillsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PublicSkillsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PublicSkillsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PublicSkillsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
