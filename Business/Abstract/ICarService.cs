using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GelAllByBrandId(int id);
        List<Car> GelAllByColorId(int id);
        List<Car> GetAllByDailyPrice(decimal min, decimal max);
        List<CarDetailsDto> GetCarDetails();
    }
}
