using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("bizekatil")]
    [ApiController]
    public class PersonelFormsController : ControllerBase
    {
        IPersonelFormService _personelFormService;
        public PersonelFormsController(IPersonelFormService personelFormService)
        {
            _personelFormService = personelFormService;
        }

        [HttpGet("listele")]
        public IActionResult GetAll()
        {
            var result = _personelFormService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("filtrele")]
        public IActionResult GetByPhone(string phone)
        {
            var result = _personelFormService.GetByPhone(phone);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("gonder")]
        public IActionResult SendForm(PersonelForm personelForm)
        {
            var result = _personelFormService.SendForm(personelForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("sil")]
        public IActionResult Delete(PersonelForm personelForm)
        {
            var result = _personelFormService.Delete(personelForm);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
