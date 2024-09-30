using ClearnArchitecture.Infrastructure.Context.Persistence.MSSQLServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClearnArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationMSSQLServer _context;
        public StudentController(ApplicationMSSQLServer context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllStudent")]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Students.ToListAsync();
            if (result.Count == 0)
            {
                return NotFound("Record not found!!");
            }
            return Ok(result);
        }
    }
}
