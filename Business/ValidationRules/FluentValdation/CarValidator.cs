using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValdation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator() 
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0);
        
        }

    }
}
