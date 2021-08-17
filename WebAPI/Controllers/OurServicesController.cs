using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("hizmetler")]
    [ApiController]
    public class OurServicesController : ControllerBase
    {
        IOurServiceService _ourServiceService;
        public OurServicesController(IOurServiceService ourServiceService, IOurServiceImageService serviceImageService)
        {
            _ourServiceService = ourServiceService;
        }

        [HttpGet("listele")]
        public IActionResult GetAll()
        {
            var result = _ourServiceService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("filtrele")]
        public IActionResult GetServiceById(int id)
        {
            var result = _ourServiceService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("ekle")]
        public IActionResult Add(OurService ourService)
        {
           
            var result = _ourServiceService.Insert(ourService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("sil")]
        public IActionResult Delete(OurService ourService)
        {
            var result = _ourServiceService.Delete(ourService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("guncelle")]
        public IActionResult Update(OurService ourService)
        {
            var result = _ourServiceService.Update(ourService);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
