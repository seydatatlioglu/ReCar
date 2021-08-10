using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GelAllByBrandId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GelAllByColorId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MainTenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);

        }

        public IDataResult<List<Car>> GetAllByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<List<CarDetailsDto>>(Messages.MainTenanceTime);
            }
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarListed);
        }
        
    }
}
