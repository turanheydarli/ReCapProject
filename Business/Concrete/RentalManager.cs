using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class RentalManager : IRentalService
	{
		IRentalDal _rentalDal;
		public RentalManager(IRentalDal rentalDal)
		{
			_rentalDal = rentalDal;
		}
		public IResult Add(Rental rental)
		{
			Rental addToRental = _rentalDal.Get(r => r.CarId == rental.CarId);
			if (addToRental != null)
			{
				if(addToRental.ReturnDate == null)
				{
					return new ErrorResult(Messages.ThisCarAllreadyRented);
				}
			}
			_rentalDal.Add(rental);
			return new SuccessResult(Messages.ThisCarRented);
		}

		public DataResult<List<Rental>> GetAll()
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
		}
	}
}
