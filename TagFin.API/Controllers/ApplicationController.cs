using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TagFin.Domain;
using TagFin.Services;

namespace TagFin.API.Controllers
{
    [Route("api/TagFin/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _service;

        public ApplicationController(ApplicationService service)
        {
            _service = service;
        }
        [HttpPost("GenerateSchedule")]
        public async Task<ActionResult> InsertSubAccCategories(ScheduleInputs data)
        {
            var response = await _service.GenerateSchedule(data);
            return Ok(response);
        }
    }
}
