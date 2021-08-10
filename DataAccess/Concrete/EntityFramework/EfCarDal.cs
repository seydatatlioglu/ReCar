using Core.DataAccess.EntityFramework;
using DataAccess.Abstarct;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (Context context=new Context())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             
                             on c.BrandId equals b.BrandId
                             select new CarDetailsDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 CarName = c.Description,
                                 
                             };

                return result.ToList();
            }
            
        }
    }
}
