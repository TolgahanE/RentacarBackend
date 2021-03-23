using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var list = _colorService.GetAll();
            if (list.Success)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest(list.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var add = _colorService.Add(color);
            if (add.Success)
            {
                return Ok(add);
            }
            else
            {
                return BadRequest(add.Message);
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var get = _colorService.GetById(id);
            if (get.Success)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest(get.Message);
            }
        }
    }
}
