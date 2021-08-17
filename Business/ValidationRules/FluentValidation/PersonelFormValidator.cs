using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonelFormValidator : AbstractValidator<PersonelForm>
    {
        public PersonelFormValidator()
        {
            RuleFor(a => a.Mail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(a => a.Phone).MinimumLength(10).WithMessage("Telefon numaranızı başında 0 olmadan yazınız.");
            RuleFor(a => a.Phone).MaximumLength(10).WithMessage("Telefon numaranızı başında 0 olmadan yazınız.");
            RuleFor(a => a.Address).MaximumLength(250);
        }
    }
}
