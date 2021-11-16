using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarManager carManager = new CarManager(new EfCarDal());
			//Add(carManager);
			foreach (CarDetailDto car in carManager.GetCarDetails())
			{
				Console.WriteLine(car.BrandName + " - " + car.CarName + " - " + car.ColorName + " - " + car.DailyPrice);
			}
		}

		private static void Add(CarManager carManager)
		{
			Car car1 = new Car { BrandId = 1, ColorId = 1, DailyPrice = 200, Description = "2r32r2", ModelYear = 2021 };
			carManager.Add(car1);
		}
		private static void AddBrand(BrandManager brandManager)
		{
			Brand brand = new Brand { Name = "Tesla" };
			brandManager.Add(brand);
		}
	}
}
