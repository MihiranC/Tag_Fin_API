using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TagFin.Services;

namespace TagFin.API.Controllers
{
    [Route("api/TagFin/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly BranchService _service;

        public BranchController(BranchService service)
        {
            _service = service;
        }

        [HttpGet("Select")]
        public async Task<ActionResult> Select(string? code)
        {
            var response = await _service.SelectBranches(code);
            return Ok(response);
        }
    }
}
