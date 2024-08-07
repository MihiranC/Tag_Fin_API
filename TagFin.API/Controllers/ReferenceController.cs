using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using TagFin.Domain;
using TagFin.Domain.CustomClasses;
using TagFin.Services;

namespace TagFin.API.Controllers
{
    [Route("api/TagFin/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        private readonly ReferenceService _service;

        public ReferenceController(ReferenceService service)
        {
            _service = service;
        }

        [HttpGet("SelectProduct")]
        public async Task<ActionResult> SelectProduct(string? code)
        {
            var response = await _service.SelectProduct(code);
            return Ok(response);
        }

        [HttpGet("SelectProductWiseChargers")]
        public async Task<ActionResult> SelectProductWiseChargers(string? chargeCode, string? productCode)
        {
            var response = await _service.SelectProductWiseChargers(chargeCode, productCode);
            return Ok(response);
        }

        [HttpGet("SelectCalMethdFrequency")]
        public async Task<ActionResult> SelectCalMethdFrequency()
        {
            var response = await _service.SelectCalMethdFrequency();
            return Ok(response);
        }

        [HttpGet("SelectProductWiseCalMethods")]
        public async Task<ActionResult> SelectProductWiseCalMethods(string productCode)
        {
            var response = await _service.SelectProductWiseCalMethods(productCode);
            return Ok(response);
        }

    }
}
