using Application.Common.Constants;
using Application.Common.Validator;
using Application.Features.CarteElectroniqueFeature.Commands;
using FluentValidation;

namespace Application.Features.CustomerFeatures.Validators
{
    public class AddCarteElectroniqueCommandNewValidator : ValidatorBase<AddCarteElectroniqueCommand>
    {
        public AddCarteElectroniqueCommandNewValidator()
        {
            RuleFor(v => v.name).NotEmpty()
                .WithMessage(ValidationConstants.FirstNameMustHasValue);

            RuleFor(v => v.companyName).NotEmpty()
                .WithMessage(ValidationConstants.CompanyNameMustHasValue);

            RuleFor(v => v.description).NotEmpty()
               .WithMessage(ValidationConstants.DescriptionMustHasValue);

            RuleFor(v => v.image).NotEmpty()
               .WithMessage(ValidationConstants.ImageMustHasValue);

            RuleFor(v => v.price).NotEmpty()
               .WithMessage(ValidationConstants.PriceMustHasValue);

            RuleFor(v => v.quantityinstock).NotEmpty()
               .WithMessage(ValidationConstants.QuantityInStockMustHasValue);

        }
    }
}