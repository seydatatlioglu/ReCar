using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalVlidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(IsCarDelivered(rental.CarId));
            if (result!=null)
            {
                return result;
            }
             _rentalDal.Add(rental);
             return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        [ValidationAspect(typeof(RentalVlidator))]
        public IDataResult<Rental> GetById(int id)
        {
          
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id== id), Messages.GetRental);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult IsCarDelivered(int id)
        {
            var result = _rentalDal.Get(r => r.CarId == id && r.ReturnDate == null);
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.RentalCarNotDelivered);
                
        }
      


    }
}
