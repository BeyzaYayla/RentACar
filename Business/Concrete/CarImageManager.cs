using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceded(carImage));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.UploadFile(file);
            carImage.Date = DateTime.Today;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory,
                "..\\..\\..\\wwwroot")) + _carImageDal.Get(cımg => cımg.Id == carImage.Id).ImagePath;

            IResult result = BusinessRules.Run(FileHelper.DeleteFile(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(cımg => cımg.Id == carImageId), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetImagesOfACar(int carId)
        {
            var carImages = _carImageDal.GetAll(cımg => cımg.CarId == carId);

            if (carImages.Count == 0)
            {
                var result = GetDefaultImage();
                if (result.Success)
                {
                    return new SuccessDataResult<List<CarImage>>(result.Data, Messages.DefaultImageDisplayed);
                }
                return new ErrorDataResult<List<CarImage>>(Messages.DefaultImageNotFound);
            }

            return new SuccessDataResult<List<CarImage>>(carImages, Messages.CarImagesListed);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            carImage.ImagePath = FileHelper.UpdateFile(oldpath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfImageLimitExceded(CarImage carImage)
        {
            var result = _carImageDal.GetAll(cımg => cımg.CarId == carImage.CarId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage()
        {
            string defaultPath = "\\Images\\logo";
            List<CarImage> defaultImage = _carImageDal.GetAll(cımg => cımg.ImagePath.Equals(defaultPath));

            if (defaultImage.Count == 0)
            {
                return new ErrorDataResult<List<CarImage>>();
            }

            return new SuccessDataResult<List<CarImage>>(defaultImage);
        }
    }
}
