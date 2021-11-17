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

			RentalManager rentalManager  = new RentalManager(new EfRentalDal());

			Console.WriteLine(rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.UtcNow.AddHours(4) }).Message);
			foreach (Rental rental in rentalManager.GetAll().Data)
			{
				Console.WriteLine(rental.RentDate + " - " + rental.CustomerId + " - " + rental.CarId);
			}
		}

		private static void AddUser(UserManager userManager)
		{
			userManager.Add(new User { Email = "engindemirog@kodlama.io", FirstName = "Engin", LastName = "Demirog", Password = "123456" });
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
