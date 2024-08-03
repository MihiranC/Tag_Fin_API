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
        public async Task<ActionResult> SelectSubAccCategories(int id, string? code, string? mainAccCode)
        {
            var response = await _service.SelectSubAccCategories(id, code, mainAccCode);
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

        [HttpGet("SelectAccounts")]
        public async Task<ActionResult> SelectAccounts(string? mainAccCode, string? subAccCode)
        {
            var response = await _service.SelectAccounts(mainAccCode, subAccCode);
            return Ok(response);
        }

        [HttpPost("InsertAccounts")]
        public async Task<ActionResult> InsertAccounts(Accounts data)
        {
            var response = await _service.InsertAccounts(data);
            return Ok(response);
        }

        [HttpPost("UpdateAccounts")]
        public async Task<ActionResult> UpdateAccounts(UpdateData data)
        {
            var response = await _service.UpdateAccounts(data);
            return Ok(response);
        }

        [HttpPost("DeleteAccounts")]
        public async Task<ActionResult> DeleteAccounts(Accounts data)
        {
            var response = await _service.DeleteAccounts(data);
            return Ok(response);
        }

        [HttpPost("InsertEntry")]
        public async Task<ActionResult> InsertEntry(EntryHeader data)
        {
            var response = await _service.InsertEntry(data);
            return Ok(response);
        }

        [HttpPost("SearchAccountsInquiry")]
        public async Task<ActionResult> SearchAccountsInquiry(SearchAccountsInquiry data)
        {
            var response = await _service.SearchAccountsInquiry(data);
            return Ok(response);
        }
    }
}
