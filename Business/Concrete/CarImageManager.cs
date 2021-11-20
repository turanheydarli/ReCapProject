using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CarImageManager : ICarImageService
	{
		ICarImageDal _carImageDal;
		IFileHelper _fileHelper;
		public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
		{
			_carImageDal = carImageDal;
			_fileHelper = fileHelper;
		}
		public IResult Add(int carId, List<IFormFile> formFiles)
		{
			var result = BusinessRules.Run
			(
				CheckIfCarImagesLimit(formFiles)
			);

			if (result != null)
			{
				return result;
			}

			string folder = PathConstants.ImagesPath;

			foreach (IFormFile file in formFiles)
			{
				string imagePath = _fileHelper.Save(file, folder);
				_carImageDal.Add(new CarImage { ImagePath = imagePath, CarId = carId, Date = DateTime.Now });
			}

			return new SuccessResult();
		}

		public IResult Delete(int imageId)
		{
			var result = _carImageDal.Get(ci => ci.Id == imageId);

			_fileHelper.Delete(result.ImagePath);
			_carImageDal.Delete(result);

			return new SuccessResult();
		}

		public IDataResult<List<CarImage>> GetByCarId(int carId)
		{
			return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(x => x.CarId == carId));
		}

		public IResult Update(int imageId, IFormFile file)
		{
			var result = _carImageDal.Get(ci => ci.Id == imageId);
			var oldFile = result.ImagePath;

			result.ImagePath =_fileHelper.Update(file, PathConstants.ImagesPath, oldFile);

			_carImageDal.Update(result);

			return new SuccessResult();
		}

		private IResult CheckIfCarImagesLimit(List<IFormFile> files)
		{
			if (files.Count > 5)
			{
				return new ErrorResult(Messages.CarImagesLimitError);
			}
			return new SuccessResult();
		}

	}
}
