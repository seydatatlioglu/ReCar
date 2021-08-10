using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //BrandTest();
            //ColorTest();

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var brand in colorManager.GetAll())
            {
                Console.WriteLine(brand.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " -- "+car.CarName);
                }
            }

            else
            {
                Console.WriteLine(result.Message);
            }
            
            

               
            
        }
    }
}
