using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TagFin.Domain;
using TagFin.Domain.CustomClasses;
using TagFin.Services;

namespace TagFin.API.Controllers
{
    [Route("api/TagFin/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet("Select")]
        public async Task<ActionResult> Select(string? code, string? firstName, string? lastName, string? mobileNo, string? nicNo, string? email, int records)
        {
            var response = await _service.Select(code, firstName, lastName, mobileNo, nicNo, email, records);
            return Ok(response);
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert(Customer data)
        {
            var response = await _service.Insert(data);
            return Ok(response);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update(UpdateData data)
        {
            var response = await _service.Update(data);
            return Ok(response);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult> Delete(Customer data)
        {
            var response = await _service.Delete(data);
            return Ok(response);
        }

        //Sample comment
    }
}
