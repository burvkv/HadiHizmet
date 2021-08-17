using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AboutUsValidator : AbstractValidator<AboutUs>
    {
        public AboutUsValidator()
        {
            RuleFor(a => a.AboutUsText).MaximumLength(350).WithMessage("Açıklama metni en fazla 350 karakter olmalıdır.");
            RuleFor(a => a.AboutUsText).MinimumLength(50).WithMessage("En az 50 karakter içeren bir açıklama metni yazınız.");
            RuleFor(a => a.Mail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi giriniz.");
            RuleFor(a => a.Phone).MinimumLength(10).WithMessage("Telefon numaranızı başında 0 olmadan yazınız.");
            RuleFor(a => a.Phone).MaximumLength(10).WithMessage("Telefon numaranızı başında 0 olmadan yazınız.");
            RuleFor(a => a.Since).Length(4).WithMessage("Lütfen geçerli bir yıl giriniz.");
        }
    }
}
