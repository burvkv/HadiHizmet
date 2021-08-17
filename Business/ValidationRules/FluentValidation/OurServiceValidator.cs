using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;

namespace Business.ValidationRules.FluentValidation
{
    public class OurServiceValidator : AbstractValidator<OurService>
    {
        public OurServiceValidator()
        {
            RuleFor(o => o.Description).NotEmpty().WithMessage(Messages.DescriptionError);
            RuleFor(o => o.Description).MinimumLength(20).WithMessage(Messages.DescriptionError);
            RuleFor(o => o.Description).MaximumLength(250).WithMessage(Messages.DescriptionError);
            
        }
    }
}
