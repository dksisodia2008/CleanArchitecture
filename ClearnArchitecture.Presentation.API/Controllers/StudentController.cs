using ClearnArchitecture.Domain.IRepositories;
using ClearnArchitecture.Infrastructure.Context.Persistence.MSSQLServer;
using ClearnArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClearnArchitecture.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // private readonly ApplicationMSSQLServer _context;
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("GetAllStudent")]
        public async Task<IActionResult> Get()
        {
            var result = await _studentRepository.GetAllStudentsAsync();
            if (result.Count == 0)
            {
                return NotFound("Record not found!!");
            }
            return Ok(result);
        }
    }
}
