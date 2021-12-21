using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.ArticleTitle).NotEmpty().WithMessage("Makalenin Bir Başlığı Olmalı");
            RuleFor(x => x.ArticleContent).NotEmpty().WithMessage("Makalenin Bir İçeriği Olmalı");
            RuleFor(x => x.ArticleThumbnailImage).NotEmpty().WithMessage("Makalenin Bir Görseli Olmalı");
            RuleFor(x => x.ArticleTitle).MaximumLength(150).WithMessage("Başlık En Fazla 150 Karakter Olabilir");
            RuleFor(x => x.ArticleTitle).MinimumLength(5).WithMessage("Başlık En Az 4 Karakter Olmalı");
        }

    }
}
