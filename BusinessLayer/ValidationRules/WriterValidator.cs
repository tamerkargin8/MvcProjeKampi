using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Olamaz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı Boş  Olamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Kısmı Boş  Olamaz");
            RuleFor(x => x.WriterSurName).MinimumLength(1).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter girişi yapın");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanı Boş  Olamaz");
        }
    }
}
