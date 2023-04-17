using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SirketsController : ControllerBase
    {
        private ISirketService _sirketService;
        public SirketsController(ISirketService sirketService)
        {
            _sirketService = sirketService;
        }

        [HttpGet("getall")]
        [Authorize(Roles ="Sirket.List")]
        public IActionResult GetList()
        {
            var result = _sirketService.GetList();
            if (result.Success) { return Ok(result.Data); }
            else { return BadRequest(result.Message); }
        }
        [HttpGet("getbyId")]

        public IActionResult GetbyId(int id) 
        {
            var result=_sirketService.GetById(id);
            if (result.Success) { return Ok(result.Data); }
            else { return BadRequest(result.Message); }
        }

        [HttpPost("add")]

        public IActionResult Add(Sirket sirket)
        {
            var result=_sirketService.Add(sirket);
            if (result.Success) { return Ok(result.Message); }
            else { return BadRequest(result.Message); }
        }

        [HttpPost("delete")]
        public IActionResult Delete(Sirket sirket) 
        {
            var result=_sirketService.Delete(sirket);
            if (result.Success) { return Ok(result.Message); }
            else { return BadRequest(result.Message);}
        }

        [HttpPost("update")]
        public IActionResult Update(Sirket sirket)
        {
            var result = _sirketService.Update(sirket);
            if (result.Success) { return Ok(result.Message); }
            else { return BadRequest(result.Message); }
        }
    }
    
}
