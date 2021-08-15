using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Id).GreaterThan(0); //girilen id değeri odan büyük olmalı
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            //RuleFor(p => p.B).Must(StartWithA).WithMessage("ürünler A harfi ile başlamalı"); //kendi kodumuzu metot halinde oluşturduk
            
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            
            //ürünün fiyatı en az olsun ama ürünün kategori id'si 1'e eşit ise
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
