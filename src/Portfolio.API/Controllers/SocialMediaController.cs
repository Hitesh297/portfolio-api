using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        // GET: api/<SocialMediaController>
        private readonly ISocialMediaService _service;
        public SocialMediaController(ISocialMediaService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
            => Ok(await _service.GetAsync(ct));

        // GET api/<SocialMediaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SocialMediaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SocialMediaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SocialMediaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
