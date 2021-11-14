using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public List<Car> GetAll()
		{
			return _cars;
		}

		public Car GetById(int carId)
		{
			return _cars.SingleOrDefault(c => c.CarId == carId);
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
