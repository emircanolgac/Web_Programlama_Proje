using EntityLayer.Concreate;
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
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Bu Alan Boş Geçilemez!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En Az İki Karakter Girilmeli!");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En Fazla 50 Karakter Girebilirsiniz!");
        }
    }
}
