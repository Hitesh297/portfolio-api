using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Infrastructure.Persistence;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly AppDbContext _db;
        public HealthController(AppDbContext db)
        {
            _db = db;
        }

        

        [HttpGet]
        [Route("ping")]
        public async Task<IActionResult> Ping(CancellationToken ct)
        {
            await _db.Database.ExecuteSqlRawAsync("SELECT 1", ct);
            return Ok(new { status = "API is up and running" });
        }
    }
}
