using Business.Abstract;
using Business.Constants;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;
		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		[ValidationAspect(typeof(CarValidator))]
		public IResult Add(Car car)
		{
			var result = BusinessRules.Run
			(
				CheckIfCarNameExists(car.Description)
			);

			if(result != null)
			{
				return result;
			}

			_carDal.Add(car);

			return new Result(true, Messages.CarAdded);
		}

		public IResult Delete(Car car)
		{
			_carDal.Delete(car);

			return new Result(true);
		}

		public IDataResult<List<Car>> GetAll()
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll());
		}

		public IDataResult<Car> GetById(int carId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}

		public IDataResult<List<Car>> GetByBrandId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
		}

		public IDataResult<List<Car>> GetByColorId(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
		}

		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new Result(true);
		}

		private IResult CheckIfCarNameExists(string description)
		{
			var result = _carDal.GetAll(c => c.Description == description).Any();
			if(result)
			{
				return new ErrorResult(Messages.CarNameExists);
			}
			return new SuccessResult();
		}
	}
}
