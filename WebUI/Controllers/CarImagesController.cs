using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpGet("getall")]
        public ActionResult GetCarImages() 
        {
            var result = _carImageService.GetAll();
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public ActionResult GetById(int id) 
        {
            var result = _carImageService.GetById(id);
            if (result.Success) { Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public ActionResult Add([FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            var result = _carImageService.Add(file, carImage);
            if (result.Success) { Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public ActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success) { Ok(result); }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public ActionResult Update([FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            var result = _carImageService.Update(file, carImage);
            if (result.Success) { Ok(result); }
            return BadRequest(result);
        }
    }
}
