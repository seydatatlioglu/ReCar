using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GelAllByBrandId(int id);
        IDataResult<List<Car>> GelAllByColorId(int id);
        IDataResult<List<Car>> GelAllById(int id);
        IDataResult<List<Car>> GetAllByDailyPrice(decimal min, decimal max);
        IDataResult< List<CarDetailsDto>> GetCarDetails();
        IDataResult<Car> Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        IResult TransactionalOperation(Car car);


    }
}
