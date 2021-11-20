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
	[Route("api/[controller]")]
	[ApiController]
	public class CarImagesController : ControllerBase
	{
		ICarImageService _carImageService;
		public CarImagesController(ICarImageService carImageService)
		{
			_carImageService = carImageService;
		}


		[HttpPost("add")]
		public IActionResult Add(int carId, List<IFormFile> formFiles)
		{
			_carImageService.Add(carId, formFiles);
			return Ok();
		}

		[HttpPost("delete")]
		public IActionResult Delete(int imageId)
		{
			return Ok(_carImageService.Delete(imageId));
		}

		[HttpPost("update")]
		public IActionResult Update(int imageId, IFormFile file)
		{
			_carImageService.Update(imageId, file);
			return Ok();
		}

		[HttpGet("getall")]
		public IActionResult GetAll(int carId)
		{
			return Ok(_carImageService.GetByCarId(carId).Data);
		}
	}
}
