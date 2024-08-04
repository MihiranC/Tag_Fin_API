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

        [HttpPost("InsertCaldetails")]
        public async Task<ActionResult> InsertCaldetails(CalDetails data)
        {
            var response = await _service.InsertCaldetails(data);
            return Ok(response);
        }

        [HttpPost("UpdateCaldetails")]
        public async Task<ActionResult> UpdateCaldetails(CalDetails data)
        {
            var response = await _service.UpdateCaldetails(data);
            return Ok(response);
        }

        [HttpPost("DeleteCaldetails")]
        public async Task<ActionResult> DeleteCaldetails(CalDetails data)
        {
            var response = await _service.DeleteCaldetails(data);
            return Ok(response);
        }

        [HttpGet("SelectCalDetails")]
        public async Task<ActionResult> SelectCalDetails(int? calId)
        {
            var response = await _service.SelectCalDetails(calId);
            return Ok(response);
        }

        [HttpGet("SelectCalWiseChargers")]
        public async Task<ActionResult> SelectCalWiseChargers(int? calId)
        {
            var response = await _service.SelectCalWiseChargers(calId);
            return Ok(response);
        }
    }
}
