using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalVlidator:AbstractValidator<Rental>
    {
        public RentalVlidator()
        {
            RuleFor(r=>r.CarId).Empty().GreaterThan(0).WithMessage("carId 0 olamaz ve boş bırakılamaz");
            RuleFor(r => r.Id).Empty().WithMessage("kiralamayı görmek için id girin");
        }
    }
}
