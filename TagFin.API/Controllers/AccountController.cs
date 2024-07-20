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
    public class AccountController : ControllerBase
    {
        private readonly AccountService _service;

        public AccountController(AccountService service)
        {
            _service = service;
        }

        [HttpGet("SelectMainAccCategories")]
        public async Task<ActionResult> SelectMainAccCategories(string? code)
        {
            var response = await _service.SelectMainAccCategories(code);
            return Ok(response);
        }

        [HttpGet("SelectSubAccCategories")]
        public async Task<ActionResult> SelectSubAccCategories(int id, string? code)
        {
            var response = await _service.SelectSubAccCategories(id, code);
            return Ok(response);
        }

        [HttpPost("InsertSubAccCategories")]
        public async Task<ActionResult> InsertSubAccCategories(SubAccCategories data)
        {
            var response = await _service.InsertSubAccCategories(data);
            return Ok(response);
        }

        [HttpPost("UpdateSubAccCategories")]
        public async Task<ActionResult> UpdateSubAccCategories(UpdateData data)
        {
            var response = await _service.UpdateSubAccCategories(data);
            return Ok(response);
        }

        [HttpPost("DeleteSubAccCategories")]
        public async Task<ActionResult> DeleteSubAccCategories(SubAccCategories data)
        {
            var response = await _service.DeleteSubAccCategories(data);
            return Ok(response);
        }

    }
}
