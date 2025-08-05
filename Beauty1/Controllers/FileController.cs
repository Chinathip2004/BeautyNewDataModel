using Beauty1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beauty1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly CustomContext _context;

        public FileController(CustomContext custom)
        {
            _context = custom;
        }

        [HttpPost]
        public ActionResult Create([FromForm] DtoFile dto)
        {
            FileImg file = new FileImg();
            file.Create(_context, dto);

            return Ok();
        }
    }
}
