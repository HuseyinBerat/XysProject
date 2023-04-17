using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullanicisController : ControllerBase
    {
        private IKullaniciService _kullaniciService;

        public KullanicisController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _kullaniciService.GetList();
            if (result.Success) { return Ok(result.Data); }
            else
            {
                return BadRequest(result.Message);
            }


        }

        [HttpGet("getlistbySirket")]
        public IActionResult GetListBySirket(int sirketId)
        {
            var result = _kullaniciService.GetListBySirket(sirketId);
            if (result.Success) { return Ok(result.Data); }
            else
            {
                return BadRequest(result.Message);
            }


        }

        [HttpGet("getbyId")]
        public IActionResult GetById(int kullaniciId)
        {
            var result = _kullaniciService.GetById(kullaniciId);
            if (result.Success) { return Ok(result.Data); }
            else
            {
                return BadRequest(result.Message);
            }


        }

        [HttpPost("add")]
        public IActionResult Add(Kullanici kullanici)
        {
            var result = _kullaniciService.Add(kullanici);
            if (result.Success) { return Ok(result.Message); }
            else
            {
                return BadRequest(result.Message);
            }


        }

        [HttpPost("delete")]
        public IActionResult Delete(Kullanici kullanici)
        {
            var result = _kullaniciService.Delete(kullanici);
            if (result.Success) { return Ok(result.Message); }
            else
            {
                return BadRequest(result.Message);
            }


        }

        [HttpPost("update")]
        public IActionResult Update(Kullanici kullanici)
        {
            var result = _kullaniciService.Update(kullanici);
            if (result.Success) { return Ok(result.Message); }
            else
            {
                return BadRequest(result.Message);
            }


        }


    }
}
