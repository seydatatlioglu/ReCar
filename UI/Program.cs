using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();
            //ColorTest();

            //RentalTest();

            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.Add(new Rental
            {
                CarId = 4,
                CustomerId = 6,
                RentDate = new DateTime(2021, 08, 08,15,20,20),



            });
            Console.WriteLine(result.Message);






        }

 


        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
         
            if (result.Success == true)
            {
                foreach (var rent in result.Data)
                {
                    Console.WriteLine(rent.RentDate + " -- " + rent.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        //private static void ColorTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    foreach (var brand in colorManager.GetAll())
        //    {
        //        Console.WriteLine(brand.ColorName);
        //    }
        //}

        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.BrandName);
        //    }
        //}



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
