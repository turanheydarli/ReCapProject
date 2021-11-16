using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, ApplicationContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using (ApplicationContext context = new ApplicationContext())
			{
				var result = from car in context.Cars
							 join color in context.Colors on car.ColorId equals color.Id
							 join brand in context.Brands on car.BrandId equals brand.Id
							 select new CarDetailDto
							 {
								 CarName = car.Description,
								 BrandName = brand.Name,
								 ColorName = color.Name,
								 DailyPrice = car.DailyPrice
							 };
				return result.ToList();
			}
		}
	}
}
