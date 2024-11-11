using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class TourValidator : AbstractValidator<Tour>
    {
        public TourValidator()
        {
            RuleFor(x => x.FirstHotel).NotEmpty();
            RuleFor(x => x.SecondHotel).NotEmpty();
            RuleFor(x => x.DepartureCity).NotEmpty();
            RuleFor(x => x.DepartureDate).NotEmpty();
            RuleFor(x => x.DestinationCity).NotEmpty();
            RuleFor(x => x.TourUrl).NotEmpty();
            RuleFor(x => x.ReturningDepartureCity).NotEmpty();
            RuleFor(x => x.ReturningDate).NotEmpty();
            RuleFor(x => x.ReturningDestinationCity).NotEmpty();
            RuleFor(x => x.PriceForThreeRoom).NotEmpty();
            RuleFor(x => x.PriceForThreeRoom).NotEmpty();
        }
    }
}
