using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarImageService
	{
		IDataResult<List<CarImage>> GetByCarId(int carId);
		IResult Update(int imageId, IFormFile file);
		IResult Delete(int imageId);
		IResult Add(int carId, List<IFormFile> files);
	}
}
