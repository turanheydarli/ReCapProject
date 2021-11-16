using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;
		public InMemoryCarDal()
		{
			_cars = new List<Car>
			{
				new Car{ CarId = 1, BrandId = 1, ColorId = 2, DailyPrice = 500, Description = "this car is cool", ModelYear = 2021 },
				new Car{ CarId = 1, BrandId = 1, ColorId = 2, DailyPrice = 150, Description = "this car is cool", ModelYear = 2021 },
				new Car{ CarId = 1, BrandId = 1, ColorId = 2, DailyPrice = 530, Description = "this car is cool", ModelYear = 2021 },
				new Car{ CarId = 1, BrandId = 1, ColorId = 2, DailyPrice = 240, Description = "this car is cool", ModelYear = 2021 },
				new Car{ CarId = 1, BrandId = 1, ColorId = 2, DailyPrice = 450, Description = "this car is cool", ModelYear = 2021 },
				new Car{ CarId = 1, BrandId = 1, ColorId = 2, DailyPrice = 100, Description = "this car is cool", ModelYear = 2021 },
			};
		}
		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car carOfDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			_cars.Remove(carOfDelete);
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public Car GetById(int carId)
		{
			return _cars.SingleOrDefault(c => c.CarId == carId);
		}

		public List<CarDetailDto> GetCarDetails()
		{
			throw new NotImplementedException();
		}

		public void Update(Car car)
		{
			Car carOfUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			carOfUpdate.BrandId = car.BrandId;
			carOfUpdate.ColorId = car.ColorId;
			carOfUpdate.DailyPrice = car.DailyPrice;
			carOfUpdate.Description = car.Description;
			carOfUpdate.ModelYear = car.ModelYear;
		}
	}
}
