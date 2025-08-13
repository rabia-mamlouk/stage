using Application.Common.Constants;
using Application.Common.Validator;
using Application.Features.CarteElectroniqueFeature.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarteElectroniqueFeature.Validators
{
    public class UpdateCarteElectroniqueCommandNewValidator : ValidatorBase<UpdateCarteElectroniqueCommand>
    {
        public UpdateCarteElectroniqueCommandNewValidator()
        {
            RuleFor(v => v.name).NotEmpty()
                 .WithMessage(ValidationConstants.NameMustHasValue);

            RuleFor(v => v.companyName).NotEmpty()
                .WithMessage(ValidationConstants.CompanyNameMustHasValue);

            RuleFor(v => v.description).NotEmpty()
               .WithMessage(ValidationConstants.DescriptionMustHasValue);

            RuleFor(v => v.price).NotEmpty()
               .WithMessage(ValidationConstants.PriceMustHasValue);

            RuleFor(v => v.image).NotEmpty()
               .WithMessage(ValidationConstants.ImageMustHasValue);

            RuleFor(v => v.quantityinstock).NotEmpty()
               .WithMessage(ValidationConstants.QuantityInStockMustHasValue);

        }
    }
}
