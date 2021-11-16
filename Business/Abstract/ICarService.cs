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
		List<Car> GetAll();
		Car GetById(int carId);
		void Update(Car car);
		void Delete(Car car);
		void Add(Car car);
		void GetCarsByBrandId(int id);
		void GetCarsByColorId(int id);
		List<CarDetailDto> GetCarDetails();
	}
}
