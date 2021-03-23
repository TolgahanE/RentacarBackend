using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(3000);
            var list = _carService.GetAll();
            if (list.Success)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest(list.Message);
            }
        }

        //[HttpGet("getbybrand")]
        //public IActionResult GetByBrand(int brandId)
        //{
        //    //Thread.Sleep(3000);
        //    var list = _carService.GetByBrandId(brandId);
        //    if (list.Success)
        //    {
        //        return Ok(list);
        //    }
        //    else
        //    {
        //        return BadRequest(list.Message);
        //    }
        //}

        [HttpGet("getbybrand")]
        public IActionResult GetByBrandId(int brandId)
        {
            //Thread.Sleep(3000);
            var list = _carService.GetByBrandIdDto(brandId);
            if (list.Success)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest(list.Message);
            }
        }

        [HttpGet("getbycolor")]
        public IActionResult GetByColorId(int colorId)
        {
            //Thread.Sleep(3000);
            var list = _carService.GetByColorIdDto(colorId);
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
        public IActionResult Add(Car car)
        {
            var add = _carService.Add(car);
            if (add.Success)
            {
                return Ok(add);
            }
            else
            {
                return BadRequest(add.Message);
            }
        }

        [HttpGet("getcardetail")]
        public IActionResult GetCarDetails()
        {
            //Thread.Sleep(3000);
            var get = _carService.GetCarDetailDto();
            if (get.Success)
            {
                return Ok(get);
            }

            return BadRequest(get.Message);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails(int id)
        {
            //Thread.Sleep(3000);
            var get = _carService.GetCarDetailsDto(id);
            if (get.Success)
            {
                return Ok(get);
            }

            return BadRequest(get.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var get = _carService.GetById(id);
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
