using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValdation
{
    public class RentalValidation : AbstractValidator<Rental>
    {
        public RentalValidation() 
        {
            RuleFor(r => r.RentDate).NotEmpty();
        }
    }
}
