﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görseli boş geçilemez");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapın");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter girişi yapın");
        }
    }
}
