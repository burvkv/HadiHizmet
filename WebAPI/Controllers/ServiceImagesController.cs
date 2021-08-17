using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("galeri")]
    [ApiController]
    public class ServiceImagesController : ControllerBase
    {
        IOurServiceImageService _imageService;

        public ServiceImagesController(IOurServiceImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("listele")]
        public IActionResult GetAll()
        {
            var result = _imageService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("ekle")]
        public IActionResult Add(IFormFile file, [FromForm] OurServiceImage serviceImages)
        {

            var result = _imageService.Add(serviceImages, file);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("sil")]
        public IActionResult Remove(/*[FromForm(Name = ("id"))] */int id)
        {
            var deleteServiceImage = _imageService.GetByImageId(id).Data;
            var result = _imageService.Remove(deleteServiceImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("guncelle")]
        public IActionResult Update([FromForm] OurServiceImage serviceImages, [FromForm(Name = ("Image"))] IFormFile file)
        {

            var result = _imageService.Update(serviceImages, file);
            if (!result.Success)
            {
                return BadRequest(result.Message);

            }

            return Ok(result);
        }

        [HttpGet("filtrele")]
        public IActionResult GetByServiceId(int serviceId)
        {
            var result = _imageService.GetByServiceId(serviceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
