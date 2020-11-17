using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Contracts.Models.StudentModels;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] RegisterStudentModel model)
        {
            if (!ModelState.IsValid) return StatusCode(400);

            await _service.CreateAsync(model);

            return StatusCode(200);
        }
        [HttpGet("find/{id}")]
        public async Task<IActionResult> FindAsync(string id)
        {
            var result = await _service.FindAsync(id);
         return StatusCode(200, result);
        }

        [HttpGet("all/{pageIndex}&{pageSize}")]

        public async Task<IActionResult> GetPaginatedResultsAsync([FromRoute] int pageIndex, [FromRoute] int pageSize)
        {
            var result = await _service.GetPaginatedResultAsync(pageIndex, pageSize);
            return StatusCode(200, result);
        }

    }
}
