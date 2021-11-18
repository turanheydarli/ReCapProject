using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICarService
	{
		IDataResult<List<Car>> GetAll();
		IDataResult<Car> GetById(int carId);
		IResult Update(Car car);
		IResult Delete(Car car);
		IResult Add(Car car);
		IDataResult<List<Car>> GetByBrandId(int id);
		IDataResult<List<Car>> GetByColorId(int id);
		IDataResult<List<CarDetailDto>> GetCarDetails();
	}
}
