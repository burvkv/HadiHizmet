using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class OurServiceImageValidator : AbstractValidator<IFormFile>
    {
        public OurServiceImageValidator()
        {
            RuleFor(o => o.FileName).MinimumLength(1).WithMessage(Messages.MustAddPhoto);

        }
    }
}
