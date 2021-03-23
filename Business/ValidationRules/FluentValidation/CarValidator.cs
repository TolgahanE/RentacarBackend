using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            // Arabanın açıklaması minimum 2 karakter olmalıdır.
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.DailyPrice).NotNull();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.BrandId == 1);
            // Kendi Kuralımızı Oluşturalım.
            //RuleFor(c => c.Description).Must(StartWithA).WithMessage("Ürünler A Harfi ile Başlamalı.");
        }

        bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
