using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KabagController : ControllerBase
    {
        KabagRepository kabagRepository;

        public KabagController(KabagRepository kabagRepository)
        {
            this.kabagRepository = kabagRepository;
        }


        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var data = kabagRepository.Get();

        //    if (data.Count == 0)
        //        return Ok(new { message = "Data yang anda ambil TIDAK ADA", statusCode = 200, data = data });
        //    return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = data });
        //}

        //READ BY ID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = kabagRepository.Get(id);

            if (data == null)
                return Ok(new { message = "Data yang anda ambil TIDAK ADA", statusCode = 200, data = data });
            return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = data });
        }

        [HttpPut("{id}")]
        public IActionResult EditSPB(int id, Pengadaan pengadaan)
        {
            var result = kabagRepository.EditSPB(pengadaan);
            if (result > 0)
                return Ok(new { message = "Berhasil mengambil data", statusCode = 200 });
            return BadRequest(new { messagae = "Gagal mengambil data", statusCode = 400 });
        }
    }

}
