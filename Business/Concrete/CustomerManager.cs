using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstarct;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length<3)
            {
                return new ErrorResult(Messages.CustomerNameInvalid);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
           
        }

        public IResult Delete(Customer customer)
        {
            if (customer.CompanyName.Length < 3)
            {
                return new ErrorResult(Messages.CustomerNameInvalid);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            Customer customer = new Customer();
            if (customer.CompanyName==null)
            {
                return new ErrorDataResult<List<Customer>>(Messages.CustomerNameNull);
            }
            return new SuccessDataResult<List<Customer>>(Messages.CustomerListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p => p.UserId == id));
        }

        public IResult Update(Customer customer)
        {
            return new SuccessDataResult<List<Customer>>(Messages.CustomerUpdated);
        }
    }
}
